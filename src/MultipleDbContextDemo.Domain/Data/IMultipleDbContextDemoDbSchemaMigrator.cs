using System.Threading.Tasks;

namespace MultipleDbContextDemo.Data;

public interface IMultipleDbContextDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
