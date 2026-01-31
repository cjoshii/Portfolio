using Portfolio.SharedKernel.DomainEvents;

namespace Portfolio.SharedKernel.Entities;

public abstract class AggregateRoot<TEntityId>
    : Entity<TEntityId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot(TEntityId id) : base(id) { }

    protected void Raise(IDomainEvent domainEvent)
        => _domainEvents.Add(domainEvent);

    public IReadOnlyCollection<IDomainEvent> DomainEvents
        => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
        => _domainEvents.Clear();
}