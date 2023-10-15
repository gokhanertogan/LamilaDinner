using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.GuestAggregate.ValueObjects;

namespace LamilaDinner.Domain.GuestAggregate.Entities;

public sealed class Rating : Entity<RatingId>
{
    private readonly List<RatingItem> _items = new();
    IReadOnlyList<RatingItem> Items => _items.AsReadOnly();

    private Rating(
        RatingId ratingId) : base(ratingId)
    {

    }
}