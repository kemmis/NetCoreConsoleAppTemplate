using Hangfire;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleAppTemplate.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IJobCancellationToken jobCancellationToken;

        public ExampleService(IJobCancellationToken jobCancellationToken = default(IJobCancellationToken))
        {
            this.jobCancellationToken = jobCancellationToken;
        }

        public void GetExamples()
        {
            // todo: add some work here
        }
    }
}
