using e_Tickets.Data;
using e_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace e_Tickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var objList = await _context.Movies.Include(m => m.Category).Include(m => m.Producer).Include(m => m.Cinema).OrderBy(m => m.Name).ToListAsync();
            return View(objList);
        }
    }
}