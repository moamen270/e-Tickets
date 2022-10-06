using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class ProducerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}