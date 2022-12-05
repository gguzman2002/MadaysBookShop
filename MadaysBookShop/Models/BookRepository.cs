using Microsoft.EntityFrameworkCore;

namespace MadaysBookShop.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly MadaysBookShopDbContext _madaysBookShopDbContext;

        public BookRepository(MadaysBookShopDbContext madaysBookShopDbContext)
        {
            _madaysBookShopDbContext = madaysBookShopDbContext;
        }

        public IEnumerable<Book> AllBooks
        {
            get
            {
                return _madaysBookShopDbContext.Books.Include(b => b.Category);
            }
        }

        public IEnumerable<Book> BooksOfTheWeek
        {
            get
            {
                return _madaysBookShopDbContext.Books.Include(b => b.Category).Where(b => b.IsBookOfTheWeek);
            }
        }

        public Book? GetBookById(int bookId)
        {
            return _madaysBookShopDbContext.Books.Include(b => b.Category).FirstOrDefault(b => b.BookId == bookId);
        }

        public IEnumerable<Book> SearchBooks(string searchQuery)
        {
            return _madaysBookShopDbContext.Books.Where(b => b.Name.Contains(searchQuery));
        }
    }
}
