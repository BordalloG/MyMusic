using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMusic.Application.Implementation;
using MyMusic.Application.Interfaces;
using MyMusic.Domain.Implementations;
using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Interfaces.Repository;
using MyMusic.Infrastructure.Repository.Context;
using MyMusic.Infrastructure.Repository.Implementation;

namespace MyMusic.Infrastructure.IoC.Manager
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //Application
            serviceCollection.AddScoped<IMusicApplicationService, MusicApplicationService>();
            //Domain
            serviceCollection.AddScoped<IMusicDomainService, MusicDomainService>();
            //Repository
            serviceCollection.AddScoped<IMusicRepository, MusicRepository>();

            serviceCollection.AddSingleton(sp => new MyMusicContext(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
