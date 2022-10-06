using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}