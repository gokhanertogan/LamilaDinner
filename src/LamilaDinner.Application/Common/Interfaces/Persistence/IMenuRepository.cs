using LamilaDinner.Domain.MenuAggregate;

namespace LamilaDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}