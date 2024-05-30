using TodoFramework.Domain.Aggregates;

namespace TaskService.Domain;

public class TaskIdentity: Identity
{
    public TaskIdentity(Guid reference) : base(reference)
    {
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Reference;
    }
}