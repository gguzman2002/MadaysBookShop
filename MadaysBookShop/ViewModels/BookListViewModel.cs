﻿using MadaysBookShop.Models;

namespace MadaysBookShop.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; }
        public string? CurrentCategory { get; }

        public BookListViewModel(IEnumerable<Book> books, string? currentCategory)
        {
            Books = books;
            CurrentCategory = currentCategory;
        }
    }
}
