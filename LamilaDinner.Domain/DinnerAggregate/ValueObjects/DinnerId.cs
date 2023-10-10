using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; private set;}
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}