using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.GuestAggregate.ValueObjects;

public sealed class RatingId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private RatingId(Guid value)
    {
        Value = value;
    }

    public static RatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}