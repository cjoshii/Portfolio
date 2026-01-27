using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Domain.Users;

namespace Portfolio.Infrastructure.Persistance.EntityConfigurations;

public sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var userIdNullableConverter = new ValueConverter<UserId?, Guid?>(
            userId => userId == null ? null : userId.Value,
            value => value == null ? null : new UserId(value.Value));

        builder
            .Property(user => user.CreatedBy)
            .HasConversion(userIdNullableConverter);

        builder
            .Property(user => user.UpdatedBy)
            .HasConversion(userIdNullableConverter);
    }
}
