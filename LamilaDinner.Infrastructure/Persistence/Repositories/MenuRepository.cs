using ErrorOr;
using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Domain.Common.Models;
using LamilaDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace LamilaDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly LamilaDinnerDbContext _dbContext;

    public MenuRepository(LamilaDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }

    public async Task<List<Menu>> GetMenus(Guid hostId)
    {
        return await _dbContext.Menus.Where(x => x.HostId.Value == hostId).ToListAsync();
    }
}
