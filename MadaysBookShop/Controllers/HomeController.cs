using MadaysBookShop.Models;
using MadaysBookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MadaysBookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        private readonly ICategoryRepository _categoryRepository;
        public HomeController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel(_bookRepository.AllBooks, "All books");

            return View(homeViewModel);

        }
    }
}