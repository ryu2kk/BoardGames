using BoardGames.Application.Common.Interfaces;
using BoardGames.Domain.Entities;
using BoardGames.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BoardGames.Web.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryController(IUnitOfWork unitOfWork) 
		{
			_unitOfWork = unitOfWork;		
		}
		public IActionResult Index()
		{
			var categorys = _unitOfWork.Category.GetAll();

			return View(categorys);
		}

        // CREATE 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
				_unitOfWork.Category.Add(obj);
				_unitOfWork.Save();

                TempData["success"] = "The category has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The category could not be created.";
            return View(obj);
        }

		// UPDATE
		public IActionResult Update(int categoryId)
		{
			Category? obj = _unitOfWork.Category.Get(u => u.Id == categoryId);

			//villa? obj2 = _db.Villas.Find(villaId);
			//var VillaList = _db.Villas.Where(_ => _.Price > 50 && _. Occupancy > 0);

			if (obj == null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Category obj)
		{

			if (ModelState.IsValid && obj.Id > 0)
			{
				_unitOfWork.Category.Update(obj);
				_unitOfWork.Save();

				TempData["success"] = "The category has been updated successfully.";
				return RedirectToAction(nameof(Index));
			}

			TempData["error"] = "The category could not be updated.";
			return View(obj);
		}

		// 3 - Delete
		//GET - este é para, depois de selecionar qual é aquele que quero eliminar, recebe o id 
		public IActionResult Delete(int categoryId)
		{
			//Aqui estou a aceder à bd, a comparar com o id que foi selecionado pelo clique do get
			Category? obj = _unitOfWork.Category.Get(x => x.Id == categoryId);

			if (obj is null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(obj);
		}


		// DELETE
		//POST - para gravar os dados atualizados depois de ele apagar
		[HttpPost]
		public IActionResult Delete(Category obj)
		{
			Category? objFromDb = _unitOfWork.Category.Get(_ => _.Id == obj.Id);

			if (objFromDb is not null)
			{
				_unitOfWork.Category.Remove(objFromDb);
				_unitOfWork.Save();              //vai ver que alterações foram preparadas e faz save na bd

				TempData["success"] = "Category has been deleted sucessfully!";
				return RedirectToAction(nameof(Index));
			}

			TempData["error"] = "Category could not be deleted!";
			return View(obj);
		}
	}
}
