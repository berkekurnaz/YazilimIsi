﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using ReflectionIT.Mvc.Paging;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.WebApp
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            IFileProvider physicalProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

            services.AddDbContext<DbYazilimIsiContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IFileProvider>(physicalProvider);
            services.AddSession();
            services.AddMvc();

            services.AddPaging();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseMvc(routes =>
            {

                /* Anasayfa Yazilimci Profil Route */
                routes.MapRoute(
                    name: "yazilimci",
                    template: "profil/{name}",
                    defaults: new { controller = "Anasayfa", action = "Yazilimci" });

                /* Anasayfa Isveren Profil Route */
                routes.MapRoute(
                    name: "isveren",
                    template: "isveren/{name}",
                    defaults: new { controller = "Anasayfa", action = "Isveren" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Anasayfa}/{action=Index}/{id?}");

            });
            app.UseStaticFiles();
            app.UseStatusCodePages();
        }
    }
}
