using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleAppTemplate
{
    public abstract class HangfireJobBase
    {
        private readonly IJobCancellationToken jobCancellationToken;

        public HangfireJobBase(IJobCancellationToken jobCancellationToken)
        {
            this.jobCancellationToken = jobCancellationToken;
        }

        protected void ThrowIfCancellationRequested()
        {
            // todo: should this be jobCancellationToken.ShutdownToken.ThrowIfCancellationRequested(); ?
            jobCancellationToken.ThrowIfCancellationRequested();
        }
    }
}
