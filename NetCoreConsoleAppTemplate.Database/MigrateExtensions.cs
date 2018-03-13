using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreConsoleAppTemplate.Database
{
    public static class MigrateExtensions
    {
        public static IServiceProvider Migrate<T>(this IServiceProvider serviceProvider) where T : DbContext
        {
            serviceProvider.GetService<T>().Database.Migrate();
            return serviceProvider;
        }
    }
}
