using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    class Program
    {

        static bool _bQuit = false;

        static void Main(string[] args)
        {
           
            if(args[0] == "simulateclient")
            {
                StartUdpClient();
            }


            StartUdpServer();

            while(!_bQuit)
            {

            }
           
        }




        static void StartUdpServer()
        {
            //create a new server
            var server = new UdpListener();

            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var received = await server.Receive();
                    server.Reply("copy " + received.Message, received.Sender);
                    if (received.Message == "quit")
                        break;
                }
            });

        }
        static void StartUdpClient()
        {
            //create a new client
            var client = UdpUser.ConnectTo("127.0.0.1", 32123);

            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var received = await client.Receive();
                        Console.WriteLine(received.Message);
                        if (received.Message.Contains("quit"))
                            break;
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
                    client.Send(read);
                } while (read != "quit");

                _bQuit = true;
            });

           
        }
    }
}
