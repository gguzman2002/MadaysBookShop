namespace MadaysBookShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MadaysBookShopDbContext _madaysBookShopDbContext;

        public CategoryRepository(MadaysBookShopDbContext madaysBookShopDbContext)
        {
            _madaysBookShopDbContext = madaysBookShopDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _madaysBookShopDbContext.Categories.OrderBy(c => c.CategoryName);
    }
}
