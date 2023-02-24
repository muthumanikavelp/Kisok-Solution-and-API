using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using Kiosk_web.Common;
using System.ServiceModel;
using log4net;
using System.Reflection;
using log4net.Config;

namespace Kiosk_web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ContractResolver =
            new DefaultContractResolver());
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddKendo();
            services.AddRouting();
            services.AddControllersWithViews();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();           
            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                if (Configuration.GetSection("AppSettings")["Instance"].ToString() == "Ta")
                {
                    routes.MapRoute(
                   name: "default",
                   template: "{controller=launch}/{action=launchViewTa}/{id?}");
                }
                else
                {
                    routes.MapRoute(
                   name: "default",
                   template: "{controller=launch}/{action=launchView}/{id?}");
                }

            });
        }
    }
}
