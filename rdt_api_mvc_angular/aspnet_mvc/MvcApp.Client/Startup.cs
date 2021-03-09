using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Okta.AspNetCore;

namespace MvcApp.Client
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
          services.AddAuthentication(options =>
          {
              options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
              options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
              options.DefaultChallengeScheme = OktaDefaults.MvcAuthenticationScheme;
          })
          .AddCookie()
          .AddOktaMvc(new OktaMvcOptions
          {

              // Replace these values with your Okta configuration
                    OktaDomain = "https://dev-93701432.okta.com",
                    ClientId = "0oa5295nqsdEl0Z0o5d6",
                    ClientSecret = "IrQkquSKr0NRVrbr19A95ofEolsLtM5ljZGGgJOU"
          });
            services.AddControllersWithViews();
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
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Landing}/{action=Index}/{id?}"
                    );
            });
        }
    }
}