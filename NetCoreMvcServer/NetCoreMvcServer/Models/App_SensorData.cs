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
        public Int32 timestamps { get; set; }
        [Column(Order = 3)]
        public Int32 timestampms { get; set; }
        [Column(Order = 4)]
        public Int16 rate { get; set; }
        [Column(Order = 5)]
        public Int16 gain { get; set; }
        [Column(Order = 6)]
        public DateTime createtime { get; set; }

        [Column(Order = 7)]
        public byte[] sendsorvalue { get; set; }
    }
}
