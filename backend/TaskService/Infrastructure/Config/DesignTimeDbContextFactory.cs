using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TaskService.Infrastructure.Database;

namespace TaskService.Infrastructure.Config;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<TaskServiceContext>
{
    public TaskServiceContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TaskServiceContext>();

        var relativePath = Path.GetFullPath(Path.Combine(
            Path.GetDirectoryName(typeof(DesignTimeDbContextFactory).Assembly.Location) ?? string.Empty,
            "..", "..", "..", "..",".."));

        // Use IConfiguration for design-time configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(relativePath)
            .AddJsonFile("AppFrontend/appsettings.Development.json", false, true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TaskServiceContext>();

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("postgresDB"));

        return new TaskServiceContext(optionsBuilder.Options);
    }
}