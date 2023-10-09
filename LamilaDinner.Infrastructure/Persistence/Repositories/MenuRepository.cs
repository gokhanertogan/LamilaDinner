using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Domain.MenuAggregate;

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
}
