using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreConsoleAppTemplate.Database;
using Topshelf;

namespace NetCoreConsoleAppTemplate.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddExampleAppConfiguration()
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddExampleAppConfiguration(configuration)
                .BuildServiceProvider();

            serviceProvider.Migrate<ExampleDbContext>().Seed<ExampleDbContext>();

            var configureCallback = serviceProvider.GetService<TopshelfConfigureCallback>();

            HostFactory.Run(configureCallback.Action);
        }
    }
}
