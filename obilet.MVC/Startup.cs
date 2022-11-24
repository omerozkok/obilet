using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using obilet.Business.DependencyResolvers;
using obilet.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace obilet.MVC
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

            services.AddHttpClient("obilet", c =>
            {
                c.BaseAddress = new Uri("https://v2-api.obilet.com/api/");
                c.DefaultRequestHeaders.Add("Authorization", "Basic JEcYcEMyantZV095WVc3G2JtVjNZbWx1");
                c.DefaultRequestHeaders.Add("User-Agent", "User-Agent-Here");
                c.DefaultRequestHeaders
                                    .Accept
                                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(opt =>
                   {
                       opt.LoginPath = "/Account/Login/";
                       opt.EventsType = typeof(CustomCookieAuthenticationEvents);
                       opt.AccessDeniedPath = "/Home/Privacy/";
                   });
            services.AddScoped<CustomCookieAuthenticationEvents>();

            services.AddDetectionCore().AddBrowser();

            services.AddHttpContextAccessor();

            services.InjectDependencies(Configuration);
            services.AddHttpContextAccessor();

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

            app.UseRouting();

            // cookie
            app.UseAuthentication();
           

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
