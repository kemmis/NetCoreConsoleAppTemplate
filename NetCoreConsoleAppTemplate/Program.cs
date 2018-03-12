using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            var configureCallback = serviceProvider.GetService<TopshelfConfigureCallback>();

            HostFactory.Run(configureCallback.Action);
        }
    }
}
