using LitJson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleServer
{
    class Program
    {

        static bool _bQuit = false;
        static CommandParser _CmdParser = new CommandParser();
        static UdpListener _Server;
        static UdpUser _Client;

        static int _TerminalPort = 5000;
        static int _WebPort = 6000;

        static string _MCUFilePath = @"D:\DevelopProj\GreenV\Document\STM32F107_PTP.bin";


        static void Main(string[] args)
        {
            if(!_CmdParser.ConnectMySql())
            {
                Console.WriteLine("Connect Data Base Failed");
                Thread.Sleep(2000);
                return;
            }

            StartUdpServer();

            FileStream fs = new FileStream("cmd.txt", FileMode.Open);
            var file = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8, true, 128);

            List<string> cmdlist = new List<string>();
            string lineOfText;
            while ((lineOfText = file.ReadLine()) != null)
            {
                lineOfText = lineOfText.Trim();
                cmdlist.Add(lineOfText);
            }
            fs.Close();

            Action<object> action = (object obj) =>
            {
                for(int i = 0; i<cmdlist.Count;i++)
                {
                    string cmdline = cmdlist[i];

                    if(cmdline.StartsWith("s"))
                    {
                        string[] strarray = cmdline.Split(' ');
                        string ip = strarray[1];
                        if (cmdline.EndsWith("t"))
                        {
                            SendToTerminal(_CmdParser.SendStartStop(Program.GetTerminalIPEndPoint(ip), true));
                        }
                        else if (cmdline.EndsWith("p"))
                        {

                            SendToTerminal(_CmdParser.SendStartStop(Program.GetTerminalIPEndPoint(ip), false));
                        }
                    }
                   
                    else if (cmdline.StartsWith("c"))
                    {
                        string[] strarray = cmdline.Split(' ');
                        string ip = strarray[1];
                        short n = Convert.ToInt16(strarray[2]);
                        short m = Convert.ToInt16(strarray[3]);

                        SendToTerminal(_CmdParser.SendCollect(Program.GetTerminalIPEndPoint(ip), n, m));

                    }
                    else if (cmdline.StartsWith("time"))
                    {
                        string[] strarray = cmdline.Split(' ');
                        Thread.Sleep(Convert.ToInt32(strarray[1]));
                    }


                }

            };

            // Create a task but do not start it.
            Task t1 = new Task(action, "Cmd Script Task");
            t1.Start();
            /*
            while (!_bQuit)
            {
                try
                {
                    string s = Console.ReadLine();

                    string cmd = ParseConsoleLine(s, 0);
                    string ip = ParseConsoleLine(s, 1);
                    string param = ParseConsoleLine(s, 2);

                    if (cmd == "quit")
                    {
                        _bQuit = true;
                    }
                    else if (cmd == "stop")
                    {
                        char timercmd = (ParseConsoleLine(s, 1))[0];
                        QueueNeedRsp.Instance.RemovePackage(timercmd);

                    }
                    else if (cmd == "t")
                    {
                        SendToTerminal(_CmdParser.SendCheck(Program.GetTerminalIPEndPoint(ip)));
                    }
                    else if (cmd == "r")
                    {
                        SendToTerminal(_CmdParser.SendReset(Program.GetTerminalIPEndPoint(ip)));
                    }
                    else if (cmd == "s")
                    {
                        if (param == "t")
                        {
                            SendToTerminal(_CmdParser.SendStartStop(Program.GetTerminalIPEndPoint(ip), true));
                        }
                        else if (param == "p")
                        {

                            SendToTerminal(_CmdParser.SendStartStop(Program.GetTerminalIPEndPoint(ip), false));
                        }
                    }
                    else if (cmd == "c")
                    {

                        short n = Convert.ToInt16(ParseConsoleLine(s, 2));
                        short m = Convert.ToInt16(ParseConsoleLine(s, 3));

                        SendToTerminal(_CmdParser.SendCollect(Program.GetTerminalIPEndPoint(ip), n, m));
                    }
                    else if (cmd == "u")
                    {
                        string path = ParseConsoleLine(s, 2);

                        SendToTerminal(_CmdParser.SendMCU(Program.GetTerminalIPEndPoint(ip), path));

                    }
                    else if (cmd == "A")
                    {
                        SendToTerminal(_CmdParser.SendSensorDataRsp(Program.GetTerminalIPEndPoint(ip)));

                    }
                    else if (cmd == "G")
                    {
                        if (param == "o")
                        {
                            SendToTerminal(_CmdParser.SendGroundTruthRsp(Program.GetTerminalIPEndPoint(ip), true));
                        }
                        else if (param == "e")
                        {

                            SendToTerminal(_CmdParser.SendGroundTruthRsp(Program.GetTerminalIPEndPoint(ip), false));
                        }
                    }
                    else if (cmd == "y")
                    {
                        SendToTerminal(_CmdParser.SendSync(Program.GetTerminalIPEndPoint(ip)));

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

              

            }
           */

            byte[] data = new byte[] { 1, 2, 3, 4, 5, 6 };
            CommandParser._MySqlConnector.InsertSensor("192.168.8.52", 243912389, data);
            CommandParser._MySqlConnector.InsertGroundTruth("192.168.8.52", "09:32:23:421", 1);

            t1.Wait();
        }
        public static void SendToWeb(byte[] data)
        {
            int len = 0;
            if (data != null)
            {
                len = data.Length;
            }
            _Server.SendToWeb(data);
            Console.WriteLine(string.Format("SendToWeb: Len:{0}", len));
        }

        public static IPEndPoint GetTerminalIPEndPoint(string ip)
        {
            return GetTerminalIPEndPoint(IPAddress.Parse(ip));
        }
        public static IPEndPoint GetTerminalIPEndPoint(IPAddress ip)
        {
            return new IPEndPoint(ip, _TerminalPort);
        }
        public static IPEndPoint GetWebIPEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse("127.0.0.1"), _WebPort);
        }

        public static void SendToTerminal(Package pkg,bool addtimer = true)
        {
            Console.WriteLine(string.Format("SendToTerminal: {0}  Len:{1}", pkg._SendTo.Address, pkg._FullData.Length));
            _Server.SendToTerminal(pkg);

            if(addtimer)
            {
                QueueNeedRsp.Instance.AddPackage(pkg);
            }
        }

        static string ParseConsoleLine(string s,int index)
        {
            string[] arr = s.Split(' ');

            if(arr.Length > index)
            {
                return arr[index];
            }

            return "";
        }




        static void StartUdpServer()
        {
            //create a new server
            _Server = new UdpListener();


            Console.WriteLine("Init UDP Server OK , Start Receiving");
            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var received = await _Server.Receive();
                    _CmdParser.ReceiveData(received);
                }
            });

        }
        static void StartUdpClient()
        {
            //create a new client
            _Client = UdpUser.ConnectTo("127.0.0.1", 5000);
            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var received = await _Client.Receive();
                      


                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                }
            });


            //Task.Factory.StartNew(async () =>
            //{
            //    //type ahead :-)
            //    string read;
            //    do
            //    {
            //        read = Console.ReadLine();
            //        if(read == "sim")
            //        {
            //            _Client.Send(DebugPackageJsonData());
            //        }

            //    } while (read != "quit");

            //    _bQuit = true;
            //});

           
        }

        static byte[] DebugPackageJsonData()
        {
            JsonData inputdata = new JsonData();
            inputdata["cmd"] = "check";
            inputdata["ip"] = "192.168.1.1";

            string inputjsonstr = inputdata.ToJson();
            byte[] bytedata = ASCIIEncoding.ASCII.GetBytes(inputjsonstr);
            return bytedata;
            
        }
        static byte[] DebugPackageData()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter w = new BinaryWriter(ms);

            char cmd = 'T';
            Int16 frame = 0;
            Int16 len = 0;

            ms.Seek(0, SeekOrigin.Begin);
            w.Write(cmd);
            w.Write(frame);
            w.Write(len);


            ms.Seek(0, SeekOrigin.Begin);

            byte[] buffer = ms.GetBuffer();
            return buffer;
        }
    }
}
