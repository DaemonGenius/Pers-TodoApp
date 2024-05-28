using TaskService.Domain.Entities;

namespace TaskService.Domain.Interfaces;

public interface ITodoTaskRepository
{
    public TodoTask GetTaskById(Guid id);

    public IEnumerable<TodoTask> GetAllTasks();

    public void AddTask(TodoTask task);

    public void UpdateTask(TodoTask task);

    public void RemoveTask(Guid id);
}