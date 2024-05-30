using TaskService.Domain.Entities;
using TaskService.Domain.Events;
using TodoFramework.Domain;

namespace TaskService.Domain;

public class TodoTaskAggregate : Aggregate<TodoTaskIdentity, TodoTask>
{
    public TodoTaskAggregate() : base(null)
    {
    }

    public TodoTaskAggregate(TodoTask state) : base(state)
    {
    }

    public void CreateTask(
        string name,
        string description,
        DateTime dueDate,
        int priority
    )
    {
        State.Create(new TodoTaskCreated()
        {
            Title = name,
            Description = description,
            DueDate = dueDate,
            Priority = priority
        });
    }

    public void ModifyTask(
        string newName,
        string newDescription,
        DateTime newDueDate,
        int newPriority
    )
    {
        State.Modify(new TodoTaskModified
            {
                Title = newName,
                Description = newDescription,
                DueDate = newDueDate,
                Priority = newPriority
            }
        );
    }

    public void RemoveTask()
    {
        State.Remove(new TodoTaskRemoved { Reason = "Removed by user" });
    }
}