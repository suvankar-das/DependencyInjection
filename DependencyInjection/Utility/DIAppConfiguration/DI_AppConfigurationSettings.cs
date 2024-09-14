using DependencyInjection.Utility.AppSettingsClasses;
using Humanizer.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Utility.DIAppConfiguration
{
    public static class DI_AppConfigurationSettings
    {
        public static IServiceCollection AddAppSettingsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //GetSection() required a key and The key would be the exact same name that we have in appsettings.json.
            services.Configure<WazeForecast>(configuration.GetSection("WazeForecast"));
            services.Configure<Stripe>(configuration.GetSection("Stripe"));
            services.Configure<Twilio>(configuration.GetSection("Twilio"));
            services.Configure<SendGrid>(configuration.GetSection("SendGrid"));

            return services;
        }
    }
}
