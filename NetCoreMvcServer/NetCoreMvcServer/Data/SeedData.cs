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
            Guid departmentId = Guid.NewGuid();
            //增加一个部门
            context.Departments.Add(
               new Department
               {
                   Id = departmentId,
                   Name = "集团总部",
                   ParentId = Guid.Empty
               }
            );
            //增加一个超级管理员用户
            context.Users.Add(
                 new User
                 {
                     UserName = "admin",
                     Password = "admin", //暂不进行加密
                         Name = "super admin",
                     DepartmentId = departmentId
                 }
            );
            //增加四个基本功能菜单
            context.Menus.AddRange(
               new Menu
               {
                   Name = "控制传感器终端",
                   Code = "Terminal",
                   SerialNumber = 0,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "Terminal/Index",
               },
               new Menu
               {
                   Name = "GroundTruth管理",
                   Code = "GroundTruth",
                   SerialNumber = 1,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "GroundTruth/Index",
               },
               new Menu
               {
                   Name = "传感器数据",
                   Code = "App_SensorData",
                   SerialNumber = 2,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "App_SensorData/Index",
               },
               new Menu
               {
                   Name = "GroundTruth数据",
                   Code = "App_GroundTruthData",
                   SerialNumber = 3,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "App_GroundTruthData/Index",
               },
               new Menu
               {
                   Name = "设备地图",
                   Code = "Map",
                   SerialNumber = 4,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link",
                   Url = "Map/Index",
               }
            );


            
            context.SaveChanges();
        }

    }
}
