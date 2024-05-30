using TaskFramework.Domain.Aggregates;

namespace TaskService.Domain;

public interface ITaskRepository: IRepository<TaskIdentity, TaskState>
{
}