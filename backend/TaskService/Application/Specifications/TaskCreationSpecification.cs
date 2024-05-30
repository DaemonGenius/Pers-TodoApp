using System.Linq.Expressions;
using TaskService.Application.Specifications.Rules;
using TaskService.Domain;
using TaskFramework.Domain.Specifications;

namespace TaskService.Application.Specifications;

public class TaskCreationSpecification : ISpecification<TaskState>
{
    private readonly ISpecification<TaskState> _specification;

    public TaskCreationSpecification()
    {
        var titleSpec = new TitleNotNullOrEmptySpecification();
        var dueDateSpec = new DueDateInFutureSpecification();
        _specification = new AndSpecification<TaskState>(titleSpec, dueDateSpec);
    }

    public Expression<Func<TaskState, bool>> SatisfiedBy()
    {
        return _specification.SatisfiedBy();
    }
}

