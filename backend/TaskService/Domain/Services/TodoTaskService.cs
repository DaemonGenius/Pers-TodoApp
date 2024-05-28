using TaskService.Domain.Entities;
using TaskService.Domain.Interfaces;

namespace TaskService.Domain.Services;

public class TodoTaskService: ITodoTaskService
{
    private readonly ITodoTaskRepository _taskRepository;

    public TodoTaskService(ITodoTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void CreateTask(TodoTask task)
    {
        task.Create();
        _taskRepository.AddTask(task);
    }

    public void ModifyTask(Guid taskId, string newName, string newDescription, DateTime newDueDate, int newPriority)
    {
        var task = _taskRepository.GetTaskById(taskId);
        if (task != null)
        {
            task.Title = newName;
            task.Description = newDescription;
            task.DueDate = newDueDate;
            task.Priority = newPriority;
            task.Modify();
            _taskRepository.UpdateTask(task);
        }
    }

    public void RemoveTask(Guid taskId)
    {
        var task = _taskRepository.GetTaskById(taskId);
        if (task != null)
        {
            task.Remove();
            _taskRepository.RemoveTask(taskId);
        }
    }
}
