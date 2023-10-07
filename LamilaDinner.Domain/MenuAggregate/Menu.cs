using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Common.ValueObjects;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;
using LamilaDinner.Domain.HostAggregate.ValueObjects;
using LamilaDinner.Domain.MenuAggregate.Entities;
using LamilaDinner.Domain.MenuAggregate.ValueObjects;
using LamilaDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace LamilaDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinners = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; } = null!;

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        List<MenuSection> sections,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
