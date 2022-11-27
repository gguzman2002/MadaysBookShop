using Microsoft.EntityFrameworkCore;

namespace MadaysBookShop.Models
{
    public class MadaysBookShopDbContext: DbContext
    {
        public MadaysBookShopDbContext(DbContextOptions<MadaysBookShopDbContext>
            options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
