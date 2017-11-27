using LitJson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    class Program
    {

        static bool _bQuit = false;
        static CommandParser _CmdParser = new CommandParser();
        static UdpListener _Server;
        static UdpUser _Client;

        static string _MCUFilePath = @"D:\DevelopProj\GreenV\Document\STM32F107_PTP.bin";


        static void Main(string[] args)
        {
            //if (args[0] == "simulateclient")
            //{
                //StartUdpClient();
            //}


            StartUdpServer();

            while (!_bQuit)
            {

                string s = Console.ReadLine();

                string cmd = ParseConsoleLine(s, 0);
                string ip = ParseConsoleLine(s, 1);
                string param = ParseConsoleLine(s, 2);

                if (cmd == "quit")
                {
                    _bQuit = true;
                }
                else if (cmd =="t")
                {
                    _Server.SendToTerminal(_CmdParser.SendCheck(),ip);
                }
                else if (cmd == "s")
                {
                    if(param == "t")
                    {
                        _Server.SendToTerminal(_CmdParser.SendStartStop(true),ip);
                    }
                    else if (param == "p")
                    {

                        _Server.SendToTerminal(_CmdParser.SendStartStop(false), ip);
                    }
                }
                else if (cmd == "c")
                {

                    short n = Convert.ToInt16(ParseConsoleLine(s, 2));
                    short m = Convert.ToInt16(ParseConsoleLine(s, 3));

                    _Server.SendToTerminal(_CmdParser.SendCollect(n, m), ip);
                }
                else if (cmd == "u")
                {
                    string path = ParseConsoleLine(s, 2);              

                    _Server.SendToTerminal(_CmdParser.SendMCU(path), ip);

                }
                else if (cmd == "A")
                {
                    _Server.SendToTerminal(_CmdParser.SendSensorDataRsp(), ip);

                }

            }
           
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
        public static void SendToTerminal(byte[] data,string ip)
        {
            int len = 0;
            if(data !=null)
            {
                len = data.Length;
            }

            Console.WriteLine(string.Format("SendToTerminal: {0}  Len:{1}", ip, len));
            _Server.SendToTerminal(data, ip);
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
