using DataDomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class ShopContext:DbContext
    {
        public ShopContext() : base(BuildConnection("Server=DESKTOP-KJE6FQD;Database=shopdb;User Id=sa;Password=test;"))
        {
        }

        private static DbContextOptions BuildConnection(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<Stock>(s => s.STOCK)
                .WithOne(p => p.PRODUCT)
                .HasForeignKey<Product>(p =>p.STOCKID);

            modelBuilder.Entity<Order>()
                .HasOne<Customer>(c => c.CUSTOMER)
                .WithMany(o => o.ORDER)
                .HasForeignKey(o => o.CUSTOMERID);

            modelBuilder.Entity<Order>()
                .HasMany<OrderRow>(or => or.ORDERROW)
                .WithOne(o => o.ORDER)
                .HasForeignKey(o => o.ORDERID);
        }*/
   
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderRow> OrderRows { get; set; }

        public DbSet<Stock> Stocks { get; set; }

    }
}
