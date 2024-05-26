using BoardGames.Application.Common.Interfaces;
using BoardGames.Domain.Entities;
using BoardGames.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoardGames.Web.Controllers
{
	public class GameController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public GameController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult Index()
		{
			var games = _unitOfWork.Game.GetAll(includeProperties: "Category"); 

			return View(games);
		}

        // CREATE 
        public IActionResult Create()
        {
			GameVM gameVM = new()
			{

				CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				})
			};

            return View(gameVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GameVM obj)
        {

			bool nameExists = _unitOfWork.Game.Any(u => u.Name == obj.Game.Name);

            if (ModelState.IsValid && !nameExists)
            {
				//File Upload
				if (obj.Game.Image != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Game.Image.FileName);
					string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\GameImages");
					using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
					obj.Game.Image.CopyTo(fileStream);

					obj.Game.ImageUrl = @"\images\GameImages\" + fileName;
				}
				else
				{
					obj.Game.ImageUrl = "https://placehold.co/600x400";
				}

				_unitOfWork.Game.Add(obj.Game);
                _unitOfWork.Save();

                TempData["success"] = "The game has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

			if (nameExists)
			{
				TempData["error"] = "The name already exists.";
			}

			obj.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			});

			return View(obj);
        }

		// UPDATE
		public IActionResult Update(int gameId)
		{
			GameVM gameVM = new()
			{

				CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Game = _unitOfWork.Game.Get(_=>_.Id == gameId)
			};

			if (gameVM.Game == null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(gameVM);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(GameVM gameVM)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.Game.Update(gameVM.Game);
				_unitOfWork.Save();

				TempData["success"] = "The game has been updated successfully.";
				return RedirectToAction(nameof(Index));
			}

			gameVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			});

			return View(gameVM);
		}

		// 3 - Delete
		//GET - este é para, depois de selecionar qual é aquele que quero eliminar, recebe o id 
		public IActionResult Delete(int gameId)
		{
			GameVM gameVM = new()
			{

				CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Game = _unitOfWork.Game.Get(_ => _.Id == gameId)
			};

			if (gameVM.Game == null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(gameVM);
		}


		// DELETE
		//POST - para gravar os dados atualizados depois de ele apagar
		[HttpPost]
		public IActionResult Delete(GameVM gameVM)
		{
			Game? objFromDb = _unitOfWork.Game.Get(_ => _.Id == gameVM.Game.Id);

			if (objFromDb is not null)
			{
				_unitOfWork.Game.Remove(objFromDb);
				_unitOfWork.Save();              //vai ver que alterações foram preparadas e faz save na bd

				TempData["success"] = "Game has been deleted sucessfully!";
				return RedirectToAction(nameof(Index));
			}

			TempData["error"] = "Game could not be deleted!";
			return View(gameVM);
		}
	}
}
