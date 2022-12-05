using MadaysBookShop.Models;
using Microsoft.AspNetCore.Components;

namespace MadaysBookShop.Pages.App
{
    public partial class SearchBlazor
    {
        public string SearchText = "";

        public List<Book> FilteredBooks { get; set; } = new List<Book>();

        [Inject]
        public IBookRepository? BookRepository { get; set; }

        private void Search()
        {
            FilteredBooks.Clear();
            if (BookRepository is not null)
            {
                if (SearchText.Length >= 3)
                    FilteredBooks = BookRepository.SearchBooks(SearchText).ToList();
            }
        }
    }
}
