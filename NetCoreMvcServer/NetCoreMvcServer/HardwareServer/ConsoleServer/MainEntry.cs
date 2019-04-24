using LitJson;
using NetCoreMvcServer;
using NetCoreMvcServer.Models;
using NetCoreMvcServer.Utility;
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
    public class MainEntry
    {

        static bool _bQuit = false;
        static CommandParser _CmdParser = new CommandParser();
        static UdpListener _Server;
        static UdpUser _Client;

        static int _TerminalPort = 5000;
        static int _GroundTruthPort = 4000;
        static int _ListenOnPort = 5000;
        static int _WebPort = 6000;

        static string _MCUFilePath = @"D:\DevelopProj\GreenV\Document\STM32F107_PTP.bin";

        public static SimpleLogger _Logger = new SimpleLogger();
        #region Callback

        public static Dictionary<string, Dictionary<string, Action<object>>> _SendCheckCallBackDic = new Dictionary<string, Dictionary<string, Action<object>>>();


        #endregion




        public static void Entry()
        {
            FileStream fs = new FileStream("udpterminalport.txt", FileMode.Open);
            var file = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8, true, 128);
            string eport = file.ReadLine();
            _TerminalPort = Convert.ToInt32(eport);

            fs = new FileStream("udplistenport.txt", FileMode.Open);
            file = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8, true, 128);
            eport = file.ReadLine();
            _ListenOnPort = Convert.ToInt32(eport);

            fs = new FileStream("udpgroundtruthport.txt", FileMode.Open);
            file = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8, true, 128);
            eport = file.ReadLine();
            _GroundTruthPort = Convert.ToInt32(eport);

            List<string> SendCBNames = new List<string>();
            SendCBNames.Add("SendT");
            SendCBNames.Add("SendR");
            SendCBNames.Add("SendST");
            SendCBNames.Add("SendSP");
            SendCBNames.Add("SendC");
            SendCBNames.Add("SendU");
            SendCBNames.Add("SendY");
            SendCBNames.Add("SendYAuto");
            foreach (string name in SendCBNames)
            {
                _SendCheckCallBackDic[name] = new Dictionary<string, Action<object>>();
            }
            _CmdParser.ConnectMySql();
            StartUdpServer();
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
        public static IPEndPoint GetGroundTruthIPEndPoint(string ip)
        {
            return GetGroundTruthIPEndPoint(IPAddress.Parse(ip));
        }

        public static IPEndPoint GetTerminalIPEndPoint(IPAddress ip)
        {
            return new IPEndPoint(ip, _TerminalPort);
        }
        public static IPEndPoint GetGroundTruthIPEndPoint(IPAddress ip)
        {
            return new IPEndPoint(ip, _GroundTruthPort);
        }

        public static IPEndPoint GetServerListenOnIPEndPoint(IPAddress ip)
        {
            return new IPEndPoint(ip, _ListenOnPort);
        }

        public static IPEndPoint GetWebIPEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse("127.0.0.1"), _WebPort);
        }

        public static void SendToTerminal(Package pkg,bool addtimer = true)
        {

            MainEntry._Logger.Debug("SendToTerminal:" + pkg._Cmd);
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


        static DateTime _LastExportDt = DateTime.MinValue;
        static DateTime GetLastExportDt()
        {
            if(_LastExportDt == DateTime.MinValue)
            {
                FileStream fs = new FileStream("LastExportDt.txt", FileMode.OpenOrCreate);
                var file = new System.IO.StreamReader(fs);
                string s = file.ReadLine();
                fs.Close();

                if(string.IsNullOrEmpty(s))
                {

                    App_SensorData first = Startup._GVContext.App_SensorData.First<App_SensorData>();
                    if(first != null)
                    {

                        _LastExportDt = first.createtime;
                    }
                }
                else
                {
                    _LastExportDt = DateTime.Parse(s);
                }

            }



            return _LastExportDt;
        }
        static void SaveLastExportDt()
        {
            FileStream fs = new FileStream("LastExportDt.txt", FileMode.OpenOrCreate);
            var file = new System.IO.StreamWriter(fs);
            file.WriteLine(_LastExportDt.ToString());
            file.Flush();
            fs.Close();
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



        public static void DebugSend()
        {
            string s = Console.ReadLine();

            string cmd = "";
            string ip = "";
            string param = "";

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
                SendToTerminal(_CmdParser.SendCheck(MainEntry.GetTerminalIPEndPoint(ip)));
            }
            else if (cmd == "r")
            {
                SendToTerminal(_CmdParser.SendReset(MainEntry.GetTerminalIPEndPoint(ip)));
            }
            else if (cmd == "s")
            {
                if (param == "t")
                {
                    SendToTerminal(_CmdParser.SendStartStop(MainEntry.GetTerminalIPEndPoint(ip), true));
                }
                else if (param == "p")
                {

                    SendToTerminal(_CmdParser.SendStartStop(MainEntry.GetTerminalIPEndPoint(ip), false));
                }
            }
            else if (cmd == "c")
            {

                short n = Convert.ToInt16(ParseConsoleLine(s, 2));
                short m = Convert.ToInt16(ParseConsoleLine(s, 3));

                SendToTerminal(_CmdParser.SendCollect(MainEntry.GetTerminalIPEndPoint(ip), n, m));
            }
            else if (cmd == "u")
            {
                string path = ParseConsoleLine(s, 2);

                SendToTerminal(_CmdParser.SendMCU(MainEntry.GetTerminalIPEndPoint(ip), path));

            }
            else if (cmd == "A")
            {
                SendToTerminal(_CmdParser.SendSensorDataRsp(MainEntry.GetTerminalIPEndPoint(ip)));

            }
            else if (cmd == "G")
            {
                if (param == "o")
                {
                    SendToTerminal(_CmdParser.SendGroundTruthRsp(MainEntry.GetGroundTruthIPEndPoint(ip), true));
                }
                else if (param == "e")
                {

                    SendToTerminal(_CmdParser.SendGroundTruthRsp(MainEntry.GetGroundTruthIPEndPoint(ip), false));
                }
            }
            else if (cmd == "y")
            {
                SendToTerminal(_CmdParser.SendSync(MainEntry.GetGroundTruthIPEndPoint(ip)));

            }
            else if (cmd == "Y")
            {
                SendToTerminal(_CmdParser.SendSyncAuto(MainEntry.GetGroundTruthIPEndPoint(ip),"Y>t1+t2"));

            }
        }



        public static void SendT(string ip,Action<object> cb)
        {
            _SendCheckCallBackDic["SendT"][ip] = cb;
            SendToTerminal(_CmdParser.SendCheck(MainEntry.GetTerminalIPEndPoint(ip)));
        }

        public static void SendS(string ip,bool start,Action<object> cb)
        {
            if(start)
            {
                _SendCheckCallBackDic["SendST"][ip] = cb;
                SendToTerminal(_CmdParser.SendStartStop(MainEntry.GetTerminalIPEndPoint(ip),true));

            }
            else
            {

                _SendCheckCallBackDic["SendSP"][ip] = cb;
                SendToTerminal(_CmdParser.SendStartStop(MainEntry.GetTerminalIPEndPoint(ip),false));
            }

        }
        public static void SendC(string ip,short m,short n, Action<object> cb)
        {
            _SendCheckCallBackDic["SendC"][ip] = cb;
            SendToTerminal(_CmdParser.SendCollect(MainEntry.GetTerminalIPEndPoint(ip),m,n));
        }
        public static void SendY(string ip,Action<object> cb)
        {
            _SendCheckCallBackDic["SendY"][ip] = cb;
            SendToTerminal(_CmdParser.SendSync(MainEntry.GetTerminalIPEndPoint(ip)));
        }
        public static void SendYAuto(string ip, Action<object> cb)
        {
            _SendCheckCallBackDic["SendYAuto"][ip] = cb;
            SendToTerminal(_CmdParser.SendSyncAuto(MainEntry.GetTerminalIPEndPoint(ip),""));
        }

        public static void SendCBParse(string name,string ip)
        {
            if(_SendCheckCallBackDic[name].ContainsKey(ip))
            {
                if (_SendCheckCallBackDic[name][ip] != null)
                {
                    _SendCheckCallBackDic[name][ip](ip);
                    _SendCheckCallBackDic[name].Remove(ip);
                }
            }
        }






     



    }
}
