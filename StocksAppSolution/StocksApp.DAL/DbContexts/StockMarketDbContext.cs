using Microsoft.EntityFrameworkCore;
using StocksApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.DAL.DbContexts;

public class StockMarketDbContext(DbContextOptions<StockMarketDbContext> options) : DbContext(options)
{
    public DbSet<BuyOrder> BuyOrders { get; set; }
    public DbSet<SellOrder> SellOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BuyOrder>(entity =>
        {
            entity.ToTable("BuyOrders");
            entity.Property(e => e.BuyOrderID).ValueGeneratedOnAdd();
            entity.Property(s => s.Price)
                .HasColumnType("decimal(9,2)");
        });

        modelBuilder.Entity<SellOrder>(entity =>
        {
            entity.ToTable("SellOrders");
            entity.Property(e => e.SellOrderID).ValueGeneratedOnAdd();
            entity.Property(s => s.Price)
                .HasColumnType("decimal(9,2)");
        });
    }
}
