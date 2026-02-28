using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomHub.Domain.Entities;

namespace RoomHub.Infrastructure.Persistence.Configurations;

public class TenantProfileConfiguration : IEntityTypeConfiguration<TenantProfile>
{
    public void Configure(EntityTypeBuilder<TenantProfile> builder)
    {
        builder.ToTable("TenantProfiles");
        builder.HasKey(t => t.UserId);

        builder.Property(t => t.CCCDNumber).HasMaxLength(20);
        builder.Property(t => t.PassportNumber).HasMaxLength(20);
        builder.Property(t => t.IdentityDocumentPath).HasMaxLength(512);
        builder.Property(t => t.SelfiePath).HasMaxLength(512);

        builder.HasOne(t => t.User)
            .WithOne(u => u.TenantProfile)
            .HasForeignKey<TenantProfile>(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
