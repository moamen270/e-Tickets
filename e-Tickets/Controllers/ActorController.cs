using e_Tickets.Data;
using e_Tickets.Data.Repository.IRepository;
using e_Tickets.Models;
using e_Tickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var objList = await _unitOfWork.Actor.GetAllAsync();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(ActorViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Form", viewModel);
            _unitOfWork.Actor.Create(new Actor
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