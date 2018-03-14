using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NetCoreConsoleAppTemplate.Database.Seed;

namespace NetCoreConsoleAppTemplate.Database
{
    public static class SeedExtensions
    {
        public static IServiceProvider Seed<T>(this IServiceProvider serviceProvider) where T : DbContext
        {
            serviceProvider.GetService<IDbInitializer<T>>().EnsureSeededAsync();
            return serviceProvider;
        }
    }
}
