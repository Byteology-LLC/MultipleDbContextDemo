using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultipleDbContextDemo.Data;
using Volo.Abp.DependencyInjection;

namespace MultipleDbContextDemo.EntityFrameworkCore;

public class EntityFrameworkCoreMultipleDbContextDemoDbSchemaMigrator
    : IMultipleDbContextDemoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMultipleDbContextDemoDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MultipleDbContextDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MultipleDbContextDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
