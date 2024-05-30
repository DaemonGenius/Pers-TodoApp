namespace TaskFramework.Domain.Aggregates;

public abstract class Aggregate<TIdentity, TState> where TState : State<TIdentity> where TIdentity : Identity
{
    protected TState State { get; }
    public TIdentity Identity => State.Identity;

    protected Aggregate(TState state)
    {
        State = state ?? throw new ArgumentNullException(nameof(state));
    }
}