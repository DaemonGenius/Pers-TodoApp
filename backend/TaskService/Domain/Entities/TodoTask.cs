using TaskService.Domain.Events;
using TodoFramework.Domain;

namespace TaskService.Domain.Entities;

public class TodoTask: State<TodoTaskIdentity>
{
    public TodoTask(TodoTaskIdentity todoTaskIdentity) : base(todoTaskIdentity)
    {
    }

    protected TodoTask()
    {
    }
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsComplete { get; private set; } = false;
    public DateTime DueDate { get; private set; }
    public int Priority { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public StateStatus State { get; private set; } = StateStatus.New;

    private void Apply(TodoTaskCreated evt)
    {
        Title = evt.Title;
        Description = evt.Description;
        DueDate = evt.DueDate;
        Priority = evt.Priority;
        State = StateStatus.Active;
    }

    private void Apply(TodoTaskModified evt)
    {
        Title = evt.Title;
        Description = evt.Description;
        DueDate = evt.DueDate;
        Priority = evt.Priority;
        UpdatedAt = DateTime.UtcNow;
        State = StateStatus.Modified;
    }

    private void Apply(TodoTaskRemoved evt)
    {
        IsComplete = true;
        UpdatedAt = DateTime.UtcNow;
        State = StateStatus.Removed;
    }

    // Command methods to trigger events
    public void Create(TodoTaskCreated evt) => Apply(evt);
    public void Modify(TodoTaskModified evt) => Apply(evt);
    public void Remove(TodoTaskRemoved evt) => Apply(evt);
}

