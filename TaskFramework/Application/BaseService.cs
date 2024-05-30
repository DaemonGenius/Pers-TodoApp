using TaskFramework.Domain.Aggregates;
using TaskFramework.Domain.Specifications;

namespace TaskFramework.Application;

public abstract class BaseService<TIdentity, TAggregate, TState, TRepository>(TRepository repository)
    where TIdentity : Identity
    where TAggregate : Aggregate<TIdentity, TState>, new()
    where TState : State<TIdentity>
    where TRepository : IRepository<TIdentity, TState>
{
    private TRepository Repository { get; } = repository ?? throw new ArgumentNullException(nameof(repository));

    protected async Task<TIdentity> Add(Func<TAggregate, Task> callback, ISpecification<TState>? specification = null)
    {
        var state = Repository.Initialize();
        var aggregate = (TAggregate)Activator.CreateInstance(typeof(TAggregate), state);

        await callback(aggregate);

        if (specification != null && !IsSatisfiedBySpecification(state, specification))
        {
            throw new InvalidOperationException("Aggregate does not satisfy the specified rules.");
        }

        await Repository.Save(state);

        return aggregate.Identity;
    }

    protected async Task Update(TIdentity identity, Func<TAggregate, Task> callback, ISpecification<TState>? specification = null)
    {
        var state = await Repository.FetchOrDefault(identity);
        if (state == null) throw new AggregateNotFoundException(nameof(TAggregate));

        var aggregate = (TAggregate)Activator.CreateInstance(typeof(TAggregate), state);
        await callback(aggregate);

        if (specification != null && !IsSatisfiedBySpecification(state, specification))
        {
            throw new InvalidOperationException("Aggregate does not satisfy the specified rules.");
        }

        await Repository.Save(state);
    }
    
    private bool IsSatisfiedBySpecification(TState state, ISpecification<TState> specification)
    {
        var predicate = specification.SatisfiedBy().Compile();
        return predicate(state);
    }
}

public class AggregateNotFoundException(string aggregateName) : Exception
{
    public string AggregateName { get; init; } = aggregateName;

    public void Deconstruct(out string aggregateName)
    {
        aggregateName = this.AggregateName;
    }
}