using Microsoft.EntityFrameworkCore;

namespace MadaysBookShop.Models
{
    public class MadaysBookShopDbContext: DbContext
    {
        public MadaysBookShopDbContext(DbContextOptions<MadaysBookShopDbContext>
            options) : base(options)
        {
        }
    }
}
