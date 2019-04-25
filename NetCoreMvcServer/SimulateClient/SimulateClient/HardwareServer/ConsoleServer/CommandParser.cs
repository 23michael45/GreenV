using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using LitJson;
using System.Net;

using System.Threading;

using ConsoleServer;
using SimulateClient;

namespace ConsoleServer
{
    public class CommandParser
    {
        PackageParser _PackageParser;


        public static string _ExportPath = "C:/Export";
        
        public CommandParser()
        {

            _PackageParser = new PackageParser();
            


        }

        public bool  ConnectMySql()
        {
            try
            {


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
                    
                }
                else if (cmd == "reset")
                {
                    IPEndPoint iep = MainEntry.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    MainEntry.SendToTerminal(SendReset(iep));
                    
                }
                else if (cmd == "startstop")
                {

                    IPEndPoint iep = MainEntry.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    MainEntry.SendToTerminal(SendStartStop(iep, pkg.GetBool("isstart")));

                }
                else if (cmd == "collection")
                {
                    IPEndPoint iep = MainEntry.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    MainEntry.SendToTerminal(SendCollect(iep, pkg.GetInt16("n"),pkg.GetInt16("m")));

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

                //QueueNeedRsp.Instance.RemovePackage(cmd);


                if (cmd == 't')
                {
                    ReceiveCheck(datalen, reader, ip);
                }
                else if (cmd == 's')
                {
                    ReceiveStartStop(datalen, reader, ip);
                }
                //if (cmd == 'T')
                //{
                //    ReceiveCheck(datalen, reader, ip);
                //}
                //else if (cmd == 'S')
                //{
                //    ReceiveStartStop(datalen, reader, ip);
                //}
                //else if (cmd == 'C')
                //{

                //    ReceiveCollection(datalen, reader, ip);
                //}
                //else if (cmd == 'U')
                //{

                //    ReceiveMCU(datalen, reader, ip);
                //}
                //else if (cmd == 'D')
                //{
                //    ReceiveMCUData(datalen, reader, ip);

                //}
                //else if (cmd == 'a')
                //{

                //    ReceiveSensorData(datalen, reader, ip);
                //}
                //else if (cmd == 'm')
                //{

                //    ReceiveMessage(datalen, reader, ip);
                //}
                //if (pkg._Cmd == 'g')
                //{
                //    ReceiveGroundTruth(datalen, reader, ip);
                //}
            }
            else
            {

                Console.WriteLine("ReceiveData Empty");
            }

        }
        void ParseByteFromString(StringPackage pkg)
        {
            
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


        #region Send Cmd To Server


        public TerminalPackage SendSensorData(IPEndPoint iep)
        {
            //return SendCmdBase(iep,'t', 0);

            MemoryStream ms = new MemoryStream();
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                long stamp = 999;
                bw.Write(stamp);

                short rate = 11;
                bw.Write(rate);
                short gain = 22;
                bw.Write(gain);

                for(int i = 0; i< 1200;i++)
                {
                    byte b = (byte)i;
                    bw.Write(b);
                }

                byte[] buf = ms.GetBuffer();
                return SendCmdBase(iep, 'a', 0,buf);
            }


        }
        public TerminalPackage SendGroundTruthData(IPEndPoint iep)
        {
            //return SendCmdBase(iep,'t', 0);

            MemoryStream ms = new MemoryStream();
            using (BinaryWriter bw = new BinaryWriter(ms))
            {

                byte nodeindex = 11;
                bw.Write(nodeindex);
                byte lr = 22;
                bw.Write(lr);


                int stamp = 999;
                bw.Write(stamp);


                int stampms = 888;
                bw.Write(stampms);


                byte[] buf = ms.GetBuffer();
                return SendCmdBase(iep, 'g', 0, buf);
            }

        }

        public TerminalPackage SendCheck(IPEndPoint iep)
        {
            //return SendCmdBase(iep,'t', 0);
            return SendCmdBase(iep, 'T', 0);
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

                Program.StartSendData();
            }
            else
            {
                writer.Write('p');

                Program.StopSendData();

            }
            stream.Seek(0, SeekOrigin.Begin);


            byte[] buffer = new byte[stream.Length];
            Buffer.BlockCopy(stream.GetBuffer(), 0, buffer, 0, (int)stream.Length);



            return SendCmdBase(iep,'S', 0, buffer);
        }




        public TerminalPackage SendCollect(IPEndPoint iep, Int16 n, Int16 m)
        {
            
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(n);
            writer.Write(m);
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

            var pkg = SendCheck(MainEntry.GetTerminalIPEndPoint(ip));
            Console.WriteLine("ReceiveCheck OK Pkg");
            MainEntry.SendToTerminal(pkg, false);

            Console.WriteLine("ReceiveCheck OK Finish");
        }

        void ReceiveStartStop(int len, BinaryReader reader, string ip)
        {
            Console.WriteLine("ReceiveStartStop Start");
            if (len == 1)
            {
                byte bytedata = reader.ReadByte();

                char ret = (char)bytedata;
     
                if (ret == 't')
                {

                    Console.WriteLine("ReceiveStart t start OK");

                    Program.StartSendData();
                    //MainEntry.SendCBParse("SendST", ip);
                }
                else if (ret == 'p')
                {

                    Console.WriteLine("ReceiveStop p stop OK");
                    Program.StopSendData();
                    //MainEntry.SendCBParse("SendSP", ip);
                }
                else if (ret == 'e')
                {
                    Console.WriteLine("ReceiveStartStop Error");
                    //MainEntry.SendCBParse("SendST", "error");
                    //MainEntry.SendCBParse("SendSP", "error");
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



            byte[] bufferdata = reader.ReadBytes(len - 12);
            //if (_MySqlConnector != null)
            //{
            //    _MySqlConnector.InsertSensor(ip, timestamps, timestampms,rate,gain,bufferdata);

            //}

            //测试用
            //ip = string.Format("192.168.{0}.{1}", rate, gain); 
            
            Console.WriteLine("ReceiveSensorData " + (len - 12 ) / 2);

        }


        void ReceiveMessage(int len, BinaryReader reader, string ip)
        {

            Console.WriteLine("ReceiveMessage OK");
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








