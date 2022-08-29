using MultipleDbContextDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;
using MultipleDbContextDemo.MongoDb;

namespace MultipleDbContextDemo.DbMigrator;

[DependsOn(typeof(MultipleDbContextDemoMongoDbModule))]
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MultipleDbContextDemoEntityFrameworkCoreModule),
    typeof(MultipleDbContextDemoApplicationContractsModule)
    )]

public class MultipleDbContextDemoDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
