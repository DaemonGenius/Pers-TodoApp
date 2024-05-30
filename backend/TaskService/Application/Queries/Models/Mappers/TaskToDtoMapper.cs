using TaskService.Contracts.Task;

namespace TaskService.Application.Queries.Models.Mappers;

public static class TaskToDtoMapper
{
    public static TaskDto Map(TaskQueryModel task)
    {
        return new TaskDto
        {
            TaskId = task.Identity.Reference,
            Title = task.Title,
            Description = task.Description,
            IsComplete = task.IsComplete,
            Priority = task.Priority,
            DueDate = task.DueDate.ToString(),
            Status = task.Status.ToString(),
            CreatedAt = task.CreatedAt.ToString(),
            UpdatedAt = task.UpdatedAt.ToString()
        };
    }
    
}