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
            Guid[] departmentIds = new Guid[3];
            for(int i = 0; i< 3;i++)
            {
                departmentIds[i] = Guid.NewGuid();
            }
            //增加一个部门
            context.Departments.AddRange(
                new Department
                {
                    Id = departmentIds[0],
                    Name = "C215F1",
                    ParentId = Guid.Empty
                },
                new Department
                {
                    Id = departmentIds[1],
                    Name = "C320F1",
                    ParentId = Guid.Empty
                },
                 new Department
                 {
                     Id = departmentIds[2],
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
                     Name = "Share_HomePage",
                     Code = "Home",
                     SerialNumber = 0,
                     ParentId = Guid.Empty,
                     Icon = "fa fa-link",
                     Url = "Home/Index",
                 },
               new Menu
               {
                   Name = "Share_TerminalControl",
                   Code = "Terminal",
                   SerialNumber = 1,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "Terminal/Index",
               },
               new Menu
               {
                   Name = "Share_GroundTruthControl",
                   Code = "GroundTruth",
                   SerialNumber = 2,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "GroundTruth/Index",
               },
               new Menu
               {
                   Name = "Share_SensorData",
                   Code = "App_SensorData",
                   SerialNumber = 3,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "App_SensorData/Index",
               },
               new Menu
               {
                   Name = "Share_GroundTruthData",
                   Code = "App_GroundTruthData",
                   SerialNumber = 4,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "App_GroundTruthData/Index",
               },
               new Menu
               {
                   Name = "Share_Map",
                   Code = "Map",
                   SerialNumber = 5,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "Map/Index",
               },
               new Menu
               {
                   Name = "Share_User_Manage",
                   Code = "User",
                   SerialNumber = 6,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "User/Index",
               }, 
               new Menu
               {
                   Name = "Share_Department_Manage",
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
                   Name = "Share_Administrator",
                   Code = "Share_Administrator",
                   Remarks = "Share_Administrator",
               }, 
               new Role
               {
                   Name = "Share_CommonUser",
                   Code = "Share_CommonUser",
                   Remarks = "Share_CommonUser",
               }
            );



            int totalcount = 3;
            Terminal[] ts = new Terminal[totalcount];
            for(int i = 0; i< totalcount; i++)
            {
                Guid departmentId = Guid.Empty;
                departmentId = departmentIds[i%3];



                Random rx = new Random(i);
                Random ry = new Random(i*i);
                Terminal t = new Terminal
                {
                  
                    DepartmentId = departmentId,
                    ip = "192.168.31." + (i + 1).ToString(),
                    PositionX = rx.Next(100,800),
                    PositionY = ry.Next(100,800),
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
                    DepartmentId = departmentIds[0],
                    ip = "192.168.1." + (i + 100).ToString(),
                    desc = "GroundTruth:" + i.ToString(),
                };
                gts[i] = gt;
            }

            context.GroundTruths.AddRange(gts);


            context.SaveChanges();
        }

        public static void InitializeTerminal(GVContext context)
        {
            if (context.Terminals.Any())
            {
                return;   // 已经初始化过数据，直接返回
            }
            Guid departmentId = context.Departments.First<Department>().Id;
          

            int totalcount = 35;
            Terminal[] ts = new Terminal[totalcount];
            for (int i = 0; i < totalcount; i++)
            {

                Random rx = new Random(i);
                Random ry = new Random(i * i);
                Terminal t = new Terminal
                {

                    DepartmentId = departmentId,
                    ip = "192.168.31." + (i + 1).ToString(),
                    PositionX = rx.Next(100, 800),
                    PositionY = ry.Next(100, 800),
                    desc = "Terminal:" + i.ToString() + " in Department:" + departmentId,
                };
                ts[i] = t;
            }

            context.Terminals.AddRange(ts);




            context.SaveChanges();
        }


        public static void CopySensorData(GVContext context)
        {
            int copycount = 1;

            for(int i =0;i< copycount;i++)
            {
                IQueryable<App_SensorData> list = context.App_SensorData.OrderBy(it => it.createtime);

                App_SensorData[] asds = new App_SensorData[list.Count<App_SensorData>()];

                int j = 0;
                foreach (App_SensorData data in list)
                {
                    App_SensorData nasd = new App_SensorData();
                    nasd.Id = new Guid();
                    nasd.createtime = DateTime.Now;
                    nasd.sensorvalue = data.sensorvalue;
                    nasd.timestampms = data.timestampms;
                    nasd.timestamps = data.timestamps;
                    nasd.device = data.device;
                    nasd.rate = data.rate;
                    nasd.gain = data.gain;

                    asds[j] = nasd;
                    j++;
                }
                context.App_SensorData.AddRange(asds);
            }


            context.SaveChanges();
        }
    }
}
