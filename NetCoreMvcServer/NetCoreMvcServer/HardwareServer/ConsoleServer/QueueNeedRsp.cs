using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class QueueNeedRsp 
    {
        public class PackageTimerData
        {
            public Package _Package;
            public Timer _Timer;
            public int _Count = 0;
        }


        private static QueueNeedRsp instance;

        private QueueNeedRsp() { }

        public static QueueNeedRsp Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QueueNeedRsp();
                }
                return instance;
            }
        }



        int _Timeout = 3000;
        int _MaxRetry = 3;
        Dictionary<char, PackageTimerData> _WaitingRspDic = new Dictionary<char, PackageTimerData>();

        public void AddPackage(Package pkg)
        {
            char cmd = pkg._Cmd;


            //全变成小写
            cmd = Char.ToLower(cmd);

            if (_WaitingRspDic.ContainsKey(cmd))
            {
                Console.WriteLine("QueueNeedRsp Key Exsit:" + cmd);
            }
            else
            {
                PackageTimerData ptdata = new PackageTimerData();
                 ptdata._Package = pkg;

                _WaitingRspDic.Add(cmd, ptdata);

                StartTimer(ptdata);
            }
        }
        public void RemovePackage(char cmd)
        {
            //全变成小写
            cmd = Char.ToLower(cmd);

            if (_WaitingRspDic.ContainsKey(cmd))
            {
                PackageTimerData ptdata = _WaitingRspDic[cmd];

                ptdata._Timer.Dispose();


                Console.WriteLine(string.Format("QueueNeedRsp RemoveKey: {0} count: {1}" , cmd,ptdata._Count));
                _WaitingRspDic.Remove(cmd);

            }
            else
            {
                Console.WriteLine("QueueNeedRsp Key Not Exsit:" + cmd);
            }
        }


        void StartTimer(PackageTimerData data)
        {
            var stateTimer = new Timer( HandleTimer,
                                       data, _Timeout, Timeout.Infinite);

            data._Timer = stateTimer;


        }

        private void HandleTimer(object data)
        {
            PackageTimerData ptdata = data as PackageTimerData;
            ptdata._Count++;

            if(ptdata._Count > _MaxRetry && _WaitingRspDic.ContainsKey(ptdata._Package._Cmd))
            {
                RemovePackage(ptdata._Package._Cmd);

                Console.WriteLine(string.Format("QueueNeedRsp Retry Failed: {0} IP: {1}", ptdata._Package._Cmd, ptdata._Package._SendTo.Address));
            }
            else
            {

                Console.WriteLine(string.Format("QueueNeedRsp Retry Cmd: {0} count: {1}", ptdata._Package._Cmd, ptdata._Count));

                MainEntry.SendToTerminal(ptdata._Package, false);


                var stateTimer = new Timer(HandleTimer,
                                           data, _Timeout, Timeout.Infinite);
                ptdata._Timer = stateTimer;
            }

        }
    }

    
}
