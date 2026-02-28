using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomHub.Domain.Entities;

namespace RoomHub.Infrastructure.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.IsModerated).HasDefaultValue(false);
        builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(r => r.Tenant)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.TenantId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(r => r.Room)
            .WithMany(rm => rm.Reviews)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(r => r.Owner)
            .WithMany()
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(r => r.Service)
            .WithMany(s => s.Reviews)
            .HasForeignKey(r => r.ServiceId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(r => r.RoomId).HasDatabaseName("IX_Reviews_RoomId");
        builder.HasIndex(r => r.OwnerId).HasDatabaseName("IX_Reviews_OwnerId");
        builder.HasIndex(r => r.ServiceId).HasDatabaseName("IX_Reviews_ServiceId");
    }
}
