using MultipleDbContextDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MultipleDbContextDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MultipleDbContextDemoController : AbpControllerBase
{
    protected MultipleDbContextDemoController()
    {
        LocalizationResource = typeof(MultipleDbContextDemoResource);
    }
}
