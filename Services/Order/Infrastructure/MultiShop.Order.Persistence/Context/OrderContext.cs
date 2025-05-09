using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1440;Initial Catalog=MultiShopOrderDb;User=sa;Password=123456aA*;TrustServerCertificate=True;");

    }

    DbSet<Address> Addresses { get; set; }
    DbSet<OrderDetail> OrderDetails { get; set; }
    DbSet<Ordering> Orderings { get; set; }
}
