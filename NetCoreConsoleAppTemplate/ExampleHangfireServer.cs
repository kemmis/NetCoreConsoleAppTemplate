using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreConsoleAppTemplate.App
{
    public class ExampleHangfireServer
    {
        private readonly IServiceProvider serviceProvider;
        private BackgroundJobServer _server;

        public ExampleHangfireServer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Start()
        {
            _server = serviceProvider.GetService<BackgroundJobServer>();
        }

        public void Stop()
        {
            _server.Dispose();
        }
    }
}
