﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NetCoreMvcServer.Models
{
    public class Role : Entity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Remarks { get; set; }
        
    }
}
