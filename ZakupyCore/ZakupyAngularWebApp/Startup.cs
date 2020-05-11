using System;
using Kruchy.Core;
using Kruchy.Core.Cryptography;
using Kruchy.Uzytkownicy;
using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Services.Impl;
using Kruchy.Zakupy.Dao;
using Kruchy.Zamowienia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZakupyAngularWebApp.Authentication;
using ZakupyAngularWebApp.Services;
using ZakupyAngularWebApp.Services.Impl;

namespace ZakupyAngularWebApp
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
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            new KruchyZakupyDaoModule().Init(services);
            new KruchyUzytkownicyModule().Init(services);
            new KrucheZamowieniaModule().Init(services);
            new KruchyCoreModule().Init(services);

            services.AddTransient<IUploadedFilesService, UploadedFilesService>();
            services.AddTransient<ITokenGenerationService, TokenGenerationService>();
            services.AddTransient<IAesKeyProvider, AesKeysProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string baseDir = env.ContentRootPath;
            var dataDirectory = System.IO.Path.Combine(baseDir, "App_Data");
            TokenGenerationService.KeysDirectory = dataDirectory;
            AesKeysProvider.KeysDirectory = dataDirectory;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
