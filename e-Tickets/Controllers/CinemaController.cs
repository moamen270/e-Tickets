using e_Tickets.Data;
using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;
using e_Tickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CinemaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var objList = await _unitOfWork.Cinema.GetAllAsync();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(CinemaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Form", viewModel);
            _unitOfWork.Cinema.Create(new Cinema
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Logo = viewModel.Logo
            });
            _unitOfWork.Save();
            return Redirect(nameof(Index));
        }

        public async Task<IActionResult> Details(int id = 0)
        {
            if (id == 0)
                return NotFound();
            var obj = await _unitOfWork.Cinema.GetAsync(id);
            return View(obj);
        }
    }
}