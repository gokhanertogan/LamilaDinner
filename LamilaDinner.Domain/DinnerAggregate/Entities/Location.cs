using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;

namespace LamilaDinner.Domain.DinnerAggregate.Entities;

public sealed class Location : Entity<LocationId>
{
    public string Name { get; }
    public string Description { get; }
    public string Latitude { get; }
    public string Longitude { get; }

    private Location(
        LocationId locationId,
        string name,
        string description,
        string latitude,
        string longitude) : base(locationId)
    {
        Name = name;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(
        string name,
        string description,
        string latitude,
        string longitude)
    {
        return new(
            LocationId.CreateUnique(),
            name,
            description,
            latitude,
            longitude
            );
    }
}
