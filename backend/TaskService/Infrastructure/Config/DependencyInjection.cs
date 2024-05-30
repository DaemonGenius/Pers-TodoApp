using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskService.Application.Services;
using TaskService.Application.Services.Queries;
using TaskService.Domain.Interfaces;
using TaskService.Infrastructure.Data.Repositories;
using TaskService.Infrastructure.Database;

namespace TaskService.Infrastructure.Config;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITodoTaskRepository, TodoTaskRepository>();
        services.AddScoped<ITodoTaskService, TodoTaskService>();
        services.AddScoped<ITodoTaskQueryService, TodoTaskQueryService>();
        
        var connectionString = configuration.GetConnectionString("postgresDb");
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<TodoTaskServiceContext>(
                options => options.UseNpgsql(connectionString)
            );
    }
}