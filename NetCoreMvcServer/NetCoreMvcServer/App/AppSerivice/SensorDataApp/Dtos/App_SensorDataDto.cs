using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public class App_SensorDataDto
    {
        public int Id { get; set; }
        public string device { get; set; }
        public Int32 timestamps { get; set; }
        public Int32 timestampms { get; set; }
        public Int16 rate { get; set; }
        public Int16 gain { get; set; }
        public List<Int16> sensorvalue { get; set; }


    }
}
