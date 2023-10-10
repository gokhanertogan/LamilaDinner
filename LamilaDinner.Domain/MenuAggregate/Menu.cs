using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Common.ValueObjects;
using LamilaDinner.Domain.DinnerAggregate.ValueObjects;
using LamilaDinner.Domain.HostAggregate.ValueObjects;
using LamilaDinner.Domain.MenuAggregate.Entities;
using LamilaDinner.Domain.MenuAggregate.Events;
using LamilaDinner.Domain.MenuAggregate.ValueObjects;
using LamilaDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace LamilaDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinners = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; } = null!;
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; private set; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> sections) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
        AverageRating = averageRating;
    }

    public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(),
            sections ?? new());

        
        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;             
    }

#pragma warning disable CS8618
    private Menu()
    {

    }
#pragma warning restore CS8618
}
