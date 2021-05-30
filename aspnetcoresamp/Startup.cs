using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Skillbakery.Models;
using Microsoft.EntityFrameworkCore;
using aspnetcoresamp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpOverrides;

namespace Skillbakery
{
    public class Startup
    {
        private readonly IConfigurationRoot configuration;
        public Startup(IHostingEnvironment env)
        {
                 configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile(env.ContentRootPath + "/config.json")
                .AddJsonFile(env.ContentRootPath + "/config.optional.json", true)
                .Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<CourseDC>();
            services.AddTransient<FormattingService>();
            services.AddTransient<Settings>(x=>new Settings() {EnableException = configuration.GetValue<bool>("Settings:EnableException")
            });
            var connection = @"server=LAPTOP-K52S6JUJ;database=Skillbakery;user id=sa;password=naveen206;persist security info=True";
            services.AddDbContext<SkillbakeryContext>(options=>options.UseSqlServer(connection));
            services.AddDbContext<IdentityDataContext>(options => options.UseSqlServer(connection));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>();
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,Settings settings)
        {
            
           // if (env.IsDevelopment())
           //if(configuration["EnableException"]=="True")
           //if(configuration.GetValue<bool>("Settings:EnableException"))
           if(settings.EnableException)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error.html");
            }
            app.Use(async (context,next) =>
            {
                if (context.Request.Path.Value.StartsWith("/exception"))
                {
                    throw new Exception("Error!");
                }
                await next();
            });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders= ForwardedHeaders.XForwardedFor| ForwardedHeaders.XForwardedProto
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseIdentity();
            app.UseMvc(routes => routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"));
            app.UseFileServer();
            
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
