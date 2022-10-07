using e_Tickets.Data;
using e_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProducerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var objList = await _context.Producers.ToListAsync();
            return View(objList);
        }
    }
}