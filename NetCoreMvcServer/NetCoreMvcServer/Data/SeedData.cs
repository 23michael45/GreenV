using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Models
{
    public static class SeedData
    {
        public static void Initialize(GVContext context)
        {
            if (context.Users.Any())
            {
                return;   // 已经初始化过数据，直接返回
            }
            Guid departmentId1 = Guid.NewGuid();
            Guid departmentId2 = Guid.NewGuid();
            Guid departmentId3 = Guid.NewGuid();
            //增加一个部门
            context.Departments.AddRange(
                new Department
                {
                    Id = departmentId1,
                    Name = "C215F1",
                    ParentId = Guid.Empty
                },
                new Department
                {
                    Id = departmentId2,
                    Name = "C320F1",
                    ParentId = Guid.Empty
                },
                 new Department
                 {
                     Id = departmentId3,
                     Name = "C321F1",
                     ParentId = Guid.Empty
                 }
            );
            //增加一个超级管理员用户
            context.Users.AddRange(
                 new User
                 {
                     UserName = "admin",
                     Password = "admin", //暂不进行加密
                     Name = "super admin",
                     //DepartmentId = Guid.Empty,
                                     
                 }
            );
            //增加四个基本功能菜单
            context.Menus.AddRange(
                 new Menu
                 {
                     Name = "首页",
                     Code = "Home",
                     SerialNumber = 0,
                     ParentId = Guid.Empty,
                     Icon = "fa fa-link",
                     Url = "Home/Index",
                 },
               new Menu
               {
                   Name = "控制传感器终端",
                   Code = "Terminal",
                   SerialNumber = 1,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "Terminal/Index",
               },
               new Menu
               {
                   Name = "GroundTruth管理",
                   Code = "GroundTruth",
                   SerialNumber = 2,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "GroundTruth/Index",
               },
               new Menu
               {
                   Name = "传感器数据",
                   Code = "App_SensorData",
                   SerialNumber = 3,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "App_SensorData/Index",
               },
               new Menu
               {
                   Name = "GroundTruth数据",
                   Code = "App_GroundTruthData",
                   SerialNumber = 4,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "App_GroundTruthData/Index",
               },
               new Menu
               {
                   Name = "设备地图",
                   Code = "Map",
                   SerialNumber = 5,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "Map/Index",
               },
               new Menu
               {
                   Name = "用户管理",
                   Code = "User",
                   SerialNumber = 6,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "User/Index",
               }, 
               new Menu
               {
                   Name = "楼层管理",
                   Code = "Department",
                   SerialNumber = 7,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "Department/Index",
               }
            );


            
            context.Roles.AddRange(

               new Role
               {
                   Name = "管理员",
                   Code = "管理员",
                   Remarks = "管理员",
               }, 
               new Role
               {
                   Name = "一般用户",
                   Code = "一般用户",
                   Remarks = "一般用户",
               }
            );




            Terminal[] ts = new Terminal[30];
            for(int i = 0; i< 30; i++)
            {
                Guid departmentId = Guid.Empty;
                if (i > 18)
                {
                    departmentId = departmentId1;
                }
                Terminal t = new Terminal
                {
                  
                    DepartmentId = departmentId,
                    ip = "192.168.1." + (i + 140).ToString(),
                    PositionX = i,
                    PositionY = i,
                    desc = "Terminal:" + i.ToString() + " in Department:" + departmentId,
                };
                ts[i] = t;
            }

            context.Terminals.AddRange(ts);




            GroundTruth[] gts = new GroundTruth[1];
            for (int i = 0; i < 1; i++)
            {
                GroundTruth gt = new GroundTruth
                {
                    DepartmentId = departmentId1,
                    ip = "192.168.1." + (i + 100).ToString(),
                    desc = "GroundTruth:" + i.ToString(),
                };
                gts[i] = gt;
            }

            context.GroundTruths.AddRange(gts);


            context.SaveChanges();
        }

    }
}
