namespace TaskFramework.Domain.Aggregates;

public abstract class State<TIdentity> where TIdentity: Identity
{
    public TIdentity Identity { get; }

    public State(TIdentity identity)
    {
        Identity = identity ?? throw new ArgumentNullException(nameof(identity));
    }

    protected State()
    {
        
    }
    
    public void Mutate(IDomainEvent evt)
    {
        ((dynamic)this).When((dynamic)evt);
    }
    
    public virtual bool IsTransient()
    {
        return Identity.Equals(default(Identity));
    }       
}

public interface IDomainEvent{}