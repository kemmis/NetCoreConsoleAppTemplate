using Hangfire;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleAppTemplate.Services
{
    public class ExampleService : IExampleService
    {
        private readonly ILogger log;

        public ExampleService(ILogger log)
        {
            this.log = log;
        }

        public void GetExamples()
        {
            log.Information("Starting GetExamples operation.");

            // todo: add some work here

            log.Information("Finished GetExamples operation.");
        }
    }
}
