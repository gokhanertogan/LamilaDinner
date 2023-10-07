using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.Guest.ValueObjects;

public sealed class RatingId : ValueObject
{
    public Guid Value { get; }
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