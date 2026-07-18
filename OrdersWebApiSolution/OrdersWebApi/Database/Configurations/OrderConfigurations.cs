using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersWebApi.Models;

namespace OrdersWebApi.Database.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(p => p.OrderId);

        builder.Property(p => p.OrderNumber)
            .IsRequired();

        builder.Property(p => p.CustomerName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p => p.OrderDate)
            .IsRequired();

        builder.Property(p => p.TotalAmount)
            .IsRequired();

    }
}
