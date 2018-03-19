# NetCoreConsoleAppTemplate

## An example Hangfire/Topshelf application that primarily uses .Net Standard 2.0 libraries<sup>*</sup>.

#### <sup>*</sup> Topshelf does not yet target .Net Standard

# Example Includes:

* Using Microsoft.Extensions.Configuration (ConfigurationBuilder/IConfiguration classes) to persist settings in appsettings.json file within a console app like Asp.Net Core does.

* Using Microsoft.Extensions.DependencyInjection (IServiceCollection/ServiceProvider classes) for dependency injection within a console app like Asp.Net Core does.

* Entity Framework Core
    * Reads connection string from configuration
    * Migration Ready
    * Seeding

* Using Microsoft.Extensions.Logging configured to use Serilog with MSSqlServer

* Topshelf configuration:
    * Using Microsoft.Extensions.DependencyInjection for service construction.
    * Using Serilog for logging

* Hangfire configuration:
    * Using MSSqlServer
    * Using Serilog for logging
    * Example BackgroundJobServer initialization
    * Example recurring job with initialization
    * Example use of IJobCancellationToken / CancellationToken