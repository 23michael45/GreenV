﻿using ConsoleServer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulateClient
{
    class Program
    {
        static UdpListener _ListenClient;
        static UdpUser _Client;


        static CommandParser _CmdParser;

        static string _ServerIP = "192.168.1.8";
        static int _SendToServerPort = 5000;

        static void Main(string[] args)
        {

            StartUdpClient();



            Console.Read();

        }



        static void StartUdpClient()
        {
            _CmdParser = new CommandParser();
            //create a new client
            _Client = UdpUser.ConnectTo(_ServerIP, _SendToServerPort);
            _ListenClient = new UdpListener();
            MainEntry._Server = _ListenClient;
            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        Package package = await _ListenClient.Receive();


                        _CmdParser.ReceiveData(package);


                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                }
            });

            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {

                        IPEndPoint iep = new IPEndPoint(IPAddress.Parse(_ServerIP), _SendToServerPort);


                        var package = _CmdParser.SendMessage(iep);
                        _Client.Send(package._FullData);



                        Console.Write("\nSend M");

                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                    Thread.Sleep(5000);
                }
            });
        }


        public static ushort mGain = 0;
        public static ushort mRate = 0;
        static bool mSending = false;
        public static void StartSendData()
        {
            mSending = true;
            Task.Factory.StartNew(async () =>
            {
                while (mSending)
                {
                    try
                    {

                        IPEndPoint iep = new IPEndPoint(IPAddress.Parse(_ServerIP), _SendToServerPort);


                        var package = _CmdParser.SendSensorData(iep);
                        _Client.Send(package._FullData);


                        package = _CmdParser.SendGroundTruthData(iep);
                        _Client.Send(package._FullData);


                        Console.Write("\nSend T");

                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                    Thread.Sleep(2000);
                }
            });
        }
        public static void StopSendData()
        {

            mSending = false;
        }
    }
}
