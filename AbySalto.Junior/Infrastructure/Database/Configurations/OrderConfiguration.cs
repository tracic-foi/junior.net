using AbySalto.Junior.Models.Entities;
using AbySalto.Junior.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbySalto.Junior.Infrastructure.Database.Configurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order> {
    public void Configure(EntityTypeBuilder<Order> builder) {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(x => x.CustomerName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.OrderTime)
            .IsRequired();
        builder.Property(x => x.PaymentType)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(x => x.CustomerAddress)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.CustomerNumber)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(x => x.Note)
            .HasMaxLength(250);
        builder.Property(x => x.Total)
            .IsRequired()
            .HasPrecision(19, 4);
        builder.Property(x => x.Currency)
            .IsRequired()
            .HasMaxLength(3);
        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
