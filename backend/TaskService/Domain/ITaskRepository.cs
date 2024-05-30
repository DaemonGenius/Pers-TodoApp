using TodoFramework.Domain.Aggregates;

namespace TaskService.Domain;

public interface ITaskRepository: IRepository<TaskIdentity, TaskState>
{
}