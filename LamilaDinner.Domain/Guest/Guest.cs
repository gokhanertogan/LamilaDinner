using LamilaDinner.Domain.Bill.ValueObjects;
using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Common.ValueObjects;
using LamilaDinner.Domain.Guest.ValueObjects;
using LamilaDinner.Domain.Host.ValueObjects;
using LamilaDinner.Domain.MenuReview.ValueObjects;
using LamilaDinner.Domain.User.ValueObjects;

namespace LamilaDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public AverageRating AverageRating { get; } = null!;
    public UserId UserId { get; }
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _postDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<Entities.Rating> _ratings = new();

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        UserId userId
        ) : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        UserId = userId;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            DateTime.UtcNow,
            DateTime.UtcNow,
            userId);
    }
}