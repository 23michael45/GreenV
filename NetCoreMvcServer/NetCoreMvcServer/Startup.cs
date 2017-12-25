using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NetCoreMvcServer.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Threading;
using ConsoleServer;

namespace NetCoreMvcServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Thread t = new Thread(MainEntry.Entry);
            t.Start();

            InitMapper();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<GVContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("GVContext")));


            //依赖注入
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentAppService, DepartmentAppService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleAppService, RoleAppService>();


            services.AddScoped<ITerminalAppService, TerminalAppService>();
            services.AddScoped<IGroundTruthAppService, GroundTruthAppService>();
            services.AddScoped<ITerminalRepository, TerminalRepository>();
            services.AddScoped<IGroundTruthRepository, GroundTruthRepository>();

            services.AddScoped<IApp_SensorDataRepository, App_SensorDataRepository>();

            services.AddMvc();
            //Session服务
            services.AddSession();

            
            //services.AddDbContext<MovieContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("MovieContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GVContext gvcontext)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
            }
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            });


            //Session
            app.UseSession();            

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "default", 
                //    template: "{controller=Home}/{action=Index}/{id?}");


                routes.MapRoute(
                    name: "default", 
                    template: "{controller=Login}/{action=Index}/{id?}");
            });


            SeedData.Initialize(gvcontext); //初始化数据


        }


        void InitMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<MenuDto, Menu>();
                cfg.CreateMap<Department, DepartmentDto>();
                cfg.CreateMap<DepartmentDto, Department>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>();

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserRoleDto, UserRole>();
                cfg.CreateMap<UserRole, UserRoleDto>();


                cfg.CreateMap<App_SensorData, App_SensorDataDto>();
                cfg.CreateMap<App_SensorDataDto, App_SensorData>();
                cfg.CreateMap<TerminalDto, Terminal>();
                cfg.CreateMap<Terminal, TerminalDto>();

                cfg.CreateMap<GroundTruthDto, GroundTruth>();
                cfg.CreateMap<GroundTruth, GroundTruthDto>();
            });
        }
    }
}
