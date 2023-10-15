using ErrorOr;
using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Domain.MenuAggregate;
using LamilaDinner.Domain.Common.Errors;
using MediatR;

namespace LamilaDinner.Application.Menus.Queries;

public class GetMenusQueryHandler : IRequestHandler<GetMenusQuery, ErrorOr<List<Menu>>>
{
    private readonly IMenuRepository _menuRepository;
    private readonly IHostRepository _hostRepository;

    public GetMenusQueryHandler(IMenuRepository menuRepository, IHostRepository hostRepository)
    {
        _menuRepository = menuRepository;
        _hostRepository = hostRepository;
    }
    public async Task<ErrorOr<List<Menu>>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var host = _hostRepository.GetHost(Guid.Parse(request.HostId));
        if (host is null)
        {
            return Errors.Host.CouldNotBeFound;
        }

        return await _menuRepository.GetMenus(host.Id.Value);
    }
}
