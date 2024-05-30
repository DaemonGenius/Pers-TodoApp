using TaskService.Domain.Entities;

namespace TaskService.Domain.Interfaces;

public interface ITodoTaskRepository
{
    public Task<TodoTask?> GetTaskById(Guid id);
    public Task AddTask(TodoTask task);
    public Task<IEnumerable<TodoTask>> GetAllTasks();
    public Task UpdateTask(TodoTask task);
    public Task RemoveTask(Guid id);
}