using TaskService.Domain.Entities;
using TaskService.Domain.Interfaces;

namespace TaskService.Application.Services.Queries;

public class TodoTaskQueryService: ITodoTaskQueryService
{
    private readonly ITodoTaskRepository _taskRepository;

    public TodoTaskQueryService(ITodoTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TodoTask?> GetTask(Guid id)
    {
        return await _taskRepository.GetTaskById(id);
    }

    public async Task<IEnumerable<TodoTask>> GetAllTasks()
    {
        return await _taskRepository.GetAllTasks();
    }
}