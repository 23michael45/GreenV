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
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.Extensions.Options;
using NetCoreMvcServer.Components;
using Microsoft.AspNetCore.Localization;

namespace NetCoreMvcServer
{
    public class Startup
    {

        public static GVContext _GVContext;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

           
            InitMapper();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectstring = Configuration.GetConnectionString("GVContext");
            services.AddDbContext<GVContext>(options =>
            options.UseMySql(connectstring));

            DbContextOptionsBuilder<GVContext> builder = new DbContextOptionsBuilder<GVContext>();
            builder.UseMySql(connectstring);
            _GVContext = new GVContext(builder.Options);
            Thread t = new Thread(MainEntry.Entry);
            t.Start();


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
            services.AddScoped<IApp_GroundTruthDataRepository, App_GroundTruthDataRepository>();


            services.AddScoped<SharedResource>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();



            //services.Configure<RequestLocalizationOptions>(
            //  options =>
            //  {
            //      var supportedCultures = new List<CultureInfo>
            //          {
            //                new CultureInfo("en-US"),
            //                new CultureInfo("zh-CN"),
            //          };

                  
            //      //options.DefaultRequestCulture = new RequestCulture("zh-CN");
            //      options.DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"));
            //      options.SupportedCultures = supportedCultures;
            //      options.SupportedUICultures = supportedCultures;
                  

                  
            //  });

          
            //Session服务
            services.AddSession();

            services.Configure<IISOptions>(options =>
            {
            });


            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GVContext gvcontext)
        {
        


            var supportedCultures = new CultureInfo[]
                      {
                            new CultureInfo("en-US"),
                            new CultureInfo("zh-CN"),
                      };
            var options = new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                //DefaultRequestCulture = new RequestCulture(new CultureInfo("zh-CN")),
                DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US")),

            };

            options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    //new QueryStringRequestCultureProvider { Options = options },
                    new CookieRequestCultureProvider(),
                    //new AcceptLanguageHeaderRequestCultureProvider { Options = options }
                };

            //options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider { CookieName = CookieRequestCultureProvider.DefaultCookieName });
            //options.RequestCultureProviders.Insert(1, new CustomRequestCultureProvider(async httpContext =>
            // {
            //     return new ProviderCultureResult("zh-CN");
            // }));

            //services.Configure<RequestLocalizationOptions>(
            //  options =>
            //  {
            //      var supportedCultures = new List<CultureInfo>
            //          {
            //                new CultureInfo("en-US"),
            //                new CultureInfo("zh-CN"),
            //          };


            //      //options.DefaultRequestCulture = new RequestCulture("zh-CN");
            //      options.DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"));
            //      options.SupportedCultures = supportedCultures;
            //      options.SupportedUICultures = supportedCultures;



            //  });

            //var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            //app.UseRequestLocalization(options.Value);
            app.UseRequestLocalization(options);

            

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


           


            //ConsoleServer.MySqlConnector.TransferDB();
            SeedData.Initialize(gvcontext); //初始化数据

            //SeedData.CopySensorData(gvcontext);
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
