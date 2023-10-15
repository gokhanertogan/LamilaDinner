using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.GuestAggregate.ValueObjects;

public sealed class RatingItemId : ValueObject
{
    public Guid Value { get; }
    private RatingItemId(Guid value)
    {
        Value = value;
    }

    public static RatingItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}