﻿using System;
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

        protected int _TerminalPort = 5000;
        protected int _WebPort = 6000;

        protected UdpBase()
        {
            Client = new UdpClient();
        }

        public async Task<Package> Receive()
        {
            var result = await Client.ReceiveAsync();
            return new Package()
            {
                //_Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
                _Sender = result.RemoteEndPoint,
                _PackageData = result.Buffer
            };
        }
    }

    //Server
    class UdpListener : UdpBase
    {
        private IPEndPoint _listenOn;
        
        public UdpListener()
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, _TerminalPort);
            _listenOn = endpoint;
            Client = new UdpClient(_listenOn);
        }

      
        public  void SendToWeb(byte[] datagram)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), _WebPort);
            Client.Send(datagram, datagram.Length, iep);
        }
        public void SendToTerminal(byte[] datagram, string ip )
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), _TerminalPort);
            Client.Send(datagram, datagram.Length, iep);
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
