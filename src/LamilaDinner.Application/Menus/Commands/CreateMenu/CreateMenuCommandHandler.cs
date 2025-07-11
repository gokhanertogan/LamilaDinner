using ErrorOr;
using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Domain.HostAggregate.ValueObjects;
using LamilaDinner.Domain.MenuAggregate;
using LamilaDinner.Domain.MenuAggregate.Entities;
using MediatR;

namespace LamilaDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
        name: request.Name,
        description: request.Description,
        hostId: HostId.Create(Guid.Parse(request.HostId)),
        sections: request.Sections.ConvertAll(section => MenuSection.Create(
            section.Name,
            section.Description,
            section.Items.ConvertAll(item => MenuItem.Create(
                item.Name,
                item.Description)))));

        _menuRepository.Add(menu);
        return menu;
    }
}
