using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskService.Domain;
using TaskService.Infrastructure.Database;
using TaskService.Infrastructure.Database.Task;

namespace TaskService.Infrastructure.Config;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITaskRepository, TaskRepository>();
        
        var connectionString = configuration.GetConnectionString("postgresDb");
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<TaskServiceContext>(
                options => options.UseNpgsql(connectionString)
            );
    }
}