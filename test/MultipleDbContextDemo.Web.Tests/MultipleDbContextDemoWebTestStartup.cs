using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace MultipleDbContextDemo;

public class MultipleDbContextDemoWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<MultipleDbContextDemoWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
