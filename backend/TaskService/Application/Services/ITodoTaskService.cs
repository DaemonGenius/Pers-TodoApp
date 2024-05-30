namespace TaskService.Application.Services;

public interface ITodoTaskService
{
    void CreateTask(string name, string description, DateTime dueDate, int priority);
    void ModifyTask(Guid taskId, string newName, string newDescription, DateTime newDueDate, int newPriority);
    void RemoveTask(Guid taskId);
}