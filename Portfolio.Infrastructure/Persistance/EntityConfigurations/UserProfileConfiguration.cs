using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Domain.Users;

namespace Portfolio.Infrastructure.Persistance.EntityConfigurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        var userProfileIdConverter = new ValueConverter<UserProfileId, Guid>(
            profileId => profileId.Value,
            value => new UserProfileId(value));

        var userIdNullableConverter = new ValueConverter<UserId?, Guid?>(
            userId => userId == null ? null : userId.Value,
            value => value == null ? null : new UserId(value.Value));

        builder.HasKey(profile => profile.Id);

        builder
            .Property(profile => profile.Id)
            .HasConversion(userProfileIdConverter);

        builder
            .HasOne<ApplicationUser>()
            .WithOne()
            .HasForeignKey<UserProfile>("_userId")
            .IsRequired();

        builder
            .Property<Guid>("_userId")
            .HasColumnName("UserId")
            .IsRequired();

        builder
            .Property(profile => profile.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(profile => profile.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(profile => profile.CreatedBy)
            .HasConversion(userIdNullableConverter);

        builder
            .Property(profile => profile.UpdatedBy)
            .HasConversion(userIdNullableConverter);

        builder.
            Property(profile => profile.DateOfBirth)
            .HasColumnType("date")
            .IsRequired();

        builder
            .Property(profile => profile.Country)
            .HasMaxLength(2);

        builder
            .Property(profile => profile.Locale)
            .HasMaxLength(20);

        builder
            .Property(profile => profile.TimeZone)
            .HasMaxLength(64);

        builder.HasIndex("_userId").IsUnique().HasDatabaseName("IX_UserProfile_UserId");
        builder.HasIndex(profile => new { profile.FirstName }).HasDatabaseName("IX_UserProfile_FirstName");
        builder.HasIndex(profile => new { profile.LastName }).HasDatabaseName("IX_UserProfile_LastName");
    }
}
