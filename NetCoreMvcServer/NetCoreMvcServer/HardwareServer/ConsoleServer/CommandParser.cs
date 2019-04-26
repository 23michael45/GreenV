using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using LitJson;
using System.Net;
using NetCoreMvcServer.Controllers;
using NetCoreMvcServer.Utility;
using NetCoreMvcServer.Models;
using System.Threading;
using NetCoreMvcServer;
using ConsoleServer;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleServer
{
    public class CommandParser
    {
        PackageParser _PackageParser;


        public static string _ExportPath = "C:/Export";
        public static MySqlConnector _MySqlConnector;
        public static SensorCache _SensorCache = new SensorCache();
        public static GroundTruthCache _GroundTruthCache = new GroundTruthCache();

        public static Mutex mutex = new Mutex();

        public CommandParser()
        {
            _MySqlConnector = new MySqlConnector();
            _PackageParser = new PackageParser();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5);
                _SensorCache.StartAutoExportTxt();
                _GroundTruthCache.StartAutoExportTxt();
            });

        }

        public bool  ConnectMySql()
        {
            try
            {

                _MySqlConnector.Connect();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        int _CurrentMCUFrame = 0;
        byte[] _MCUFiledata;

        #region Send Cmd Trunk


        TerminalPackage SendCmdBase(IPEndPoint iep,char cmd, Int16 framecount, byte[] data = null)
        {
            short len = 0;
            if (data != null)
            {
                len = (short)data.Length;
            }

            TerminalPackage pkg = new TerminalPackage(iep, null, cmd, framecount, len, data);

            return pkg;
        }

        byte[] SendCmdJson(string cmd,string ip,string code)
        {
            JsonData inputdata = new JsonData();
            inputdata["cmd"] = cmd;
            inputdata["ip"] =  ip;
            inputdata["code"] = code;

            string inputjsonstr = inputdata.ToJson();
            byte[] bytedata = ASCIIEncoding.ASCII.GetBytes(inputjsonstr);
            return bytedata;
        }

        #endregion
        #region Receive Cmd Trunk

        void ParseJsonFromWeb(JsonPackage pkg)
        {
            try
            {
                
                string cmd = pkg.GetString("cmd").ToString();

                if (cmd == "check")
                {
                    IPEndPoint iep = MainEntry.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    MainEntry.SendToTerminal(SendCheck(iep));

                    MainEntry.SendToWeb(SendCmdJson("checkrsp", pkg.GetString("ip"), "ok"));
                }
                else if (cmd == "reset")
                {
                    IPEndPoint iep = MainEntry.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    MainEntry.SendToTerminal(SendReset(iep));

                    MainEntry.SendToWeb(SendCmdJson("resetrsp", pkg.GetString("ip"), "ok"));
                }
                else if (cmd == "startstop")
                {

                    IPEndPoint iep = MainEntry.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    MainEntry.SendToTerminal(SendStartStop(iep, pkg.GetBool("isstart")));

                }
                else if (cmd == "collection")
                {
                    IPEndPoint iep = MainEntry.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    MainEntry.SendToTerminal(SendCollect(iep, pkg.GetUInt16("gain"),pkg.GetUInt16("rate")));

                }
                else if (cmd == "mcu")
                {
                    IPEndPoint iep = MainEntry.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    MainEntry.SendToTerminal(SendMCU(iep, pkg.GetString("binpath")));

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        void ParseByteFromTerminal(TerminalPackage pkg)
        {
            MainEntry._Logger.Debug("Receive ParseByteFromTerminal:" + pkg._Cmd);
            byte[] data = pkg._PackageData;
            string ip = pkg._ReceiveFrom.Address.ToString();
            char cmd = pkg._Cmd;
            int datalen = pkg._Len;
            if (pkg._FullData.Length >= 5)
            {
                BinaryReader reader = null;
              
                if(datalen > 0)
                {

                    MemoryStream stream = new MemoryStream(data);
                    reader = new BinaryReader(stream);
                }

                QueueNeedRsp.Instance.RemovePackage(cmd);

                if (cmd == 'T')
                {
                    ReceiveCheck(datalen, reader, ip);
                }
                else if (cmd == 'S')
                {
                    ReceiveStartStop(datalen, reader, ip);
                }
                else if (cmd == 'C')
                {

                    ReceiveCollection(datalen, reader, ip);
                }
                else if (cmd == 'U')
                {

                    ReceiveMCU(datalen, reader, ip);
                }
                else if (cmd == 'D')
                {
                    ReceiveMCUData(datalen, reader, ip);

                }
                else if (cmd == 'a')
                {

                    ReceiveSensorData(datalen, reader, ip);
                }
                else if (cmd == 'm')
                {

                    ReceiveMessage(datalen, reader, ip);
                }
                if (pkg._Cmd == 'g')
                {
                    ReceiveGroundTruth(datalen, reader, ip);
                }
            }
            else
            {

                Console.WriteLine("ReceiveData Empty");
            }

        }
        void ParseByteFromString(StringPackage pkg)
        {

            MainEntry._Logger.Debug("Receive ParseByteFromString:" + pkg._Cmd);
            QueueNeedRsp.Instance.RemovePackage(pkg._Cmd);


            if (pkg._Cmd == 'g')
            {
                //ReceiveGroundTruth(pkg);
            }
            else if (pkg._Cmd == 'Y')
            {

                //ReceiveSyncRsp(pkg);
            }
            else if (pkg._Cmd == 'y')
            {

                //DateTime now = DateTime.Now;
                //pkg._AddtionalData = now;
                //ReceiveSyncAutoRsp(pkg);
            }


            else
            {

                Console.WriteLine("ReceiveData Empty");
            }

        }

        public void ReceiveData(Package pkg)
        {
            if(pkg == null)
            {
                return;
            }
            try
            {
                if (pkg._PackageType == Package.ENUMPACKAGETYPE.EPT_JSON)
                {
                    try
                    {
                        ParseJsonFromWeb(pkg as JsonPackage);
                    }
                    catch (Exception ex)
                    {

                        ParseByteFromTerminal(pkg as TerminalPackage);
                    }

                }
                else if (pkg._PackageType == Package.ENUMPACKAGETYPE.EPT_TERMINAL)
                {
                    ParseByteFromTerminal(pkg as TerminalPackage);

                }
                else if (pkg._PackageType == Package.ENUMPACKAGETYPE.EPT_STRING)
                {
                    ParseByteFromString(pkg as StringPackage);

                }

            }
            catch (Exception ex)
            {
                Console.Write("Receive Data Format Error");
            }


      



        }

        #endregion


        #region Send Cmd To Terminal

        public TerminalPackage SendCheck(IPEndPoint iep)
        {
            return SendCmdBase(iep,'t', 0);
        }


        public TerminalPackage SendReset(IPEndPoint iep)
        {
            return SendCmdBase(iep, 'r', 0);
        }

        public TerminalPackage SendStartStop(IPEndPoint iep,bool bstart)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            
            if (bstart)
            {
                writer.Write('t');
            }
            else
            {
                writer.Write('p');

            }
            stream.Seek(0, SeekOrigin.Begin);


            byte[] buffer = new byte[stream.Length];
            Buffer.BlockCopy(stream.GetBuffer(), 0, buffer, 0, (int)stream.Length);

            return SendCmdBase(iep,'s', 0, buffer);
        }

        public TerminalPackage SendCollect(IPEndPoint iep, UInt16 gain, UInt16 rate)
        {
            
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
     
            writer.Write(rate);
            writer.Write(gain);
            stream.Seek(0, SeekOrigin.Begin);


            byte[] buffer = new byte[stream.Length];
            Buffer.BlockCopy(stream.GetBuffer(), 0, buffer, 0, (int)stream.Length);

            return SendCmdBase(iep, 'c', 0, buffer);
        }

        public TerminalPackage SendMCU(IPEndPoint iep, string path)
        {
            try
            {
                FileStream fs = File.Open(path, FileMode.Open);
                long len = fs.Length;

                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Seek(0, SeekOrigin.Begin);

                int x = (int)fs.Length;
                fs.Close();
                _MCUFiledata = bytes;

                MemoryStream stream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(x);
                stream.Seek(0, SeekOrigin.Begin);

                byte[] buffer = new byte[stream.Length];
                Buffer.BlockCopy(stream.GetBuffer(), 0, buffer, 0, (int)stream.Length);

                return SendCmdBase(iep, 'u', 0, buffer);
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
            return null;
  
        }

        public TerminalPackage SendMCUData(IPEndPoint iep)
        {
            int fileframelen = 2048;

            int dataleftlen = _MCUFiledata.Length - _CurrentMCUFrame * fileframelen;
            dataleftlen = Math.Min(dataleftlen, fileframelen);

            byte[] buffer = new byte[dataleftlen];

            Buffer.BlockCopy(_MCUFiledata, _CurrentMCUFrame * fileframelen, buffer, 0, dataleftlen);

            return SendCmdBase(iep, 'd', (short)_CurrentMCUFrame, buffer);
        }

        public TerminalPackage SendSensorDataRsp(IPEndPoint iep)
        {
            return SendCmdBase(iep, 'A', 0);
        }


        public TerminalPackage SendMessageRsp(IPEndPoint iep)
        {
            return SendCmdBase(iep, 'M', 0);
        }

        public StringPackage SendGroundTruthRsp(IPEndPoint iep,bool succ)
        {
            string str;
            if (succ)
            {
                str = "G>o";
            }
            else
            {
                str = "G>e";

            }
            StringPackage pkg = new StringPackage(iep, null, str);

            return pkg;
        }

        public StringPackage SendSync(IPEndPoint iep)
        {
            DateTime now = DateTime.Now;
            string str = string.Format("y>{0:D2}:{1:D2}:{2:D2}:{3}", now.Hour, now.Minute, now.Second, now.Millisecond);
            return new StringPackage(iep, null, str);
        }
        public StringPackage SendSyncAuto(IPEndPoint iep,string t1t2)
        {
            DateTime now = DateTime.Now;
            string str = t1t2 + string.Format("{0:D2}:{1:D2}:{2:D2}:{3}", now.Hour, now.Minute, now.Second, now.Millisecond);
            return new StringPackage(iep, null, str);
        }
        #endregion




        #region Receive Cmd FromTerminal


        void ReceiveCheck(int len, BinaryReader reader,string ip)
        {
            Console.WriteLine("ReceiveCheck OK");
            MainEntry.SendCBParse("SendT",ip);
          
        }

        void ReceiveStartStop(int len, BinaryReader reader, string ip)
        {
            if(len == 1)
            {
                byte bytedata = reader.ReadByte();

                char ret = (char)bytedata;

                if (ret == 't')
                {

                    Console.WriteLine("ReceiveStart OK");
                    MainEntry.SendCBParse("SendST", ip);
                }
                else if (ret == 'p')
                {

                    Console.WriteLine("ReceiveStop OK");
                    MainEntry.SendCBParse("SendSP", ip);
                }
                else if (ret == 'e')
                {
                    Console.WriteLine("ReceiveStartStop Error");
                    MainEntry.SendCBParse("SendST", "error");
                    MainEntry.SendCBParse("SendSP", "error");
                }

            }

        }

        void ReceiveCollection(int len, BinaryReader reader, string ip)
        {
            if (len == 1)
            {
                char ret = (char)reader.ReadByte();

                if (ret == 'o')
                {

                    Console.WriteLine("ReceiveCollection OK");
                    MainEntry.SendCBParse("SendC", ip);
                }
                else if (ret == 'e')
                {

                    Console.WriteLine("ReceiveCollection Error");
                    MainEntry.SendCBParse("SendC", "error");
                }
            }
        }
        void ReceiveMCU(int len, BinaryReader reader, string ip)
        {
            if (len == 1)
            {
                char ret = (char)reader.ReadByte();

                if (ret == 'o')
                {
                    Console.WriteLine("ReceiveMCU OK");

                    MainEntry.SendCBParse("SendU", ip);

                    _CurrentMCUFrame = 0;
                    
                    MainEntry.SendToTerminal(SendMCUData(MainEntry.GetTerminalIPEndPoint(ip)));

                }
                else if (ret == 'e')
                {
                    Console.WriteLine("ReceiveMCU Error");
                    MainEntry.SendCBParse("SendU", "error");

                }


            }
        }
        void ReceiveMCUData(int len, BinaryReader reader, string ip)
        {
            if (len == 1)
            {
                char ret = (char)reader.ReadByte();

                if (ret == 'o')
                {
                    _CurrentMCUFrame++;

                    MainEntry.SendToTerminal(SendMCUData(MainEntry.GetTerminalIPEndPoint(ip)));

                    Console.WriteLine("ReceiveMCUData Frame OK");
                }
                else if (ret == 'e')
                {
                    _CurrentMCUFrame = 0;

                    Console.WriteLine("ReceiveMCUData Error");
                }
                else if (ret == 'c')
                {

                    _CurrentMCUFrame = 0;
                    Console.WriteLine("ReceiveMCUData All OK");
                }


            }
        }

        void ReceiveSensorData(int len, BinaryReader reader,string ip )
        {
            MainEntry.SendToTerminal(SendSensorDataRsp(MainEntry.GetTerminalIPEndPoint(ip)),false);

            UInt32 timestamps = reader.ReadUInt32();
            UInt32 timestampms = reader.ReadUInt32();
            UInt16 rate = reader.ReadUInt16();
            UInt16 gain = reader.ReadUInt16();

            //for(int i = 0;i < len - 12;i += 2)//每次处理2个字节   len - 12 = 1200
            //{
            //    Int16 advalue = reader.ReadInt16();


            //    if(_MySqlConnector != null)
            //    {
            //        _MySqlConnector.InsertSensor(ip, timestampms, advalue);

            //    }
            //}

            if (TerminalController._ConnectedTerminals.ContainsStringKey(ip))
            {

                TerminalController._ConnectedTerminals.GetStringKey(ip).mIsStart = true;
                TerminalController._ConnectedTerminals.GetStringKey(ip).mRate = rate;
                TerminalController._ConnectedTerminals.GetStringKey(ip).mGain = gain;
                TerminalController._ConnectedTerminals.GetStringKey(ip).ResetTimer();
            }
            else
            {
                TerminalController._ConnectedTerminals.AddIfNotExistStringKey(ip);
                TerminalController._ConnectedTerminals.GetStringKey(ip).mRate = rate;
                TerminalController._ConnectedTerminals.GetStringKey(ip).mGain = gain;
                TerminalController._ConnectedTerminals.GetStringKey(ip).mIsStart = true;
            }


            byte[] bufferdata = reader.ReadBytes(len - 12);
            //if (_MySqlConnector != null)
            //{
            //    _MySqlConnector.InsertSensor(ip, timestamps, timestampms,rate,gain,bufferdata);

            //}

            //测试用
            //ip = string.Format("192.168.{0}.{1}", rate, gain); 

            _SensorCache.Insert(ip, timestamps, timestampms, rate, gain, bufferdata);

            Console.WriteLine("ReceiveSensorData " + (len - 12 ) / 2);

        }


        void ReceiveMessage(int len, BinaryReader reader, string ip)
        {

            Console.WriteLine("ReceiveMessage OK");

            if (TerminalController._ConnectedTerminals.ContainsStringKey(ip))
            {
                TerminalController._ConnectedTerminals.GetStringKey(ip).ResetTimer();
            }
            else
            {
                TerminalController._ConnectedTerminals.AddIfNotExistStringKey(ip);
            }


            MainEntry.SendToTerminal(SendMessageRsp(MainEntry.GetTerminalIPEndPoint(ip)),false);

        }

        //void ReceiveGroundTruth(StringPackage pkg)
        void ReceiveGroundTruth(int len, BinaryReader reader, string ip)
        {
            try
            {

                //string ip = pkg._ReceiveFrom.Address.ToString();

                //string s = pkg._StringContent;
                //int start = s.IndexOf('>');
                //int end = s.IndexOf('=');
                //string time = s.Substring(start + 1, end - start - 1);
                //string slr = s.Substring(end + 1, 1);
                //ushort lr = Convert.ToUInt16(slr);

                //string[] timeparam = time.Split(':');
                //if (timeparam.Length == 4)
                //{
                //    int hour = Convert.ToInt32(timeparam[0]);
                //    int min = Convert.ToInt32(timeparam[1]);
                //    int sec = Convert.ToInt32(timeparam[2]);
                //    int ms = Convert.ToInt32(timeparam[3]);
                //}


                byte nodeIndex = reader.ReadByte();
                byte lr = reader.ReadByte();
                int timestamps = reader.ReadInt32();
                int timestampms = reader.ReadInt32();



                //if (_MySqlConnector != null)
                //{
                //    _MySqlConnector.InsertGroundTruth(ip, timestamps, timestampms, nodeIndex,lr);

                //}


                _GroundTruthCache.Insert(ip, nodeIndex,timestamps, timestampms, lr);

                //MainEntry.SendToTerminal(SendGroundTruthRsp(pkg._ReceiveFrom, true),false);
                MainEntry.SendToTerminal(SendGroundTruthRsp(MainEntry.GetTerminalIPEndPoint(ip), true), false);
            }
            catch(Exception e)
            {
                //MainEntry.SendToTerminal(SendGroundTruthRsp(pkg._ReceiveFrom, false),false);
                MainEntry.SendToTerminal(SendGroundTruthRsp(MainEntry.GetTerminalIPEndPoint(ip), false), false);
            }

        }
        void ReceiveSyncRsp(StringPackage pkg)
        {
            if (pkg._StringContent == "Y>o")
            {

                Console.WriteLine("ReceiveSyncRsp OK");
                MainEntry.SendCBParse("SendY", "");
            }
            else if (pkg._StringContent == "Y>e")
            {

                Console.WriteLine("ReceiveSyncRsp Failed");
                MainEntry.SendCBParse("SendY", "error");
            }
        }
        void ReceiveSyncAutoRsp(StringPackage pkg)
        {
            if (pkg._StringContent.StartsWith("y"))
            {
                string T1 = pkg._StringContent.Replace("y>","Y>");

                DateTime recTime = (DateTime)pkg._AddtionalData;
                string T2 = string.Format("+{0:D2}:{1:D2}:{2:D2}:{3}", recTime.Hour, recTime.Minute, recTime.Second, recTime.Millisecond);

                DateTime now = DateTime.Now;
                string T3 = string.Format("+{0:D2}:{1:D2}:{2:D2}:{3}", now.Hour, now.Minute, now.Second, now.Millisecond);

                string str = T1 + T2 + T3;
                Console.WriteLine("ReceiveSyncAuto OK");
                MainEntry.SendToTerminal(new StringPackage(pkg._ReceiveFrom, null, str), false);
            }
        }



        #endregion


    }
}






public class GroundTruthCache
{


    public class DeviceCache
    {
        public class MiniteCache
        {
            public DateTime _Minite;
            public List<App_GroundTruthData> _DataList = new List<App_GroundTruthData>();



        }


        public DateTime _LastRevTime;
        public string _IP;

        public Queue<MiniteCache> _MiniteCache = new Queue<MiniteCache>();

        public void AddMiniteCache(App_GroundTruthData data)
        {
            if (_MiniteCache.Count == 0)
            {
                MiniteCache newminite = new MiniteCache();

                DateTime mtime = new DateTime(
                   data.createtime.Year,
                   data.createtime.Month,
                   data.createtime.Day,
                   data.createtime.Hour,
                   data.createtime.Minute,
                   0,
                   0);

                newminite._Minite = mtime;
                _MiniteCache.Enqueue(newminite);
                newminite._DataList.Add(data);

                return;
            }
            else
            {

            }

            MiniteCache last = _MiniteCache.Last<MiniteCache>();
            DateTime firstdt = last._Minite;

            DateTime startdt = new DateTime(
             firstdt.Year,
             firstdt.Month,
             firstdt.Day,
             firstdt.Hour,
             firstdt.Minute,
             0,
             0);

            DateTime enddt = startdt.AddMinutes(1);


            if (data.createtime > enddt)
            {
                DateTime newdt = new DateTime(
                data.createtime.Year,
                data.createtime.Month,
                data.createtime.Day,
                data.createtime.Hour,
                data.createtime.Minute,
                0,
                0);

                MiniteCache newminite = new MiniteCache();
                newminite._Minite = newdt;

                _MiniteCache.Enqueue(newminite);
                newminite._DataList.Add(data);


            }
            else
            {
                last._DataList.Add(data);

            }
        }



        public bool ExportTxt(DeviceCache.MiniteCache minitecache)
        {
            try
            {

                string rootdir = CommandParser._ExportPath;
                if (!Directory.Exists(rootdir))
                {
                    Directory.CreateDirectory(rootdir);
                }

                string ipstring = rootdir + "/" + _IP;
                if (!Directory.Exists(ipstring))
                {
                    Directory.CreateDirectory(ipstring);
                }

                string daystring = minitecache._Minite.ToString("yyyy-MM-dd");
                daystring = daystring.Replace("/", "-");
                daystring = rootdir + "/" + _IP + "/" + "gt-" + daystring;
                if (!Directory.Exists(daystring))
                {
                    Directory.CreateDirectory(daystring);
                }


                string minitestring = minitecache._Minite.ToString("HH-mm");
                string filename = daystring + "/" + minitestring + ".txt";


                if (System.IO.File.Exists(filename) == true)
                {
                    System.IO.File.Delete(filename);
                }



                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                var file = new System.IO.StreamWriter(fs);

                //int totalCount = rt.Count<App_SensorData>();

                if (minitecache == null)
                {
                    file.Flush();
                    fs.Close();
                    return false;
                }
                foreach (App_GroundTruthData agd in minitecache._DataList)
                {


                    long id = agd.Id;
                    string device = agd.device;
                    int timestamp = agd.timestamp;
                    int timestampms = agd.timestampms;
                    int leftright = agd.leftright;
                    byte nodeindex = agd.nodeindex;
                    DateTime createtime = agd.createtime;




                    string s = string.Format(" createtime:{0} device:{1} timestamp:{2} timestampms: {3}  leftright: {4} nodeIndex:{5}", createtime, device, timestamp, timestampms, leftright,nodeindex);
                  
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

        public void ProcessOnce()
        {
            if (_MiniteCache.Count == 0)
            {
                return;
            }
            MiniteCache first = _MiniteCache.First<MiniteCache>();
            DateTime firstdt = first._Minite;

            DateTime startdt = new DateTime(
             firstdt.Year,
             firstdt.Month,
             firstdt.Day,
             firstdt.Hour,
             firstdt.Minute,
             0,
             0);

            DateTime enddt = startdt.AddMinutes(1);

            if (DateTime.Now > enddt)
            {
                MiniteCache exfirst = _MiniteCache.Dequeue();
                ExportTxt(exfirst);

            }
        }
    }

    public Dictionary<string, DeviceCache> _DevicesCache = new Dictionary<string, DeviceCache>();


    public void Insert(string ip, byte nodeindex,int timestamp ,int timestampms, byte lr)
    {
        DeviceCache dv = GetDevice(ip);


        DateTime dt = DateTime.Now;
        
        App_GroundTruthData data = new App_GroundTruthData();
        data.createtime = dt;
        data.device = ip;
        data.timestamp = timestamp;
        data.timestampms = timestampms;
        data.leftright = lr;
        data.nodeindex = nodeindex;

        dv.AddMiniteCache(data);
        

    }

    public DeviceCache GetDevice(string ip)
    {
        if(_DevicesCache.ContainsKey(ip))
        {
            return _DevicesCache[ip];
        }
        else
        {
            DeviceCache cache = new DeviceCache();
            cache._IP = ip;
            cache._LastRevTime = DateTime.Now;
            _DevicesCache.Add(ip, cache);
            return cache;
        }
    }


    Task _ExportTask;
    CancellationTokenSource tokenSource;
    public void StartAutoExportTxt()
    {
        tokenSource = new CancellationTokenSource();
        Console.WriteLine("StartAutoExportTxt");

        IQueryable<GroundTruth> groundtruths = null;
        _ExportTask = Task.Factory.StartNew(() =>
        {

            var GVContext = Startup.CreateDBContext();
            while (true)
            {

                groundtruths = GVContext.GroundTruths.OrderBy(item => item.ip);


                foreach (GroundTruth groundtruth in groundtruths)
                {
                    DeviceCache dv = GetDevice(groundtruth.ip);
                    dv.ProcessOnce();
                }

                Thread.Sleep(30000);

                if (tokenSource.IsCancellationRequested == true)
                {
                    Console.WriteLine("Task {0} was cancelled before it got started.",
                                      tokenSource);
                    tokenSource.Token.ThrowIfCancellationRequested();
                }
            }
            
        });

    }
    public void Reset()
    {
        if(_ExportTask != null && tokenSource != null)
        {
            var token = tokenSource.Token;
            tokenSource.Cancel();
            tokenSource = null;
            _ExportTask = null;
        }

        Thread.Sleep(1000);

        StartAutoExportTxt();
    }


}



public class SensorCache
{



    public class DeviceCache
    {
        public class MiniteCache
        {
            public DateTime _Minite;
            public List<App_SensorData> _DataList = new List<App_SensorData>();



        }


        public DateTime _LastRevTime;
        public string _IP;

        public Queue<MiniteCache> _MiniteCache = new Queue<MiniteCache>();

        public void AddMiniteCache(App_SensorData data)
        {
            if (_MiniteCache.Count == 0)
            {
                MiniteCache newminite = new MiniteCache();

                DateTime mtime = new DateTime(
                   data.createtime.Year,
                   data.createtime.Month,
                   data.createtime.Day,
                   data.createtime.Hour,
                   data.createtime.Minute,
                   0,
                   0);

                newminite._Minite = mtime;
                _MiniteCache.Enqueue(newminite);
                newminite._DataList.Add(data);

                return;
            }
            else
            {

            }

            MiniteCache last = _MiniteCache.Last<MiniteCache>();
            DateTime firstdt = last._Minite;

            DateTime startdt = new DateTime(
             firstdt.Year,
             firstdt.Month,
             firstdt.Day,
             firstdt.Hour,
             firstdt.Minute,
             0,
             0);

            DateTime enddt = startdt.AddMinutes(1);


            if (data.createtime > enddt)
            {
                DateTime newdt = new DateTime(
                data.createtime.Year,
                data.createtime.Month,
                data.createtime.Day,
                data.createtime.Hour,
                data.createtime.Minute,
                0,
                0);

                MiniteCache newminite = new MiniteCache();
                newminite._Minite = newdt;

                _MiniteCache.Enqueue(newminite);
                newminite._DataList.Add(data);


            }
            else
            {
                last._DataList.Add(data);

            }
        }




        public bool ExportTxt(DeviceCache.MiniteCache minitecache)
        {
            try
            {

                string rootdir = CommandParser._ExportPath;
                if (!Directory.Exists(rootdir))
                {
                    Directory.CreateDirectory(rootdir);
                }

                string ipstring = rootdir + "/" + _IP;
                if (!Directory.Exists(ipstring))
                {
                    Directory.CreateDirectory(ipstring);
                }

                string daystring = minitecache._Minite.ToString("yyyy-MM-dd");
                daystring = daystring.Replace("/", "-");
                daystring = rootdir + "/" + _IP + "/" + "sd-" + daystring;
                if (!Directory.Exists(daystring))
                {
                    Directory.CreateDirectory(daystring);
                }


                string minitestring = minitecache._Minite.ToString("HH-mm");
                string filename = daystring + "/" + minitestring + ".txt";


                if (System.IO.File.Exists(filename) == true)
                {
                    System.IO.File.Delete(filename);
                }



                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                var file = new System.IO.StreamWriter(fs);

                //int totalCount = rt.Count<App_SensorData>();

                if (minitecache == null)
                {
                    file.Flush();
                    fs.Close();
                    return false;
                }
                foreach (App_SensorData asd in minitecache._DataList)
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

        public void ProcessOnce()
        {
            if (_MiniteCache.Count == 0)
            {
                return;
            }
            MiniteCache first = _MiniteCache.First<MiniteCache>();
            DateTime firstdt = first._Minite;

            DateTime startdt = new DateTime(
             firstdt.Year,
             firstdt.Month,
             firstdt.Day,
             firstdt.Hour,
             firstdt.Minute,
             0,
             0);

            DateTime enddt = startdt.AddMinutes(1);

            if (DateTime.Now > enddt)
            {
                MiniteCache exfirst = _MiniteCache.Dequeue();
                ExportTxt(exfirst);

            }
        }
    }
    public Dictionary<string, DeviceCache> _DevicesCache = new Dictionary<string, DeviceCache>();


    public void Insert(string ip, UInt32 timestamps, UInt32 timestampms, UInt16 rate, UInt16 gain, byte[] bufferdata)
    {
        DeviceCache dv = GetDevice(ip);


        DateTime dt = DateTime.Now;

        App_SensorData data = new App_SensorData();
        data.createtime = dt;
        data.device = ip;
        data.gain = (short)gain;
        data.rate = (short)rate;
        data.sensorvalue = bufferdata;
        data.timestampms = (int)timestampms;
        data.timestamps = (int)timestamps;

        dv.AddMiniteCache(data);


    }

    public DeviceCache GetDevice(string ip)
    {
        if (_DevicesCache.ContainsKey(ip))
        {
            return _DevicesCache[ip];
        }
        else
        {
            DeviceCache cache = new DeviceCache();
            cache._IP = ip;
            cache._LastRevTime = DateTime.Now;
            _DevicesCache.Add(ip, cache);
            return cache;
        }
    }


    Task _ExportTask;
    CancellationTokenSource tokenSource;
    public void StartAutoExportTxt()
    {
        tokenSource = new CancellationTokenSource();
        Console.WriteLine("StartAutoExportTxt");

        IQueryable<Terminal> terminals = null;
        _ExportTask = Task.Factory.StartNew(() =>
        {
            while (true)
            {
                var GVContext = Startup.CreateDBContext();

                terminals = GVContext.Terminals.OrderBy(item => item.ip);


                foreach (Terminal terminal in terminals)
                {
                    DeviceCache dv = GetDevice(terminal.ip);
                    dv.ProcessOnce();
                }

                Thread.Sleep(30000);

                if (tokenSource.IsCancellationRequested == true)
                {
                    Console.WriteLine("Task {0} was cancelled before it got started.",
                                      tokenSource);
                    tokenSource.Token.ThrowIfCancellationRequested();
                }
            }
        });

    }
    public void Reset()
    {
        if (_ExportTask != null && tokenSource != null)
        {
            var token = tokenSource.Token;
            tokenSource.Cancel();
            tokenSource = null;
            _ExportTask = null;
        }

        Thread.Sleep(1000);

        StartAutoExportTxt();
    }


}