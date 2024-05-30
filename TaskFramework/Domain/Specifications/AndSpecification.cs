using System.Linq.Expressions;

namespace TaskFramework.Domain.Specifications;

public class AndSpecification<TState>(ISpecification<TState> left, ISpecification<TState> right)
    : ISpecification<TState>
    where TState : class
{
    public Expression<Func<TState, bool>> SatisfiedBy()
    {
        var leftExpression = left.SatisfiedBy();
        var rightExpression = right.SatisfiedBy();

        var parameter = Expression.Parameter(typeof(TState));
        var body = Expression.AndAlso(
            Expression.Invoke(leftExpression, parameter),
            Expression.Invoke(rightExpression, parameter)
        );

        return Expression.Lambda<Func<TState, bool>>(body, parameter);
    }
}