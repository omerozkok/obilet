using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using obilet.Business.Abstract;
using obilet.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.DependencyResolvers
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ISessionService, SessionManager>();
            services.AddScoped<IApiService, ApiManager>();
            services.AddScoped<ICookieService, CookieManager>();
            services.AddScoped<IBusLocationService, BusLocationManager>();
            services.AddScoped<IBusJourneyService, BusJourneyManager>();
        }
    }
}
