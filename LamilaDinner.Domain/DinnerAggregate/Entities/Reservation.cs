using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;

namespace LamilaDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    private readonly List<ReservationItem> _items = new();

    IReadOnlyList<ReservationItem> Items => _items.AsReadOnly();

    private Reservation(ReservationId reservationId) : base(reservationId) { }
}