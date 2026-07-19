using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersWebApi.Models;

namespace OrdersWebApi.Database.Configurations;

public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(p => p.OrderItemId);


        builder.HasOne<Order>()
            .WithMany(p => p.OrderItems)
            .HasForeignKey(p => p.OrderId)
            .IsRequired();

        builder.Property(p => p.ProductName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Quantity)
            .IsRequired();

        builder.Property(p => p.UnitPrice)
            .IsRequired();

        builder.Property(p => p.TotalPrice)
            .IsRequired();
    }
}
