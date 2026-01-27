using Microsoft.AspNetCore.Identity;
using Portfolio.SharedKernel.DomainEvents;
using Portfolio.SharedKernel.Entities;

namespace Portfolio.Domain.Users;

public sealed class ApplicationUser : IdentityUser<Guid>, IAuditableEntity<UserId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public ApplicationUser()
    {
        Id = Guid.NewGuid();
    }

    public UserId? CreatedBy { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public UserId? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

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
