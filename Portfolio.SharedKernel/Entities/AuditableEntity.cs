using Portfolio.SharedKernel.Entities;

namespace Portfolio.Domain.Users;

public abstract class AuditableEntity<TEntityId, TUserId> : Entity<TEntityId>, IAuditableEntity<TUserId>
{
    protected AuditableEntity(TEntityId id) : base(id) { }
    public TUserId? CreatedBy { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public TUserId? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}