using TaskService.Domain.Entities;
using TaskService.Domain.Interfaces;

namespace TaskService.Domain.Services.Queries;

public class TodoTaskQueryService: ITodoTaskQueryService
{
    private readonly ITodoTaskRepository _taskRepository;

    public TodoTaskQueryService(ITodoTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public TodoTask GetTask(Guid id)
    {
        return _taskRepository.GetTaskById(id);
    }

    public IEnumerable<TodoTask> GetAllTasks()
    {
        return _taskRepository.GetAllTasks();
    }
}