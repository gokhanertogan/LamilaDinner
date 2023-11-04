using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Domain.HostAggregate;

namespace LamilaDinner.Infrastructure.Persistence.Repositories;

public class HostRepository : IHostRepository
{
    private readonly LamilaDinnerDbContext _dbContext;

    public HostRepository(LamilaDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Host GetHost(Guid id)
    {
        throw new NotImplementedException();
    }

    public void GetMenus(Guid guid)
    {
        throw new NotImplementedException();
    }
}