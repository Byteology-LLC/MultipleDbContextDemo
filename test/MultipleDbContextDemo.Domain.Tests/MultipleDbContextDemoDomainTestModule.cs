using MultipleDbContextDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MultipleDbContextDemo;

[DependsOn(
    typeof(MultipleDbContextDemoEntityFrameworkCoreTestModule)
    )]
public class MultipleDbContextDemoDomainTestModule : AbpModule
{

}
