using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulateClient
{
    class Program
    {
        static UdpUser client;
        static Dictionary<int, byte[]> dic = new Dictionary<int, byte[]>();

        static void Main(string[] args)
        {

            string ip = args[0];
            int port = Convert.ToInt32(args[1]);

            client = UdpUser.ConnectTo(ip,port);

            bool quit = false;

            for (int i = 0; i < 33; i++)
            {
                dic[i] = Pack(31, (Int16)i);

            }
            while (!quit)
            {
                SendOnce();
                Thread.Sleep(30);
            }

          

        }
        static void SendOnce()
        {
            for (int i = 0; i < 33; i++)
            {
                client.Send(dic[i]);
                Console.Write("Send IP:" + i);
            }
        }

        static byte[] Pack(Int16 r, Int16 g)
        {

            MemoryStream mStream = new MemoryStream();
            BinaryWriter mWriter = new BinaryWriter(mStream);



            char cmd = 'a';
            mWriter.Write(cmd);
            Int16 frame = 1;
            mWriter.Write(frame);

            Int16 len = 1212;
            mWriter.Write(len);

            Int32 timestamps = Int32.MaxValue;
            mWriter.Write(timestamps);

            Int32 timestampms = Int32.MaxValue;
            mWriter.Write(timestampms);


            Int16 rate = r;
            mWriter.Write(rate);
            Int16 gain = g;
            mWriter.Write(gain);


            byte[] data = new byte[1200];
            for(int i = 0; i < 1200;i++)
            {
                data[i] = 0xff;
            }
            mWriter.Write(data);

            mStream.Seek(0, SeekOrigin.Begin);
            return mStream.ToArray();
        }


        abstract class UdpBase
        {
            protected UdpClient Client;


            protected UdpBase()
            {
                Client = new UdpClient();
            }
            
        }

        //Client
        class UdpUser : UdpBase
        {
            private UdpUser() { }

            public static UdpUser ConnectTo(string hostname, int port)
            {
                var connection = new UdpUser();
                connection.Client.Connect(hostname, port);
                return connection;
            }

            public void Send(string message)
            {
                var datagram = Encoding.ASCII.GetBytes(message);
                Send(datagram);
            }
            public void Send(byte[] datagram)
            {
                Client.Send(datagram, datagram.Length);
            
            }
        }
    }
}
