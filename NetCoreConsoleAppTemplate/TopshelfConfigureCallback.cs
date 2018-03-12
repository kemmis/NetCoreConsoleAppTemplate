using System;
using System.Collections.Generic;
using System.Text;
using Topshelf;
using Topshelf.HostConfigurators;
using Topshelf.MicrosoftDependencyInjection;

namespace NetCoreConsoleAppTemplate.App
{
    public class TopshelfConfigureCallback
    {
        private readonly IServiceProvider services;

        public TopshelfConfigureCallback(IServiceProvider services)
        {
            this.services = services;
        }

        public Action<HostConfigurator> Action
        {
            get
            {
                return x =>
                {
                    x.UseMicrosoftDependencyInjection(services);

                    x.Service<ExampleHangfireServer>(s =>
                    {
                        s.ConstructUsingMicrosoftDependencyInjection();
                        s.WhenStarted(a => a.Start());
                        s.WhenStopped(a => a.Stop());
                    });

                    x.RunAsLocalSystem();

                    x.SetDescription("Example Service");
                    x.SetDisplayName("Example Service");
                    x.SetServiceName("Example Service");
                };
            }
        }
    }
}
