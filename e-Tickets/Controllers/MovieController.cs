using e_Tickets.Data;
using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;
using e_Tickets.ViewModel;
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

        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(MovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Form", viewModel);
            _unitOfWork.Movie.Create(new Movie
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Picture = viewModel.Picture,
                CategoryId = viewModel.CategoryId,
                Price = viewModel.Price,
                CinemaId = viewModel.CinemaId,
                ProducerId = viewModel.ProducerId,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
            });
            _unitOfWork.Save();
            return Redirect(nameof(Index));
        }

        public async Task<IActionResult> Details(int id = 0)
        {
            if (id == 0)
                return NotFound();
            var obj = await _unitOfWork.Movie.GetAsync(id);
            return View(obj);
        }
    }
}