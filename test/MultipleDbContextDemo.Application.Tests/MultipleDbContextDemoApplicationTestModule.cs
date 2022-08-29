using Volo.Abp.Modularity;

namespace MultipleDbContextDemo;

[DependsOn(
    typeof(MultipleDbContextDemoApplicationModule),
    typeof(MultipleDbContextDemoDomainTestModule)
    )]
public class MultipleDbContextDemoApplicationTestModule : AbpModule
{

}
