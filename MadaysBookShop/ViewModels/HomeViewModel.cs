using MadaysBookShop.Models;

namespace MadaysBookShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> Books { get; }
        public string? CurrentCategory { get; }

        public HomeViewModel(IEnumerable<Book> books, string? currentCategory)
        {
            Books = books;
            CurrentCategory = currentCategory;
        }
    }
}