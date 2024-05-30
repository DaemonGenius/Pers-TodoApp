using System.Linq.Expressions;
using TaskService.Domain;
using TaskFramework.Domain.Specifications;

namespace TaskService.Application.Specifications.Rules;

public class TitleNotNullOrEmptySpecification : ISpecification<TaskState>
{
    public Expression<Func<TaskState, bool>> SatisfiedBy()
    {
        return task => !string.IsNullOrEmpty(task.Title);
    }
}