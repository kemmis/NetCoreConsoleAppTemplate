using System;
using System.Collections.Generic;
using System.Text;
using Hangfire;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;
using Serilog;

namespace NetCoreConsoleAppTemplate.Services
{
    public class ExampleHangfireJob
    {
        private readonly IExampleService exampleService;
        private readonly ILogger log;

        public ExampleHangfireJob(IExampleService exampleService, ILogger log)
        {
            this.exampleService = exampleService;
            this.log = log;
            log.Verbose("ExampleHangfireJob created.");
        }

        public void Run(IJobCancellationToken jobCancellationToken)
        {
            log.Information("Starting ExampleHangfireJob.");
            exampleService.GetExamples(jobCancellationToken.ShutdownToken);
            log.Information("Finished ExampleHangfireJob.");
        }
    }
}
