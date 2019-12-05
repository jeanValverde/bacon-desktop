using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bacon_desktop
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            //runBaconDesktop(); 

           /// loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });



            if (HybridSupport.IsElectronActive)
            {
                Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
                //runBaconDesktop();
            }
        }


        public async void runBaconDesktop()
        {
            var opcions = new BrowserWindowOptions
            {
                Show = false
            };

            var mainWindow = await Electron.WindowManager.CreateWindowAsync(opcions);

            mainWindow.OnReadyToShow += () =>
            {
                mainWindow.Show();
            };

            var menu = new MenuItem[]
            {
                new MenuItem
                {
                    Label = "Bacon",
                    Submenu = new MenuItem[]
                    {
                        new MenuItem {
                            Label = "Cerrar Sesión",
                            Click = () =>{
                                Electron.App.Exit();
                            }
                        }
                    }
                }, new MenuItem
                {
                    Label ="Configuración",
                    Click = () => {

                    }
                }
            };

            Electron.Menu.SetApplicationMenu(menu);


        }
    }
}
