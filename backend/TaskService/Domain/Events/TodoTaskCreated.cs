namespace TaskService.Domain.Events;

public class TodoTaskCreated
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
}

public class TodoTaskModified
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
}

public class TodoTaskRemoved
{
    public string Reason { get; set; } // Example of additional data for the event
}