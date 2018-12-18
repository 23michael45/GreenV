using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{


    abstract class UdpBase
    {
        protected UdpClient Client;


        protected UdpBase()
        {
            Client = new UdpClient();
        }

        public async Task<Package> Receive()
        {
            var result = await Client.ReceiveAsync();

            Package package = null;

            if (result.RemoteEndPoint.Address.ToString() == "127.0.0.1")
            {
                MainEntry._Logger.Debug("Receive JsonPackage");
                package = JsonPackage.Unpack(result.Buffer);

            }
            else
            {
                MainEntry._Logger.Debug("Receive TerminalPackage");

                package = Package.Unpack(result.RemoteEndPoint, result.Buffer);

            }

            Console.WriteLine(string.Format("Socket ReceiveData Package Type {0}", package._PackageType));
            return package;
        }
    }

    //Server
    class UdpListener : UdpBase
    {
        private IPEndPoint _listenOn;

        UdpClient _SendClient;
        public UdpListener()
        {
            IPEndPoint endpoint = MainEntry.GetTerminalIPEndPoint(IPAddress.Any);
            _listenOn = endpoint;
            Client = new UdpClient(_listenOn);
            _SendClient = new UdpClient();
        }

      
        public  void SendToWeb(byte[] datagram)
        {
            IPEndPoint iep = MainEntry.GetWebIPEndPoint();

            _SendClient.Send(datagram, datagram.Length, iep);

            Console.WriteLine(string.Format("Send To SendToWeb Data Length: {0}", datagram.Length));

        }
        public void SendToTerminal(Package pkg)
        {
            try
            {
                
                _SendClient.Send(pkg._FullData, pkg._FullData.Length, pkg._SendTo);
             

                Console.WriteLine(string.Format("Send To Terminal: {0} Data Length: {1}", pkg._SendTo.Address.ToString(), pkg._FullData.Length));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
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
