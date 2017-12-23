using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class App_SensorData : Entity
    {
        [Column(Order = 1)]
        public string device { get; set; }
        [Column(Order = 2)]
        public long timestamps { get; set; }
        [Column(Order = 3)]
        public long timestampms { get; set; }

        [Column(Order = 4)]
        public byte[] sendsorvalue { get; set; }
    }
}
