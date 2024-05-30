using System.Linq.Expressions;
using TaskService.Application.Specifications.Rules;
using TaskService.Domain;
using TaskFramework.Domain.Specifications;

namespace TaskService.Application.Specifications;

public class TaskUpdateSpecification : ISpecification<TaskState>
{
    private readonly ISpecification<TaskState> _specification;

    public TaskUpdateSpecification()
    {
        var dueDateSpec = new DueDateInFutureSpecification();
        _specification = dueDateSpec;
    }

    public Expression<Func<TaskState, bool>> SatisfiedBy()
    {
        return _specification.SatisfiedBy();
    }
}