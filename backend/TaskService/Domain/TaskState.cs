using TaskService.Domain.Events;
using TodoFramework.Domain.Aggregates;
using static System.DateTimeOffset;

namespace TaskService.Domain;

public class TaskState : State<TaskIdentity>
{
    public TaskState(TaskIdentity taskIdentity) : base(taskIdentity)
    {
    }

    protected TaskState()
    {
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsComplete { get; private set; }
    public DateTimeOffset DueDate { get; private set; } = UtcNow;
    public int Priority { get; private set; }
    
    public TaskStatus Status { get; private set; } = TaskStatus.Created;
    public DateTimeOffset CreatedAt { get; private set; } = UtcNow;
    public DateTimeOffset UpdatedAt { get; private set; } = UtcNow;
    
    
    public void When(TaskCreated evt)
    {
        Title = evt.Title;
        Description = evt.Description;
        DueDate = evt.DueDate;
        Priority = evt.Priority;
        Status = TaskStatus.Active;
    }
    public void When(TaskInformationUpdated evt)
    {
        Title = evt.Title;
        Description = evt.Description;
        DueDate = evt.DueDate;
        Priority = evt.Priority;
        Status = TaskStatus.Active;
    }
    
    public void When(TaskRemoved evt)
    {
        Status = TaskStatus.Expunged;
        UpdatedAt = UtcNow;
    }
}
