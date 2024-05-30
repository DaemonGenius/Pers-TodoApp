using TodoFramework.Domain.Aggregates.ValueObjects;

namespace TodoFramework.Domain.Aggregates;

public abstract class Identity: ValueObject
{
    public Guid Reference { get;  }

    public Identity(Guid reference)
    {
        Reference = reference;
    }
}