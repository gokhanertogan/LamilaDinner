using LamilaDinner.Domain.BillAggregate.ValueObjects;
using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Common.ValueObjects;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;
using LamilaDinner.Domain.GuestAggregate.ValueObjects;
using LamilaDinner.Domain.MenuReviewAggregate.ValueObjects;
using LamilaDinner.Domain.UserAggregate.ValueObjects;

namespace LamilaDinner.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId, Guid>
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