using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}