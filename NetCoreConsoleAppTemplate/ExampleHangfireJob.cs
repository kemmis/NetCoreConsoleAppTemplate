using System;
using System.Collections.Generic;
using System.Text;
using Hangfire;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;

namespace NetCoreConsoleAppTemplate.App
{
    public class ExampleHangfireJob : HangfireJobBase
    {
        private readonly IExampleService exampleService;

        public ExampleHangfireJob(IJobCancellationToken jobCancellationToken, 
            IExampleService exampleService) : base(jobCancellationToken)
        {
            this.exampleService = exampleService;
        }

        public void DoWork()
        {
            exampleService.GetExamples();
        }
    }
}
