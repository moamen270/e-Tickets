using e_Tickets.Data;
using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;
using e_Tickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var objList = await _unitOfWork.Category.GetAllAsync();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Form", viewModel);
            _unitOfWork.Category.Create(new Category
            {
                Name = viewModel.Name
            });
            _unitOfWork.Save();
            return Redirect(nameof(Index));
        }

        public async Task<IActionResult> Details(int id = 0)
        {
            if (id == 0)
                return NotFound();
            var obj = await _unitOfWork.Producer.GetAsync(id);
            return View(obj);
        }
    }
}