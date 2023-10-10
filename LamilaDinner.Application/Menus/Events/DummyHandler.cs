using LamilaDinner.Domain.MenuAggregate.Events;
using MediatR;

namespace LamilaDinner.Application.Menus.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
