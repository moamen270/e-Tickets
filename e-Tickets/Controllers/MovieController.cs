using e_Tickets.Data;
using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace e_Tickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var objList = await _unitOfWork.Movie.GetAllAsync(m => m.Category, m => m.Cinema);
            return View(objList);
        }
    }
}