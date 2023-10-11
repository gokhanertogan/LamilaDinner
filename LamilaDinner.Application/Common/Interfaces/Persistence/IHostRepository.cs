using LamilaDinner.Domain.HostAggregate;
using LamilaDinner.Domain.MenuAggregate;

namespace LamilaDinner.Application.Common.Interfaces.Persistence;

public interface IHostRepository
{
    Host GetHost(Guid id);
    void GetMenus(Guid guid);
}