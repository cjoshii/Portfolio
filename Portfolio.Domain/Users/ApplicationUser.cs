using Microsoft.AspNetCore.Identity;
using Portfolio.SharedKernel.DomainEvents;
using Portfolio.SharedKernel.Entities;

namespace Portfolio.Domain.Users;

public sealed class ApplicationUser : IdentityUser<Guid>, IAuditableEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public ApplicationUser()
    {
        Id = Guid.NewGuid();
    }

    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }

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
