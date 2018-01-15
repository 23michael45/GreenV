using LitJson;
using NetCoreMvcServer;
using NetCoreMvcServer.Models;
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
        static int _WebPort = 6000;

        static string _MCUFilePath = @"D:\DevelopProj\GreenV\Document\STM32F107_PTP.bin";


        #region Callback

        public static Dictionary<string, Dictionary<string, Action<object>>> _SendCheckCallBackDic = new Dictionary<string, Dictionary<string, Action<object>>>();


        #endregion




        public static void Entry()
        {
            List<string> SendCBNames = new List<string>();
            SendCBNames.Add("SendT");
            SendCBNames.Add("SendR");
            SendCBNames.Add("SendST");
            SendCBNames.Add("SendSP");
            SendCBNames.Add("SendC");
            SendCBNames.Add("SendU");
            SendCBNames.Add("SendY");
            foreach(string name in SendCBNames)
            {
                _SendCheckCallBackDic[name] = new Dictionary<string, Action<object>>();
            }
            _CmdParser.ConnectMySql();
            StartUdpServer();
            StartAutoExportTxt();
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


        static void StartAutoExportTxt()
        {
            Console.WriteLine("StartAutoExportTxt");

            IQueryable<Terminal> terminals = null;
            terminals = Startup._GVContext.Terminals.OrderBy(item => item.ip);


            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    DateTime last = GetLastExportDt();

                    DateTime startdt = new DateTime(
                     last.Year,
                     last.Month,
                     last.Day,
                     last.Hour,
                     last.Minute,
                     0,
                     0);

                    DateTime enddt = startdt.AddMinutes(1);

                    if (DateTime.Now > enddt)
                    {


                        terminals = Startup._GVContext.Terminals.OrderBy(item => item.ip);
                        foreach (Terminal terminal in terminals)
                        {
                            if(ExportTxt(Startup._GVContext, terminal.ip, startdt, enddt))
                            {

                            }
                        }

                        _LastExportDt = enddt;
                        SaveLastExportDt();
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }

                }
            });

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
                    SendToTerminal(_CmdParser.SendGroundTruthRsp(MainEntry.GetTerminalIPEndPoint(ip), true));
                }
                else if (param == "e")
                {

                    SendToTerminal(_CmdParser.SendGroundTruthRsp(MainEntry.GetTerminalIPEndPoint(ip), false));
                }
            }
            else if (cmd == "y")
            {
                SendToTerminal(_CmdParser.SendSync(MainEntry.GetTerminalIPEndPoint(ip)));

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






        public static bool ExportTxt(GVContext context, string ip, DateTime startdt, DateTime enddt)
        {
            try
            {
                IQueryable<App_SensorData> rt = null;
                if (ip == null || ip == "" || ip == "undefined")
                {

                    return false;
                }
                else
                {
                    rt = context.App_SensorData.Where(item => (item.device == ip) && (item.createtime > startdt && item.createtime < enddt)).OrderBy(it => it.createtime);

                }

                string rootdir = "Export";
                if (!Directory.Exists(rootdir))
                {
                    Directory.CreateDirectory(rootdir);
                }

                string ipstring = rootdir + "/" + ip;
                if (!Directory.Exists(ipstring))
                {
                    Directory.CreateDirectory(ipstring);
                }

                string daystring = startdt.ToString("yyyy-MM-dd");
                daystring = daystring.Replace("/", "-");
                daystring = rootdir + "/" + ip + "/" + daystring;
                if (!Directory.Exists(daystring))
                {
                    Directory.CreateDirectory(daystring);
                }


                string minitestring = startdt.ToString("HH-mm");
                string filename = daystring + "/" + minitestring + ".txt";


                if (System.IO.File.Exists(filename) == true)
                {
                    System.IO.File.Delete(filename);
                }



                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                var file = new System.IO.StreamWriter(fs);

                //int totalCount = rt.Count<App_SensorData>();

                if (rt == null)
                {
                    file.Flush();
                    fs.Close();
                    return false;
                }
                foreach (App_SensorData asd in rt)
                {


                    Guid id = asd.Id;
                    string device = asd.device;
                    int timestamps = asd.timestamps;
                    int timestampms = asd.timestampms;
                    int rate = asd.rate;
                    int gain = asd.gain;
                    DateTime createtime = asd.createtime;



                    byte[] data = new byte[1200];
                    long len = asd.sensorvalue.Length;
                    MemoryStream ms = new MemoryStream(asd.sensorvalue);
                    BinaryReader reader = new BinaryReader(ms);


                    string s = string.Format(" createtime:{0} device:{1} timestamp:{2} : {3}  rate: {4}  gain:{5} data: ", createtime, device, timestamps, timestampms, rate, gain);
                    for (int i = 0; i < len / 2; i++)
                    {
                        UInt16 d = reader.ReadUInt16();
                        s += " " + d.ToString();
                    }
                    file.WriteLine(s);

                }

                file.Flush();
                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
            
        



    }
}
