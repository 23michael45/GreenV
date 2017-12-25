using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class GroundTruthDto
    {
        public Guid Id { get; set; }

        public Guid DepartmentId { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string ip { get; set; }
        
        public string desc { get; set; }


    }
}
