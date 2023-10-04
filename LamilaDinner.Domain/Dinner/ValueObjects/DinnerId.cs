using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.Host.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }
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