using TaskService.Domain.Entities;

namespace TaskService.Domain.States;

public class NewTaskState : ITaskState
{
    public void Create(TodoTask task) => throw new InvalidOperationException("TodoTask is already created.");
    public void Modify(TodoTask task)
    {
        task.UpdatedAt = DateTime.UtcNow;
        task.State = new ModifiedTaskState();
    }
    public void Remove(TodoTask task) => task.State = new RemovedTaskState();


}