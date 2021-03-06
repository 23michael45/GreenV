﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class App_GroundTruthData : EntityInt
    {

        [Column(Order = 1)]
        public string device { get; set; }
        [Column(Order = 2)]
        public int timestamp { get; set; }
        [Column(Order = 3)]
        public byte leftright { get; set; }
        [Column(Order = 4)]
        public DateTime createtime { get; set; }
        [Column(Order = 5)]
        public int timestampms { get; set; }
        [Column(Order = 6)]
        public byte nodeindex { get; set; }

    }
}
