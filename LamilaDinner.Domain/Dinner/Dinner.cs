using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Dinner.Entities;
using LamilaDinner.Domain.Host.ValueObjects;
using LamilaDinner.Domain.Menu.ValueObjects;

namespace LamilaDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();

    public string Name { get; }
    public string Description { get; }
    public DateTime EndedDateTime { get; }
    public DateTime StartedDateTime { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public string Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public string ImageUrl { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public Price Price { get; } = null!;
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public Location Location { get; } = null!;

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime endedDateTime,
        DateTime startedDateTime,
        DateTime startDateTime,
        DateTime endDateTime,
        string status,
        bool isPublic,
        int maxGuests,
        string imageUrl,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        HostId hostId,
        MenuId menuId
        ) : base(dinnerId)
    {
        Name = name;
        Description = description;
        EndedDateTime = endedDateTime;
        StartedDateTime = startedDateTime;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        ImageUrl = imageUrl;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        HostId = hostId;
        MenuId = menuId;
    }


    public static Dinner Create(
        string name,
        string description,
        string status,
        bool isPublic,
        int maxGuests,
        string imageUrl,
        HostId hostId,
        MenuId menuId)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            DateTime.UtcNow,
            DateTime.UtcNow,
            DateTime.UtcNow,
            DateTime.UtcNow,
            status,
            isPublic,
            maxGuests,
            imageUrl,
            DateTime.UtcNow,
            DateTime.UtcNow,
            hostId,
            menuId
            );
    }
}
