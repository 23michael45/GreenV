using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class App_GroundTruthData
    {
        [Column("id", Order = 0)]
        public int id { get; set; }
        [Column(Order = 1)]
        public string device { get; set; }
        [Column(Order = 2)]
        public long timestamp { get; set; }
        [Column(Order = 3)]
        public int leftright { get; set; }
        
    }
}
