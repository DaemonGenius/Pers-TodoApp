using TodoFramework.Domain.Aggregates;

namespace TaskService.Domain.Events;

public class TaskCreated: IDomainEvent
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public int Priority { get; set; }
}