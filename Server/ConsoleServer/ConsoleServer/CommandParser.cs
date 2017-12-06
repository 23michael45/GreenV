using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using LitJson;
using System.Net;

namespace ConsoleServer
{
    public class CommandParser
    {
        PackageParser _PackageParser;


        static MySqlConnector _MySqlConnector = new MySqlConnector();


        public CommandParser()
        {
            _PackageParser = new PackageParser();
           // _MySqlConnector.Connect();
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
                    IPEndPoint iep = Program.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    Program.SendToTerminal(SendCheck(iep));

                    Program.SendToWeb(SendCmdJson("checkrsp", pkg.GetString("ip"), "ok"));
                }
                else if (cmd == "reset")
                {
                    IPEndPoint iep = Program.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    Program.SendToTerminal(SendReset(iep));

                    Program.SendToWeb(SendCmdJson("resetrsp", pkg.GetString("ip"), "ok"));
                }
                else if (cmd == "startstop")
                {

                    IPEndPoint iep = Program.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    Program.SendToTerminal(SendStartStop(iep, pkg.GetBool("isstart")));

                }
                else if (cmd == "collection")
                {
                    IPEndPoint iep = Program.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    Program.SendToTerminal(SendCollect(iep, pkg.GetInt16("n"),pkg.GetInt16("m")));

                }
                else if (cmd == "mcu")
                {
                    IPEndPoint iep = Program.GetTerminalIPEndPoint(pkg.GetString("ip"));
                    Program.SendToTerminal(SendMCU(iep, pkg.GetString("binpath")));

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

                ReceiveGroundTruth(pkg);
            }
            else if (pkg._Cmd == 'Y')
            {

                ReceiveSyncRsp(pkg);
            }


            else
            {

                Console.WriteLine("ReceiveData Empty");
            }

        }

        public void ReceiveData(Package pkg)
        {
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

        #endregion




        #region Receive Cmd FromTerminal


        void ReceiveCheck(int len, BinaryReader reader,string ip)
        {
            Console.WriteLine("ReceiveCheck OK");

            Program.SendToWeb(SendCmdJson("check", ip, "ok"));

            
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

                    Program.SendToWeb(SendCmdJson("startstop", ip, "startok"));
                }
                else if (ret == 'p')
                {

                    Console.WriteLine("ReceiveStop OK");
                    Program.SendToWeb(SendCmdJson("startstop", ip, "stopok"));
                }
                else if (ret == 'e')
                {

                    Console.WriteLine("ReceiveStartStop Error");
                    Program.SendToWeb(SendCmdJson("startstop", ip, "error"));
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
                    Program.SendToWeb(SendCmdJson("collection", ip, "ok"));
                }
                else if (ret == 'e')
                {

                    Console.WriteLine("ReceiveCollection Error");
                    Program.SendToWeb(SendCmdJson("collection", ip, "error"));
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
                    Program.SendToWeb(SendCmdJson("mcu", ip, "ok"));

                    _CurrentMCUFrame = 0;
                    
                    Program.SendToTerminal(SendMCUData(Program.GetTerminalIPEndPoint(ip)));

                }
                else if (ret == 'e')
                {
                    Console.WriteLine("ReceiveMCU Error");
                    Program.SendToWeb(SendCmdJson("mcu", ip, "error"));

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

                    Program.SendToTerminal(SendMCUData(Program.GetTerminalIPEndPoint(ip)));

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

            int timestamps = reader.ReadInt32();
            int timestampms = reader.ReadInt32();
            Int16 rate = reader.ReadInt16();
            Int16 gain = reader.ReadInt16();
            
            for(int i = 0;i < len - 12;i += 2)//每次处理2个字节   len - 12 = 1200
            {
                Int16 advalue = reader.ReadInt16();


                if(_MySqlConnector != null)
                {
                    _MySqlConnector.InsertSensor(ip, timestampms, advalue);

                }
            }


            Console.WriteLine("ReceiveSensorData " + (len - 12 ) / 2);

            Program.SendToTerminal(SendSensorDataRsp(Program.GetTerminalIPEndPoint(ip)));

        }


        void ReceiveMessage(int len, BinaryReader reader, string ip)
        {

            Console.WriteLine("ReceiveMessage OK");
            Program.SendToTerminal(SendMessageRsp(Program.GetTerminalIPEndPoint(ip)),false);

        }

        void ReceiveGroundTruth(StringPackage pkg)
        {
            string s = pkg._StringContent;
            int start = s.IndexOf('>');
            int end = s.IndexOf('=');
            string time = s.Substring(start + 1, end - start - 1);
            string lr = s.Substring(end + 1, 1);

            string[] timeparam = time.Split(':');
            if(timeparam.Length == 4)
            {
                int hour = Convert.ToInt32(timeparam[0]);
                int min = Convert.ToInt32(timeparam[1]);
                int sec = Convert.ToInt32(timeparam[2]);
                int ms = Convert.ToInt32(timeparam[3]);
            }
            if (_MySqlConnector != null)
            {
                _MySqlConnector.InsertGroundTruth(pkg._ReceiveFrom.Address.ToString(), time, lr);

            }
        }
        void ReceiveSyncRsp(StringPackage pkg)
        {
            if (pkg._StringContent == "Y>o")
            {

                Console.WriteLine("ReceiveSyncRsp OK");
                Program.SendToWeb(SendCmdJson("syncrsp", pkg._ReceiveFrom.Address.ToString(), "ok"));
            }
            else if (pkg._StringContent == "Y>e")
            {

                Console.WriteLine("ReceiveSyncRsp Failed");
                Program.SendToWeb(SendCmdJson("syncrsp", pkg._ReceiveFrom.Address.ToString(), "failed"));
            }
        }

        


        #endregion


    }
}
