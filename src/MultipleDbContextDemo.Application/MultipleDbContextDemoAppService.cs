using System;
using System.Collections.Generic;
using System.Text;
using MultipleDbContextDemo.Localization;
using Volo.Abp.Application.Services;

namespace MultipleDbContextDemo;

/* Inherit your application services from this class.
 */
public abstract class MultipleDbContextDemoAppService : ApplicationService
{
    protected MultipleDbContextDemoAppService()
    {
        LocalizationResource = typeof(MultipleDbContextDemoResource);
    }
}
