using System;

namespace Portfolio.SharedKernel.Entities;

public abstract class AuditableAggregateRoot<TEntityId, TUserId>
: AggregateRoot<TEntityId>, IAuditableEntity<TUserId>
{
    protected AuditableAggregateRoot(TEntityId id) : base(id)
    {
    }
    public TUserId? CreatedBy { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public TUserId? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
