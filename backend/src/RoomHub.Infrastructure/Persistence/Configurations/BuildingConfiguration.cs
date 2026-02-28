using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomHub.Domain.Entities;

namespace RoomHub.Infrastructure.Persistence.Configurations;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.ToTable("Buildings");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).HasMaxLength(256).IsRequired();
        builder.Property(b => b.Province).HasMaxLength(128);
        builder.Property(b => b.City).HasMaxLength(128).IsRequired();
        builder.Property(b => b.District).HasMaxLength(128).IsRequired();
        builder.Property(b => b.Ward).HasMaxLength(128).IsRequired();
        builder.Property(b => b.Address).HasMaxLength(512).IsRequired();
        builder.Property(b => b.Latitude).HasColumnType("decimal(9,6)");
        builder.Property(b => b.Longitude).HasColumnType("decimal(9,6)");
        builder.Property(b => b.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(b => b.IsDeleted).HasDefaultValue(false);

        builder.HasOne(b => b.Owner)
            .WithMany(u => u.Buildings)
            .HasForeignKey(b => b.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(b => new { b.City, b.District, b.Ward })
            .HasDatabaseName("IX_Buildings_Location");
    }
}
