using Portfolio.SharedKernel.DomainEvents;

namespace Portfolio.SharedKernel.Entities;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> GetDomainEvents { get; }
    void ClearDomainEvents();
}