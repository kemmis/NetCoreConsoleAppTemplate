using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;
using NetCoreConsoleAppTemplate.Database;
using NetCoreConsoleAppTemplate.Services;
using Hangfire;
using Serilog;

namespace NetCoreConsoleAppTemplate.App
{
    public static class ExampleConfigurationExtensions
    {
        public static IConfigurationBuilder AddExampleAppConfiguration(this IConfigurationBuilder builder)
        {
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            // todo: add environment-specific appsettings loading
            return builder;
        }

        public static IServiceCollection AddExampleAppConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton(configuration)
                .AddTransient<TopshelfConfigureCallback>()
                .AddTransient<BackgroundJobServer>()
                .AddTransient<ExampleHangfireJob>()
                .AddTransient<IExampleService, ExampleService>()
                .AddTransient<IExampleHangfireJobManagementService, ExampleHangfireJobManagementService>()
                .AddLogging(configuration)
                .AddDbContext<ExampleDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                }, ServiceLifetime.Transient, ServiceLifetime.Transient)
                .AddHangfire(x =>
                {
                    x.UseSqlServerStorage(configuration.GetConnectionString("hangfire"))
                     .UseColouredConsoleLogProvider();
                });
            return service;
        }

        public static IServiceCollection AddLogging(this IServiceCollection service, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                                .WriteTo.LiterateConsole()
                                .WriteTo.MSSqlServer(configuration.GetConnectionString("DefaultConnection"), "Logs", autoCreateSqlTable: true)
                                .CreateLogger();

            service.AddSingleton<ILogger>(logger);

            return service;
        }
    }
}
