using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace web_editor_seo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "applications",
                    template: "{controller=Applications}/{action=Index}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pages",
                    template: "pages/{controller=Pages}/{action=Index}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "marketpages",
                    template: "marketpages/{controller=MarketPages}/{action=Index}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagedata",
                    template: "pagedata/{controller=PageData}/{action=Index}");
            });

                        app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "success",
                    template: "success/{controller=Success}/{action=Index}");
            });
        }
    }
}
