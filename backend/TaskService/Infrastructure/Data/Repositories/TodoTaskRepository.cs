using TaskService.Domain.Entities;
using TaskService.Domain.Interfaces;

namespace TaskService.Infrastructure.Data.Repositories;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly Dictionary<Guid, TodoTask> _tasks = new Dictionary<Guid, TodoTask>();

    public TodoTask GetTaskById(Guid id)
    {
        _tasks.TryGetValue(id, out var task);
        return task;
    }

    public IEnumerable<TodoTask> GetAllTasks()
    {
        return _tasks.Values.ToList();
    }

    public void AddTask(TodoTask task)
    {
        _tasks[task.Id] = task;
    }

    public void UpdateTask(TodoTask task)
    {
        _tasks[task.Id] = task;
    }

    public void RemoveTask(Guid id)
    {
        _tasks.Remove(id);
    }
}