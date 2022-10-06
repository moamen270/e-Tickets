using e_Tickets.Data;
using e_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objList = _context.Set<Actor>().ToList();
            return View(objList);
        }
    }
}