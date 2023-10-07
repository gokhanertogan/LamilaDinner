using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Domain.MenuAggregate;

namespace LamilaDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}
