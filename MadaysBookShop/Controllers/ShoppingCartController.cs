using MadaysBookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace MadaysBookShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IBookRepository bookRepository, IShoppingCart shoppingCart)
        {
            _bookRepository = bookRepository;
            _shoppingCart = shoppingCart;
        }
    }
}
