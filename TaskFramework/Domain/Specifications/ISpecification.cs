using System.Linq.Expressions;

namespace TaskFramework.Domain.Specifications;

public interface ISpecification<TState>
    where TState : class
{
    /// <summary>
    /// Check if this specification is satisfied by a 
    /// specific expression lambda
    /// </summary>
    /// <returns></returns>
    Expression<Func<TState, bool>> SatisfiedBy();
}