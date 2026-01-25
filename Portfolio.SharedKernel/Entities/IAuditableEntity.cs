namespace Portfolio.SharedKernel.Entities;

public interface IAuditableEntity : IEntity
{
    string? CreatedBy { get; set; }
    DateTime? CreatedAt { get; set; }
    string? UpdatedBy { get; set; }
    DateTime? UpdatedAt { get; set; }
}