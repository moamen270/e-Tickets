using e_Tickets.Data;
using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;
using e_Tickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProducerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var objList = await _unitOfWork.Producer.GetAllAsync();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(ProducerViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Form", viewModel);
            _unitOfWork.Producer.Create(new Producer
            {
                Name = viewModel.Name,
                Bio = viewModel.Bio,
                Picture = viewModel.Picture
            });
            _unitOfWork.Save();
            return Redirect(nameof(Index));
        }
    }
}