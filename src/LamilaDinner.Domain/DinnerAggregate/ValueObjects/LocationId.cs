using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class LocationId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private LocationId(Guid value)
    {
        Value = value;
    }

    public static LocationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}