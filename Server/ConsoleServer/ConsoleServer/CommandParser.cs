using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using LitJson;

namespace ConsoleServer
{
    public class CommandParser
    {
        PackageParser _PackageParser;


        static MySqlConnector _MySqlConnector = new MySqlConnector();


        public CommandParser()
        {
            _PackageParser = new PackageParser();
            _MySqlConnector.Connect();
        }



        #region Send Cmd Trunk


        byte[] SendCmdBase(char cmd, Int16 framecount, byte[] data = null)
        {
            int len = 0;
            if (data != null)
            {
                len = data.Length;
            }
            return _PackageParser.Pack(cmd, framecount, len, data);
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

        void ParseJsonFromWeb(byte[] receiveddata)
        {
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();


                string jsonstr = encoding.GetString(receiveddata);

                JsonData outputdata = JsonMapper.ToObject(jsonstr);

                string cmd = outputdata["cmd"].ToString();

                if (cmd == "check")
                {
                    string ip = outputdata["ip"].ToString();
                    Program.SendToTerminal(SendCheck(), ip);

                    Program.SendToWeb(SendCmdJson("checkrsp", ip, "ok"));
                }
                else if (cmd == "startstop")
                {
                    string ip = outputdata["ip"].ToString();
                    bool b = Convert.ToBoolean(outputdata["isstart"].ToString());
                    Program.SendToTerminal(SendStartStop(b), ip);

                }
                else if (cmd == "collection")
                {
                    string ip = outputdata["ip"].ToString();
                    short n = Convert.ToInt16(outputdata["n"].ToString());
                    short m = Convert.ToInt16(outputdata["m"].ToString());
                    Program.SendToTerminal(SendCollect(n,m), ip);

                }
                else if (cmd == "mcu")
                {
                    string ip = outputdata["ip"].ToString();
                    int x = Convert.ToInt32(outputdata["x"].ToString());
                    Program.SendToTerminal(SendMCU(x), ip);

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        void ParseByteFormTerminal(byte[] receiveddata,string ip)
        {
            if (receiveddata.Length >= 5)
            {

                MemoryStream stream = new MemoryStream(receiveddata);
                BinaryReader reader = new BinaryReader(stream);
                char cmd = (char)reader.ReadByte();
                Int16 framecount = reader.ReadInt16();
                Int16 datalen = reader.ReadInt16();
                byte[] data = reader.ReadBytes(datalen);

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
            }
            else
            {

                Console.WriteLine("ReceiveData Empty");
            }

        }

        public void ReceiveData(Package pkg)
        {
            byte[] receiveddata = pkg._PackageData;
            string ip = pkg._Sender.Address.ToString();

            if (ip == "127.0.0.1")
            {
                try
                {

                    ParseJsonFromWeb(receiveddata);
                }
                catch(Exception ex)
                {

                    ParseByteFormTerminal(receiveddata, ip);
                }

            }
            else
            {
                ParseByteFormTerminal(receiveddata,ip);

            }



        }

        #endregion


        #region Send Cmd To Terminal

        public byte[] SendCheck()
        {
            return SendCmdBase('t', 0);
        }

        public byte[] SendStartStop(bool bstart)
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
            return SendCmdBase('s', 0, stream.GetBuffer());
        }

        public byte[] SendCollect(Int16 n, Int16 m)
        {
            
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(n);
            writer.Write(m);
            stream.Seek(0, SeekOrigin.Begin);

            byte[] data = stream.GetBuffer();

            return SendCmdBase('c', 0, data);
        }

        public byte[] SendMCU(int x)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(x);
            stream.Seek(0, SeekOrigin.Begin);

            byte[] data = stream.GetBuffer();

            return SendCmdBase('u', 0, data);
        }

        public byte[] SendMCUData(byte[] filedata)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(filedata.Length);
            writer.Write(filedata);
            stream.Seek(0, SeekOrigin.Begin);

            byte[] data = stream.GetBuffer();

            return SendCmdBase('u', 0, data);
        }

        public byte[] SendSensorDataRsp()
        {
            return SendCmdBase('A', 0);
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
                char ret = (char)reader.ReadByte();

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

                    Console.WriteLine("ReceiveMCUData OK");
                }
                else if (ret == 'e')
                {

                    Console.WriteLine("ReceiveMCUData Error");
                }


            }
        }

        void ReceiveSensorData(int len, BinaryReader reader,string ip )
        {

            int timestamps = reader.ReadInt32();
            int timestampms = reader.ReadInt32();
            Int16 rate = reader.ReadInt16();
            Int16 gain = reader.ReadInt16();
            
            for(int i = 0;i < len - 12;i += 2)//每次处理4个字节
            {
                Int16 advalue = reader.ReadInt16();


                if(_MySqlConnector != null)
                {
                    _MySqlConnector.Insert(ip, timestampms, advalue);

                }
            }


            Console.WriteLine("ReceiveSensorData " + (len - 12 ) / 2);

            Program.SendToTerminal(SendSensorDataRsp(), ip);

        }
        #endregion


    }
}
