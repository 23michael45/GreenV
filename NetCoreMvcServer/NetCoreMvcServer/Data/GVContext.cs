using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NetCoreMvcServer.Models
{
    public class GVContext : DbContext
    {
        public GVContext(DbContextOptions<GVContext> options)
            : base(options)
        {
        }

        public DbSet<NetCoreMvcServer.Models.App_SensorData> App_SensorData { get; set; }
        public DbSet<NetCoreMvcServer.Models.App_GroundTruthData> App_GroundTruthData { get; set; }
    }
}
