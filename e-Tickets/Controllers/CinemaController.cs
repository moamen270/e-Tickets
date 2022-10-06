using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}