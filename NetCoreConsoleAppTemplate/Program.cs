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
            // disable quick edit on console
            ConsoleConfig.DisableQuickEdit();

            // load app settings into an IConfiguration object
            var configuration = new ConfigurationBuilder()
                .AddExampleAppConfiguration()
                .Build();

            // create ioc container and configure it
            var serviceProvider = new ServiceCollection()
                .AddExampleAppConfiguration(configuration)
                .BuildServiceProvider();

            // ensure db is initialized
            serviceProvider.Migrate<ExampleDbContext>().Seed<ExampleDbContext>();

            // create instance of the app's callback for topshelf
            var configureCallback = serviceProvider.GetService<TopshelfConfigureCallback>();

            // run the shopshelf host
            HostFactory.Run(configureCallback.Action);

            // flush logger before the app closes
            serviceProvider.FlushLogger();
        }
    }
}
