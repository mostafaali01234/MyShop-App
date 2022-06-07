using Microsoft.EntityFrameworkCore;

namespace MyShop.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { set; get; }
        public DbSet<State> States { set; get; }
        public DbSet<City> Cities { set; get; }
        public DbSet<Order> Orders { set; get; }
    }
}
