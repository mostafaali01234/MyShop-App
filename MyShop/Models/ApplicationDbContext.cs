using Microsoft.EntityFrameworkCore;

namespace MyShop.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AccountTypes> AccountTypes { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<CartItem> CartItems { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<City> Cities { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetails> OrderDetails { set; get; }
        public DbSet<OrdersTransaction> OrdersTransactions { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductsReviews> ProductsReviews { set; get; }
        public DbSet<State> States { set; get; }
        public DbSet<User> Users { set; get; }
    }
}
