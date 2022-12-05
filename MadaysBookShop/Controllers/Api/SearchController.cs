using MadaysBookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MadaysBookShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public SearchController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allBooks = _bookRepository.AllBooks;
            return Ok(allBooks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_bookRepository.AllBooks.Any(b => b.BookId == id))
                return NotFound();
            return Ok(_bookRepository.AllBooks.Where(b => b.BookId == id));
        }

        [HttpPost]
        public IActionResult SearchBooks([FromBody] string searchQuery)
        {
            IEnumerable<Book> books = new List<Book>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                books = _bookRepository.SearchBooks(searchQuery);
            }
            return new JsonResult(books);
        }
    }
}
