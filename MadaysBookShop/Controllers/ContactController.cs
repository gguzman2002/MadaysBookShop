using Microsoft.AspNetCore.Mvc;

namespace MadaysBookShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
