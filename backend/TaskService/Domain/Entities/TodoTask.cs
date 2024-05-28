using System.ComponentModel.DataAnnotations;
using TaskService.Domain.States;

namespace TaskService.Domain.Entities;

public class TodoTask
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ITaskState State { get; set; }

    public TodoTask()
    {
        Id = Guid.NewGuid();
        IsComplete = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        State = new NewTaskState();
    }

    public void Create() => State.Create(this);
    public void Modify() => State.Modify(this);
    public void Remove() => State.Remove(this);
}