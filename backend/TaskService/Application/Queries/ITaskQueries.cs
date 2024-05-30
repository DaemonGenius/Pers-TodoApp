using TaskFramework.Application;
using TaskService.Application.Queries.Models;
using TaskService.Domain;

namespace TaskService.Application.Queries;

public interface ITaskQueries
{
    Task<TaskQueryModel> FindTaskOrDefault(TaskIdentity identity, CancellationToken cT);

    Task<List<TaskQueryModel>> FindTasksByQueryParamsOrDefault(
        QueryParams queryParams,
        CancellationToken cT
    );
}