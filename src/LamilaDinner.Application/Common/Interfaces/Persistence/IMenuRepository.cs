using ErrorOr;
using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.MenuAggregate;

namespace LamilaDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
    Task<List<Menu>> GetMenus(Guid hostId);
}