﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    class Program
    {

        static bool _bQuit = false;
        static CommandParser _CmdParser = new CommandParser();
        static UdpListener _Server;
        static UdpUser _Client;

        static void Main(string[] args)
        {
           
            if(args[0] == "simulateclient")
            {
                StartUdpClient();
            }


            StartUdpServer();

            while(!_bQuit)
            {

                string s = Console.ReadLine();

                string cmd = ParseConsoleLine(s, 0);
                string ip = ParseConsoleLine(s, 1);

                if (cmd == "quit")
                {
                    _bQuit = true;
                }
                else if (cmd =="t")
                {
                    _Server.SendToTerminal(_CmdParser.SendCheck(),ip);
                }
                else if (cmd == "s")
                {
                    if(s.EndsWith("t"))
                    {
                        _Server.SendToTerminal(_CmdParser.SendStartStop(true),ip);
                    }
                    else if (s.EndsWith("p"))
                    {

                        _Server.SendToTerminal(_CmdParser.SendStartStop(false), ip);
                    }
                }
                else if (cmd == "c")
                {

                    short n = Convert.ToInt16(ParseConsoleLine(s, 2));
                    short m = Convert.ToInt16(ParseConsoleLine(s, 3));

                    _Server.SendToTerminal(_CmdParser.SendCollect(n, m), ip);
                }
                else if (cmd == "u")
                {
                    string path = ParseConsoleLine(s, 2);
                    FileStream fs = File.Open(path, FileMode.Open);
                    long len = fs.Length;
                    _Server.SendToTerminal(_CmdParser.SendMCU((int)len), ip);

                }
                else if (cmd == "d")
                {
                    string path = ParseConsoleLine(s, 2); FileStream fs = File.Open(path, FileMode.Open);

                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Seek(0, SeekOrigin.Begin);
                    _Server.SendToTerminal(_CmdParser.SendMCUData(bytes), ip);

                }


            }
           
        }

        static string ParseConsoleLine(string s,int index)
        {
            string[] arr = s.Split(' ');

            if(arr.Length > index)
            {
                return arr[index];
            }

            return "";
        }




        static void StartUdpServer()
        {
            //create a new server
            _Server = new UdpListener();

            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var received = await _Server.Receive();
                    _CmdParser.ReceiveData(received._PackageData);
                }
            });

        }
        static void StartUdpClient()
        {
            //create a new client
            _Client = UdpUser.ConnectTo("127.0.0.1", 16000);

            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var received = await _Client.Receive();
                      


                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                }
            });


            Task.Factory.StartNew(async () =>
            {
                //type ahead :-)
                string read;
                do
                {
                    read = Console.ReadLine();
                    if(read == "sim")
                    {
                        _Client.Send(DebugPackageData());
                    }

                } while (read != "quit");

                _bQuit = true;
            });

           
        }


        static byte[] DebugPackageData()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter w = new BinaryWriter(ms);

            char cmd = 'T';
            Int16 frame = 0;
            Int16 len = 0;

            ms.Seek(0, SeekOrigin.Begin);
            w.Write(cmd);
            w.Write(frame);
            w.Write(len);


            ms.Seek(0, SeekOrigin.Begin);

            byte[] buffer = ms.GetBuffer();
            return buffer;
        }
    }
}
