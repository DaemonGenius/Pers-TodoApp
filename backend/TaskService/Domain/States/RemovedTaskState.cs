using TaskService.Domain.Entities;

namespace TaskService.Domain.States;

public class RemovedTaskState : ITaskState
{
    public void Create(TodoTask task) => throw new InvalidOperationException("TodoTask is removed.");
    public void Modify(TodoTask task) => throw new InvalidOperationException("TodoTask is removed.");
    public void Remove(TodoTask task) => throw new InvalidOperationException("TodoTask is already removed.");
}