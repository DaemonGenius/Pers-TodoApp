using TaskService.Domain.Events;
using TodoFramework.Domain.Aggregates;

namespace TaskService.Domain;

public class TaskAggregate : Aggregate<TaskIdentity, TaskState>
{
    public TaskAggregate() : base(null)
    {
    }

    public TaskAggregate(TaskState state) : base(state)
    {
    }

    public void CreateTask(
        string title,
        string description,
        DateTimeOffset dueDate,
        int priority
    )
    {
        State.When(new TaskCreated
        {
            Title = title, 
            Description = description, 
            DueDate = dueDate, 
            Priority = priority
        });
    }
    
    public void UpdateTaskInformation(
        string title,
        string description,
        DateTimeOffset dueDate,
        int priority
    )
    {
        State.When(new TaskInformationUpdated
        {
            Title = title, 
            Description = description, 
            DueDate = dueDate, 
            Priority = priority
        });
    }
    
    public void RemoveTask()
    {
        State.When(new TaskRemoved());
    }
}