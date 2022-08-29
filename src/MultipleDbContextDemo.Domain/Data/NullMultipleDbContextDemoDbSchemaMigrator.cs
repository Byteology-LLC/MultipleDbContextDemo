using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MultipleDbContextDemo.Data;

/* This is used if database provider does't define
 * IMultipleDbContextDemoDbSchemaMigrator implementation.
 */
public class NullMultipleDbContextDemoDbSchemaMigrator : IMultipleDbContextDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
