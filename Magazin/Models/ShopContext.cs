using Microsoft.EntityFrameworkCore;

namespace Magazin.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }

       
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Log> Logs { get; set; }
       

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
