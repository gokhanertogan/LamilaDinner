using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Guest.ValueObjects;

namespace LamilaDinner.Domain.Guest.Entities;

public sealed class Rating : Entity<RatingId>
{
    private readonly List<RatingItem> _items = new();
    IReadOnlyList<RatingItem> Items => _items.AsReadOnly();

    private Rating(
        RatingId ratingId) : base(ratingId)
    {

    }
}