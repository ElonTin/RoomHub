using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomHub.Domain.Entities;

namespace RoomHub.Infrastructure.Persistence.Configurations;

public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.ToTable("InvoiceItems");
        builder.HasKey(ii => ii.Id);

        builder.Property(ii => ii.ItemType).HasMaxLength(50).IsRequired();
        builder.Property(ii => ii.Description).HasMaxLength(256);
        builder.Property(ii => ii.Amount).HasColumnType("decimal(18,2)").IsRequired();

        builder.HasOne(ii => ii.Invoice)
            .WithMany(i => i.InvoiceItems)
            .HasForeignKey(ii => ii.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
