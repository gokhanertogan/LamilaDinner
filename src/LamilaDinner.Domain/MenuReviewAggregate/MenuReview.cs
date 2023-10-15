using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;
using LamilaDinner.Domain.GuestAggregate.ValueObjects;
using LamilaDinner.Domain.HostAggregate.ValueObjects;
using LamilaDinner.Domain.MenuAggregate.ValueObjects;
using LamilaDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace LamilaDinner.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public int Rating { get; }
    public string Comment { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    private MenuReview(
            MenuReviewId menuReviewId,
            int rating,
            string comment,
            DateTime createdDateTime,
            DateTime updatedDateTime,
            HostId hostId,
            MenuId menuId,
            DinnerId dinnerId,
            GuestId guestId) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        HostId = hostId;
        MenuId = menuId;
        DinnerId = dinnerId;
        GuestId = guestId;
    }

    public static MenuReview Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        DinnerId dinnerId,
        GuestId guestId)
    {
        return new(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            DateTime.UtcNow,
            DateTime.UtcNow,
            hostId,
            menuId,
            dinnerId,
            guestId);
    }

}