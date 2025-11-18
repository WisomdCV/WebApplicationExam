using LAB08WILSONDCV.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08WILSONDCV.Data
{
    //Hereda de DbContext, que es la clase base de EF Core.
    public class LinqDbContext : DbContext
    {
        public LinqDbContext(DbContextOptions<LinqDbContext> options) : base(options)
        {
        }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}