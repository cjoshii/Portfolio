namespace Portfolio.SharedKernel.Entities;

public abstract class AuditableEntity<TEntityId> : Entity<TEntityId>, IAuditableEntity
where TEntityId : class
{
    public AuditableEntity(TEntityId id) : base(id)
    {
    }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
