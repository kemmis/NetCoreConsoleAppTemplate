using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;
using Serilog;
using System.Threading;
using Serilog.Core;

namespace NetCoreConsoleAppTemplate.App
{
    public class ExampleHangfireServer
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IExampleHangfireJobManagementService jobManagementService;
        private BackgroundJobServer _server;
        private readonly ILogger logger;
        public ExampleHangfireServer(IServiceProvider serviceProvider,
            IExampleHangfireJobManagementService jobManagementService, ILogger logger)
        {
            this.serviceProvider = serviceProvider;
            this.jobManagementService = jobManagementService;
            this.logger = logger;
        }

        public void Start()
        {
            // start the hangfire background server
            _server = serviceProvider.GetService<BackgroundJobServer>();

            // init / reset any recurring jobs
            jobManagementService.ScheduleRecurringJobs();
        }

        public void Stop()
        {
            _server.Dispose();
        }
    }
}
