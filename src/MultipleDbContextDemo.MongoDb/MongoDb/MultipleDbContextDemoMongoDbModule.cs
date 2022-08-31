using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.Uow;

namespace MultipleDbContextDemo.MongoDb;

[DependsOn(
    typeof(MultipleDbContextDemoDomainModule)
    )]
[DependsOn(typeof(AbpMongoDbModule))]
public class MultipleDbContextDemoMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<MultipleDbContextDemoMongoDbContext>(options =>
        {
            options.AddDefaultRepositories();
        });

        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });
    }
}
