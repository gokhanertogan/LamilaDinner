using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;
using LamilaDinner.Domain.GuestAggregate.ValueObjects;
using LamilaDinner.Domain.HostAggregate.ValueObjects;

namespace LamilaDinner.Domain.GuestAggregate.Entities;

public sealed class RatingItem : Entity<RatingItemId>
{
    public int Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }

    private RatingItem(
        RatingItemId ratingItemId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        HostId hostId,
        DinnerId dinnerId) : base(ratingItemId)
    {
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        HostId = hostId;
        DinnerId = dinnerId;
    }

    public static RatingItem Create(
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        HostId hostId,
        DinnerId dinnerId)
    {
        return new(
            RatingItemId.CreateUnique(),
            rating,
            createdDateTime,
            updatedDateTime,
            hostId,
            dinnerId);
    }
}