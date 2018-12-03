using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsoleServer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NetCoreMvcServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileStream fs = new FileStream("exportpath.txt", FileMode.Open);
            var file = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8, true, 128);
            string epath = file.ReadLine();
            fs.Close();
            CommandParser._ExportPath = epath;


            BuildWebHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>

            //Publish的时候 一定要copy exportpath.txt文件和Views文件夹到Publish的地方，否则会报错
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(true)
                .UseContentRoot("c:/wwwroot/Publish")
                .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
                .UseStartup<Startup>()
                .Build();


    }
}
