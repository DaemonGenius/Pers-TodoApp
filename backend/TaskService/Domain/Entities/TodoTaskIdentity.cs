using TodoFramework.Domain;

namespace TaskService.Domain.Entities;

public class TodoTaskIdentity: Identity
{
    public TodoTaskIdentity(Guid reference) : base(reference)
    {
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Reference;
    }
}