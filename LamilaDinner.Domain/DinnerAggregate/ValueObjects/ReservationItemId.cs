using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.DinnerAggregate.ValueObjects;
public sealed class ReservationItemId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private ReservationItemId(Guid value)
    {
        Value = value;
    }

    public static ReservationItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}