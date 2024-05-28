using Microsoft.Extensions.DependencyInjection;
using TaskService.Domain.Interfaces;
using TaskService.Domain.Services;
using TaskService.Domain.Services.Queries;
using TaskService.Infrastructure.Data.Repositories;

namespace TaskService.Infrastructure.Config;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITodoTaskRepository, TodoTaskRepository>();
        services.AddScoped<ITodoTaskService, TodoTaskService>();
        services.AddScoped<ITodoTaskQueryService, TodoTaskQueryService>();
    }
}