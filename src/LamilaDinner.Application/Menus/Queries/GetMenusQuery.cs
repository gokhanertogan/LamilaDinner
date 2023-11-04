using ErrorOr;
using LamilaDinner.Domain.MenuAggregate;
using MediatR;

namespace LamilaDinner.Application.Menus.Queries;

public record GetMenusQuery(string HostId) : IRequest<ErrorOr<List<Menu>>>;