namespace TodoFramework.Domain;

public abstract class Identity: ValueObject
{
    public Guid Reference { get;  }

    public Identity(Guid reference)
    {
        Reference = reference;
    }
}