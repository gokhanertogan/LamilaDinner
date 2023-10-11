using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.UserAggregate.ValueObjects;

namespace LamilaDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    // public static HostId Create(UserId userId)
    // {
    //     return new HostId($"Host_{userId.Value}");
    // }
    // public static HostId Create(string hostId)
    // {
    //     return new HostId(hostId);
    // }

    public static HostId Create(UserId userId)
    {
        return new HostId(userId.Value);
    }
    public static HostId Create(Guid hostId)
    {
        return new HostId(hostId);
    }
}