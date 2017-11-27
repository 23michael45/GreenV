using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public struct Package
    {
        public IPEndPoint _Sender;
        public byte[] _PackageData;

        public char _Cmd;
        public Int16 _Frame;
        public Int16 _Len;
        public byte[] _Data;

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

        public byte[] Pack(char cmd, int frame, int len, byte[] data = null)
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
        public Package Unpack(byte[] data)
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


            Package pkg = new Package()
            {
                _PackageData = data,

                _Cmd = cmd,
                _Frame = frame,
                _Len = len,
                _Data = rdata
            };

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
