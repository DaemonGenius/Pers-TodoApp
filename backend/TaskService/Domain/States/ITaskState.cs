using TaskService.Domain.Entities;

namespace TaskService.Domain.States;

public interface ITaskState
{
    void Create(TodoTask task);
    void Modify(TodoTask task);
    void Remove(TodoTask task);
}