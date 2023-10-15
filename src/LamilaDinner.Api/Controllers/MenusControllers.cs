using LamilaDinner.Application.Menus.Commands.CreateMenu;
using LamilaDinner.Application.Menus.Queries;
using LamilaDinner.Contracts.Menus;
using LamilaDinner.Domain.HostAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LamilaDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusControllers : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public MenusControllers(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request,
    string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await _mediator.Send(command);

        return createMenuResult.Match(
            //menu => CreatedAtAction(nameof(GetMenu), new { hostId, menuId = menu.Id }, menu),
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors));
    }

    // [HttpGet]
    // public async Task<IActionResult> GetMenus(string hostId)
    // {
    //     var command = new GetMenusQuery(hostId);
    //     var menusResult = await _mediator.Send(command);
    //     return Ok();
    // }
}