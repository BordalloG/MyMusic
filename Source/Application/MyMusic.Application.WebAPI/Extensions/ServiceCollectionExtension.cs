using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMusic.Application.WebAPI.Middleware;
using MyMusic.Infrastructure.IoC.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Application.WebAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddNativeIoC(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            RegisterAllServices(serviceCollection, configuration);
            RegisterMiddlewares(serviceCollection);
        }

        private static void RegisterAllServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Bootstrapper.RegisterServices(serviceCollection, configuration);
        }
        private static void RegisterMiddlewares(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ErrorHandlerMiddleware>();
        }
    }
}
