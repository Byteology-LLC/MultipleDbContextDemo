using MultipleDbContextDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MultipleDbContextDemo.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MultipleDbContextDemoPageModel : AbpPageModel
{
    protected MultipleDbContextDemoPageModel()
    {
        LocalizationResourceType = typeof(MultipleDbContextDemoResource);
    }
}
