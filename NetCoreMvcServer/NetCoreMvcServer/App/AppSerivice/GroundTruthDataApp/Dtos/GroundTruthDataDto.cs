using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class App_GroundTruthDataDto
    {
        public int Id { get; set; }
        public string device { get; set; }
        public Int32 timestamp { get; set; }
        public DateTime createtime { get; set; }
        public int leftright { get; set; }

    }
}
