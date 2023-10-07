using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.DinnerAggregate.ValueObjects;
public sealed class ReservationItemId : ValueObject
{
    public Guid Value { get; }
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