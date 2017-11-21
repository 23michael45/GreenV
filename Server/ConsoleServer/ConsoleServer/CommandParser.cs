using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class CommandParser
    {
        PackageParser _PackageParser;

        public CommandParser()
        {
            _PackageParser = new PackageParser();
        }
        

        #region Send Cmd

        public byte[] SendTerminalCheck()
        {
            return SendTerminalCmdBase('t', 0);
        }
        public byte[] SendTerminalStart()
        {
            return _PackageParser.Pack('s', 0, 't');
        }
        public byte[] SendTerminalStop()
        {
            return _PackageParser.Pack('s', 0, 'p');
        }

        public byte[] SendTerminalCollect()
        {
            return _PackageParser.Pack('c', 0, 'p');
        }


        #endregion

        #region Receive Cmd


        #endregion


        byte[] SendTerminalCmdBase(char cmd,Int16 framecount,byte[] data = null)
        {

            return _PackageParser.Pack(cmd, framecount, data.Length, data);
        }
    }
}
