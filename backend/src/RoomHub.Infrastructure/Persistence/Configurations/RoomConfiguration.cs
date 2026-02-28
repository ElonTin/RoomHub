using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomHub.Domain.Entities;
using RoomHub.Domain.Enums;

namespace RoomHub.Infrastructure.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoomNumber).HasMaxLength(50).IsRequired();
        builder.Property(r => r.RoomType)
            .HasConversion<string>()
            .HasColumnType("varchar(30)")
            .IsRequired();
        builder.Property(r => r.MaxCapacity).HasDefaultValue(2);
        builder.Property(r => r.SurfaceArea).HasColumnType("decimal(6,2)");
        builder.Property(r => r.BasePrice).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(r => r.Description).HasMaxLength(1024);
        builder.Property(r => r.IsFurnished).HasDefaultValue(true);
        builder.Property(r => r.Status)
            .HasConversion<string>()
            .HasColumnType("varchar(20)")
            .IsRequired();
        builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(r => r.IsDeleted).HasDefaultValue(false);

        builder.HasOne(r => r.Floor)
            .WithMany(f => f.Rooms)
            .HasForeignKey(r => r.FloorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => new { r.FloorId, r.RoomNumber })
            .IsUnique()
            .HasDatabaseName("UQ_RoomPerFloor");

        builder.HasIndex(r => new { r.Status, r.BasePrice })
            .HasDatabaseName("IX_Rooms_Status_Price");

        builder.HasIndex(r => r.RoomType)
            .HasDatabaseName("IX_Rooms_RoomType");
    }
}
