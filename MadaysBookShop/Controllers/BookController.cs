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

        public IActionResult List()
        {
            BookListViewModel bookListViewModel = new BookListViewModel
                (_bookRepository.AllBooks, "All books");
            return View(bookListViewModel);
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
