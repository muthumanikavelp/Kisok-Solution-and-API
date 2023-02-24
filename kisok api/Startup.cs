using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kisok_api.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using nafmodel;
using kisok_api.Services;
using log4net;
using log4net.Config;
using System.Reflection;
using System.IO;

namespace kisok_api
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
            services.AddCors();
            services.AddControllers();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IUserService, UserService>();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            if ((Configuration.GetSection("AppSettings")["Environment"].ToString() == "UAT"))
            {
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeODUat"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeUPUAt"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeTAUAt"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeBHUat"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeJUUAT"));
            }
            else if (Configuration.GetSection("AppSettings")["Environment"].ToString() == "PRO")
            {
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeTAPRO"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeBAPRO"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeODPRO"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeUPPRO"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeJUPRO"));
            }
            else if (Configuration.GetSection("AppSettings")["Environment"].ToString() == "DEV")
            {
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeTA"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeBA"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeOD"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeUP"));
                services.Configure<MySettingsModel>(Configuration.GetSection("dbtypeJU"));
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ////   loggerFactory.AddLog4Net();
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
