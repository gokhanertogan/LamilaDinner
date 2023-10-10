namespace LamilaDinner.Domain.Common.Models;

public interface IHasDomainEvent
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    public void ClearDomainEvents();
}