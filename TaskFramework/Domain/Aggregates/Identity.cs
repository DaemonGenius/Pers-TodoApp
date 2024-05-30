using TaskFramework.Domain.Aggregates.ValueObjects;

namespace TaskFramework.Domain.Aggregates;

public abstract class Identity: ValueObject
{
    public Guid Reference { get;  }

    public Identity(Guid reference)
    {
        Reference = reference;
    }
}