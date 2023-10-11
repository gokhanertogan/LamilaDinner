using LamilaDinner.Domain.BillAggregate.ValueObjects;
using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;
using LamilaDinner.Domain.GuestAggregate.ValueObjects;
using LamilaDinner.Domain.HostAggregate.ValueObjects;

namespace LamilaDinner.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; set; } = null!;
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private Bill(
        BillId id,
        HostId hostId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        GuestId guestId,
        DinnerId dinnerId,
        HostId hostId)
    {
        return new(
            BillId.CreateUnique(),
            hostId,
            guestId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}