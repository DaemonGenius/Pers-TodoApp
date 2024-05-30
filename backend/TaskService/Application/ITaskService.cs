using TaskService.Domain;

namespace TaskService.Application;

public interface ITaskService
{
    public Task<TaskIdentity> CreateTask(
        string title,
        string description,
        DateTimeOffset dueDate,
        int priority
    );

    public Task UpdateTask(
        TaskIdentity identity,
        string title,
        string description,
        DateTimeOffset dueDate,
        int priority
    );

    Task RemoveTask(TaskIdentity identity);
}