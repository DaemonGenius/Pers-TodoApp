namespace TaskService.Domain.Events;

public class TaskInformationUpdated
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public int Priority { get; set; }
}