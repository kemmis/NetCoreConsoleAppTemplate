using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NetCoreConsoleAppTemplate.Core.Contracts.Services
{
    public interface IExampleService
    {
        void GetExamples(CancellationToken cancellationToken);
    }
}
