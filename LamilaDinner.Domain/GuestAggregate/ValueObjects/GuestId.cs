using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}