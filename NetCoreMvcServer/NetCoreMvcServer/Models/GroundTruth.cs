using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class GroundTruth : Entity
    {
        [Column(Order = 1)]
        public string department { get; set; }
        [Column(Order = 2)]
        public string ip { get; set; }
        [Column(Order = 3)]
        public string desc { get; set; }
    }
}
