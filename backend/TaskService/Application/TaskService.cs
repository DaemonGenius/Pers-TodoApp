using TaskService.Application.Specifications;
using TaskService.Domain;
using TodoFramework.Application;

namespace TaskService.Application;

public class TaskService(ITaskRepository repository)
    : BaseService<TaskIdentity, TaskAggregate, TaskState, ITaskRepository>(repository),
        ITaskService
{
    private readonly ITaskRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<TaskIdentity> CreateTask(
        string title,
        string description,
        DateTimeOffset dueDate,
        int priority
    )
    {
        return await Add(task =>
        {
            task.CreateTask(title, description, dueDate, priority);
            return Task.CompletedTask;
        }, new TaskCreationSpecification());
    }

    public async Task UpdateTask(
        TaskIdentity identity,
        string title,
        string description,
        DateTimeOffset dueDate,
        int priority
    )
    {
        await Update(identity, task =>
        {
            task.UpdateTaskInformation(title, description, dueDate, priority);
            return Task.CompletedTask;
        }, new TaskUpdateSpecification());
    }
    
    public async Task RemoveTask(TaskIdentity identity)
    {
        await Update(identity, task =>
        {
            task.RemoveTask();
            return Task.CompletedTask;
        });
    }
}