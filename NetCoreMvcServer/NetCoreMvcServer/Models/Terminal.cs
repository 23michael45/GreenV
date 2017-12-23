using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class Terminal : Entity
    {
        [Column(Order = 1)]
        public Guid DepartmentId { get; set; }
        [Column(Order = 2)]
        public string ip { get; set; }
        [Column(Order = 3)]
        public int PositionX { get; set; }
        [Column(Order = 4)]
        public int Positiony { get; set; }
        [Column(Order = 5)]
        public string desc { get; set; }

    }
}
