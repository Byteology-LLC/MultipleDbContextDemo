using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MultipleDbContextDemo.Web;

[Dependency(ReplaceServices = true)]
public class MultipleDbContextDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MultipleDbContextDemo";
}
