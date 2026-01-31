namespace Portfolio.SharedKernel.Entities;

public interface IAuditableEntity<TUserId>
{
    TUserId? CreatedBy { get; set; }
    DateTimeOffset? CreatedAt { get; set; }
    TUserId? UpdatedBy { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }
}
