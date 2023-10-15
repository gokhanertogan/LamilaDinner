using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Common.ValueObjects;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;
using LamilaDinner.Domain.HostAggregate.ValueObjects;
using LamilaDinner.Domain.MenuAggregate.ValueObjects;
using LamilaDinner.Domain.UserAggregate.ValueObjects;

namespace LamilaDinner.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public AverageRating AverageRating { get; } = null!;
    public UserId UserId { get; }
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();

    private Host(
            HostId guestId,
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

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            DateTime.UtcNow,
            DateTime.UtcNow,
            userId);
    }

}