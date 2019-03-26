using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMusic.Infrastructure.Repository.Context;

namespace MyMusic.Infrastructure.IoC.Manager
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //Application
            //Domain

            //Repository

            serviceCollection.AddSingleton(sp => new MyMusicContext(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
