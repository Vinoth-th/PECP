using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.Contracts.Models;
using PromotionEngine.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PromotionEngine.Service.Repository;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostBuilder = new HostBuilder();
            hostBuilder.UseEnvironment("Development")
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Startup>();
                ConfigureServices(services);
            }).ConfigureLogging(configureLogging =>
            {
                configureLogging.AddConsole();
                configureLogging.SetMinimumLevel(LogLevel.Information);
            });

            hostBuilder.RunConsoleAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICheckoutProcess, CheckoutProcess>();

            services.AddScoped<IPromotionTypes, PromotionTypes>();
        }
    }
}
