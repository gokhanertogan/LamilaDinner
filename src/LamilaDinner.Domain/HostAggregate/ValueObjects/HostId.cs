using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.UserAggregate.ValueObjects;

namespace LamilaDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public string Value { get; private set; }
    private HostId(string value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid().ToString());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static HostId Create(UserId userId)
    {
        return new HostId($"Host_{userId.Value}");
    }
    public static HostId Create(string hostId)
    {
        return new HostId(hostId);
    }
}