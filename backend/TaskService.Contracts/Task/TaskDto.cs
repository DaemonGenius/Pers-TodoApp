namespace TaskService.Contracts.Task;

public class TaskDto
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public string DueDate { get; set; }
    public int Priority { get; set; }
    public string Status { get; set; }

    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}