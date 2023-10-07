using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.MenuAggregate.ValueObjects;

namespace LamilaDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(
        string name,
        string description)
    {
        return new(
            MenuItemId.CreateUnique(),
            name,
            description);
    }
}
