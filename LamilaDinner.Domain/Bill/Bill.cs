using LamilaDinner.Domain.Bill.ValueObjects;
using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Guest.ValueObjects;
using LamilaDinner.Domain.Host.ValueObjects;

namespace LamilaDinner.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
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
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
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