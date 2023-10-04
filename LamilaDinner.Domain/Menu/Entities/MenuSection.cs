using LamilaDinner.Domain.Menu.ValueObjects;
using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.Menu.Entities;

namespace LamilaDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; }
    public string Description { get; }
    IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }
}
