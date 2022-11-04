using MadaysBookShop.Models;
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
                (_bookRepository.AllBooks, "Romance");
            return View(bookListViewModel);
        }
    }
}
