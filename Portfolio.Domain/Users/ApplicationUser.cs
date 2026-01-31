using Microsoft.AspNetCore.Identity;
using Portfolio.SharedKernel.Entities;

namespace Portfolio.Domain.Users;

public sealed class ApplicationUser : IdentityUser<Guid>, IAuditableEntity<UserId>
{
    public ApplicationUser()
    {
        Id = Guid.NewGuid();
    }

    public UserProfile? UserProfile { get; set; }
    public UserId? CreatedBy { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public UserId? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}