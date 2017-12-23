using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class TerminalDto
    {
        public Guid Id { get; set; }

        public Guid DepartmentId { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// X
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// Y
        /// </summary>
        public int PositionY { get; set; }


        public string desc { get; set; }


    }
}
