﻿using MadaysBookShop.Models;
using MadaysBookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MadaysBookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        private readonly ICategoryRepository _categoryRepository;

        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        //public IActionResult List()
        //{
        //    BookListViewModel bookListViewModel = new BookListViewModel
        //        (_bookRepository.AllBooks, "All books");
        //    return View(bookListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Book> books;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                books = _bookRepository.AllBooks.Where(b => b.Category.CategoryName == category)
                    .OrderBy(b => b.BookId);
                currentCategory = "All books";
            }
            else
            {
                books = _bookRepository.AllBooks.Where(b => b.Category.CategoryName == category)
                    .OrderBy(b => b.BookId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)
                    ?.CategoryName;
            }

            return View(new BookListViewModel(books, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();
            return View(book);
        }
    }
}
