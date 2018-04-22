using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace url_shortner
{
    public static class Global
    {
        public static IConfiguration Configuration { get; set; }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Global.Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/!error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultNonRedirect",
                    template: "!{action=error}/{id?}",
                    defaults: new { controller = "Home" }
                    );

                routes.MapRoute(
                    name: "defaultRedirect",
                    template: "{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                    );
            });
        }
    }
}
