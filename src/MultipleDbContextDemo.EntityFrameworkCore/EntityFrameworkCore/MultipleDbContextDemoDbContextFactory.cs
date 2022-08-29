using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MultipleDbContextDemo.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class MultipleDbContextDemoDbContextFactory : IDesignTimeDbContextFactory<MultipleDbContextDemoDbContext>
{
    public MultipleDbContextDemoDbContext CreateDbContext(string[] args)
    {
        MultipleDbContextDemoEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<MultipleDbContextDemoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new MultipleDbContextDemoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MultipleDbContextDemo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
