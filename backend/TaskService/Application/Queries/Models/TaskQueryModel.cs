using TaskService.Domain;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace TaskService.Application.Queries.Models;

public class TaskQueryModel
{
    public TaskIdentity Identity { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public int Priority { get; private set; }
    public TaskStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}