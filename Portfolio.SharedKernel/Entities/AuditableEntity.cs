namespace Portfolio.SharedKernel.Entities;

public abstract class AuditableEntity<TEntityId, TUserId> : Entity<TEntityId>, IAuditableEntity<TUserId>
where TEntityId : class
{
    public AuditableEntity(TEntityId id) : base(id)
    {
    }
    public TUserId? CreatedBy { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public TUserId? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
