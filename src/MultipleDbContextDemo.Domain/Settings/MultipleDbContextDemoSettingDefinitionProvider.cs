using Volo.Abp.Settings;

namespace MultipleDbContextDemo.Settings;

public class MultipleDbContextDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MultipleDbContextDemoSettings.MySetting1));
    }
}
