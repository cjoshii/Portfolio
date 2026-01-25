using Portfolio.SharedKernel.DomainEvents;

namespace Portfolio.SharedKernel.Entities;

public abstract class Entity<TEntityId> : IEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(TEntityId id)
    {
        Id = id;
    }

    public TEntityId Id { get; init; }

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents => [.. _domainEvents];

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
