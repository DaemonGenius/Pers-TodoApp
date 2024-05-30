using System.Linq.Expressions;
using TaskService.Domain;
using TaskFramework.Domain.Specifications;

namespace TaskService.Application.Specifications.Rules;

public class DueDateInFutureSpecification : ISpecification<TaskState>
{
    public Expression<Func<TaskState, bool>> SatisfiedBy()
    {
        return task => task.DueDate > DateTimeOffset.UtcNow;
    }
}