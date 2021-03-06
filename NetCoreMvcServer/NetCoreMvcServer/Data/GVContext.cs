﻿using System;
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


        public DbSet<Department> Departments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<GroundTruth> GroundTruths { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //UserRole关联配置
            builder.Entity<UserRole>()
              .HasKey(ur => new { ur.UserId, ur.RoleId });
            

            //启用Guid主键类型扩展
            //builder.HasPostgresExtension("uuid-ossp");

            base.OnModelCreating(builder);
        }
    }
}
