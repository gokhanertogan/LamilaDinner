using LamilaDinner.Domain.Common.Models;

namespace LamilaDinner.Domain.MenuAggregate.Events;

public record MenuCreated(Menu Menu) : IDomainEvent;