using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class CommandParser
    {
        PackageParser _PackageParser;

        public CommandParser()
        {
            _PackageParser = new PackageParser();
        }
        

        #region Send Cmd

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
        #endregion

        #region Receive Cmd

        public void ReceiveData(byte[] receiveddata)
        {
            if(receiveddata .Length >= 5)
            {

                MemoryStream stream = new MemoryStream(receiveddata);
                BinaryReader reader = new BinaryReader(stream);
                char cmd = (char)reader.ReadByte();
                Int16 framecount = reader.ReadInt16();
                Int16 datalen = reader.ReadInt16();
                byte[] data = reader.ReadBytes(datalen);

                if (cmd == 'T')
                {
                    ReceiveCheck(datalen, reader);
                }
                else if (cmd == 'S')
                {
                    ReceiveStartStop(datalen, reader);
                }
                else if (cmd == 'C')
                {

                    ReceiveCollection(datalen, reader);
                }
                else if (cmd == 'U')
                {

                    ReceiveMCU(datalen, reader);
                }
                else if (cmd == 'D')
                {
                    ReceiveMCUData(datalen, reader);

                }
                else if (cmd == 'A')
                {

                    ReceiveSensorData(datalen, reader);
                }





            }
            else
            {

                Console.WriteLine("ReceiveData Empty");
            }
        }


        void ReceiveCheck(int len, BinaryReader reader)
        {
            Console.WriteLine("ReceiveCheck OK");

        }
        void ReceiveStartStop(int len, BinaryReader reader)
        {
            if(len == 1)
            {
                char ret = (char)reader.ReadByte();

                if (ret == 't')
                {

                }
                else if (ret == 'p')
                {

                }
                else if (ret == 'e')
                {

                }

            }

        }

        void ReceiveCollection(int len, BinaryReader reader)
        {
            if (len == 1)
            {
                char ret = (char)reader.ReadByte();

                if (ret == 'o')
                {

                }
                else if (ret == 'e')
                {

                }
            }
        }
        void ReceiveMCU(int len, BinaryReader reader)
        {
            if (len == 1)
            {
                char ret = (char)reader.ReadByte();

                if (ret == 'o')
                {

                }
                else if (ret == 'e')
                {

                }


            }
        }
        void ReceiveMCUData(int len, BinaryReader reader)
        {
            if (len == 1)
            {
                char ret = (char)reader.ReadByte();

                if (ret == 'o')
                {

                }
                else if (ret == 'e')
                {

                }


            }
        }

        void ReceiveSensorData(int len, BinaryReader reader)
        {

            int timestamps = reader.ReadInt32();
            int timestampms = reader.ReadInt32();
            Int16 rate = reader.ReadInt16();
            Int16 gain = reader.ReadInt16();
            
            for(int i = 0;i < len - 12;i += 2)//每次处理4个字节
            {
                Int16 advalue = reader.ReadInt16();
            }



        }
        #endregion


        byte[] SendCmdBase(char cmd,Int16 framecount,byte[] data = null)
        {
            return _PackageParser.Pack(cmd, framecount, data.Length, data);
        }

        void ReceiveCmdBase(BinaryReader reader)
        {


        }
    }
}
