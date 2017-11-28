﻿using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class Package
    {
        public enum ENUMPACKAGETYPE
        {
            EPT_NONE,
            EPT_TERMINAL,
            EPT_JSON,
        }
        public virtual ENUMPACKAGETYPE _PackageType
        {
            get { return ENUMPACKAGETYPE.EPT_NONE; }
        }
    }
    public class TerminalPackage : Package
    {
        public override ENUMPACKAGETYPE _PackageType
        {
            get { return ENUMPACKAGETYPE.EPT_TERMINAL; }
        }

        public IPEndPoint _SendTo;
        public IPEndPoint _ReceiveFrom;
        public byte[] _PackageData;

        public char _Cmd;
        public Int16 _Frame;
        public Int16 _Len;
        public byte[] _Data;

        public byte[] _FullData;

        static PackageParser _Parser = new PackageParser();

        public TerminalPackage(IPEndPoint iepto, IPEndPoint iepfrom, char cmd, short frame, short len, byte[] data = null)
        {
            _SendTo = iepto;
            _ReceiveFrom = iepfrom;

            _PackageData = data;
            _Cmd = cmd;
            _Frame = frame;
            _Len = len;
            _Data = data;

            _FullData = _Parser.Pack(cmd, frame, len, data);
        }
                
        public static TerminalPackage Unpack(IPEndPoint iep, byte[] data)
        {
            return _Parser.Unpack(iep, data);
        }
        
    }
    public class JsonPackage : Package
    {
        public override ENUMPACKAGETYPE _PackageType
        {
            get { return ENUMPACKAGETYPE.EPT_JSON; }
        }


        JsonData _JsonData;

        public JsonPackage(JsonData jd)
        {
            _JsonData = jd;
        }

        public static JsonPackage Unpack(byte[] data)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string jsonstr = encoding.GetString(data);
            return new JsonPackage(JsonMapper.ToObject(jsonstr));
        }

        public string GetString(string key)
        {
            try
            {

                return _JsonData[key].ToString();
            }
            catch(Exception ex)
            {
                Console.Write("JsonPackage Error:" + ex);
                return "";
            }
        }
        public Int16 GetInt16(string key)
        {
            try
            {
                return Convert.ToInt16(_JsonData[key]);
            }
            catch (Exception ex)
            {
                Console.Write("JsonPackage Error:" + ex);
                return 0;
            }
        }
        public Int32 GetInt(string key)
        {
            try
            {
                return Convert.ToInt32(_JsonData[key]);
            }
            catch (Exception ex)
            {
                Console.Write("JsonPackage Error:" + ex);
                return 0;
            }
        }
        public bool GetBool(string key)
        {
            try
            {
                return Convert.ToBoolean(_JsonData[key]);
            }
            catch (Exception ex)
            {
                Console.Write("JsonPackage Error:" + ex);
                return false;
            }
        }
    }


    public class PackageParser
    {
        MemoryStream mStream;
        BinaryWriter mWriter;
        BinaryReader mReader;

        int mSize = 0;

        public int position { get { return (int)mStream.Position; } set { mStream.Seek(value, SeekOrigin.Begin); } }

        public PackageParser()
        {

            mStream = new MemoryStream();
            mWriter = new BinaryWriter(mStream);
            mReader = new BinaryReader(mStream);

        }

        public byte[] Pack(char cmd, short frame, short len, byte[] data = null)
        {
            BinaryWriter writer = BeginWriting();
            writer.Write(cmd);
            writer.Write(frame);
            writer.Write(len);
            if(len > 0 && data != null)
            {
                writer.Write(data);

            }
            int streamlen = EndWriting();

            byte[] buffer = new byte[streamlen];
            Buffer.BlockCopy(mStream.GetBuffer(), 0, buffer, 0, streamlen);
            
            return buffer;
        }

        public TerminalPackage Unpack(IPEndPoint iep, byte[] data)
        {
            BeginWriting();
            mWriter.Write(data);
            EndWriting();

            BinaryReader reader = BeginReading();
            char cmd = (char)reader.ReadByte();
            Int16 frame = (Int16)reader.ReadInt16();
            Int16 len = (Int16)reader.ReadInt16();

            byte[] rdata = null;
            if (len > 0)
            {
                rdata = reader.ReadBytes(len);

            }


            TerminalPackage pkg = new TerminalPackage(null,iep, cmd, frame, len, rdata);


            return pkg;
        }
        

        public BinaryReader BeginReading(int startOffset = 0)
        {
            mStream.Seek(startOffset, SeekOrigin.Begin);
            return mReader;
        }



        public BinaryWriter BeginWriting(int startOffset = 0)
        {
            mStream.Seek(startOffset, SeekOrigin.Begin);
         
            return mWriter;
        }
        
        public int EndWriting()
        {
            mSize = position;
            mStream.Seek(0, SeekOrigin.Begin);
            return mSize;
        }


        /// <summary>
        /// Peek at the first byte at the specified offset.
        /// </summary>

        public int PeekByte(int offset)
        {
            long pos = mStream.Position;
            if (offset + 1 > pos) return -1;
            mStream.Seek(offset, SeekOrigin.Begin);
            int val = mReader.ReadByte();
            mStream.Seek(pos, SeekOrigin.Begin);

            return val;
        }
        /// <summary>
        /// Peek at the first integer at the specified offset.
        /// </summary>
        public int PeekInt(int offset)
        {
            long pos = mStream.Position;
            if (offset + 4 > pos) return -1;
            mStream.Seek(offset, SeekOrigin.Begin);
            int val = mReader.ReadInt32();
            mStream.Seek(pos, SeekOrigin.Begin);

            //val = System.Net.IPAddress.HostToNetworkOrder(val);
            return val;
        }

        public int PeekShort(int offset)
        {
            long pos = mStream.Position;
            if (offset + 1 > pos) return -1;
            mStream.Seek(offset, SeekOrigin.Begin);
            int val = mReader.ReadInt16();
            mStream.Seek(pos, SeekOrigin.Begin);

            val = System.Net.IPAddress.HostToNetworkOrder(val);

            return val;
        }
    }
}
