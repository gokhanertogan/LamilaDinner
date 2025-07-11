using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.MenuAggregate.ValueObjects;

namespace LamilaDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

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

#pragma warning disable CS8618
    private MenuItem()
    {

    }
#pragma warning restore CS8618
}
