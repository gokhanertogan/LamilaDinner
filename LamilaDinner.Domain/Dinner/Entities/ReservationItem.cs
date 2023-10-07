using LamilaDinner.Domain.Bill.ValueObjects;
using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Dinner.ValueObjects;
using LamilaDinner.Domain.Guest.ValueObjects;

namespace LamilaDinner.Domain.Dinner.Entities;

public sealed class ReservationItem : Entity<ReservationItemId>
{
    public int GuestCount { get; }
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public GuestId GuestId { get; }
    public BillId BillId { get; }


    private ReservationItem(
        ReservationItemId reservationItemId,
        int guestCount,
        DateTime arrivalDateTime,
        DateTime createDateTime,
        DateTime updatedDateTime,
        BillId billId,
        GuestId guestId
        ) : base(reservationItemId)
    {
        GuestCount = guestCount;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createDateTime;
        UpdatedDateTime = updatedDateTime;
        BillId = billId;
        GuestId = guestId;
    }

    public static ReservationItem Create(
        int guestCount,
        BillId billId,
        GuestId guestId)
    {
        return new(
            ReservationItemId.CreateUnique(),
            guestCount,
            DateTime.UtcNow,
            DateTime.UtcNow,
            DateTime.UtcNow,
            billId,
            guestId
            );
    }
}