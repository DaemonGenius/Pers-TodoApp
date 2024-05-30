namespace TodoFramework.Domain;

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
}

public interface IDomainEvent{}