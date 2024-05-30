using TaskService.Domain.Entities;
using TaskService.Domain.Events;
using TaskService.Domain.Interfaces;

namespace TaskService.Application.Services;

public class TodoTaskService : ITodoTaskService
{
    private readonly ITodoTaskRepository _taskRepository;

    public TodoTaskService(ITodoTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void CreateTask(
        string name,
        string description,
        DateTime dueDate,
        int priority
    )
    {
        var task = new TodoTask();
        task.Create(new TodoTaskCreated()
        {
            Title = name,
            Description = description,
            DueDate = dueDate,
            Priority = priority
        });
        _taskRepository.AddTask(task);
    }

    public async void ModifyTask(
        Guid taskId,
        string newName,
        string newDescription,
        DateTime newDueDate,
        int newPriority
    )
    {
        var task = await _taskRepository.GetTaskById(taskId);
        if (task != null)
        {
            task.Modify(new TodoTaskModified
                {
                    Title = newName,
                    Description = newDescription,
                    DueDate = newDueDate,
                    Priority = newPriority
                }
            );
            await _taskRepository.UpdateTask(task);
        }
    }

    public async void RemoveTask(Guid taskId)
    {
        var task = await _taskRepository.GetTaskById(taskId);
        if (task != null)
        {
            task.Remove(new TodoTaskRemoved { Reason = "Removed by user" });
            await _taskRepository.RemoveTask(taskId);
        }
    }
}