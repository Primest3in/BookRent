using BookRent.DataAccess.Data;
using BookRent.DataAccess.Repository.IRepository;
using BookRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookRent.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryController(IUnitOfWork db)
        {
            unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = unitOfWork.CategoryRepository.GetAll().ToList();
            return View(categories);
        }
        public IActionResult CreateNewCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewCategory(Category obj)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CategoryRepository.Add(obj);
                unitOfWork.Save();

                TempData["success"] = "New category added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult EditEntry(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? category = unitOfWork.CategoryRepository.Get(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }




            return View(category);
        }
        [HttpPost]
        public IActionResult EditEntry(Category obj)
        {

            if (ModelState.IsValid)
            {
                unitOfWork.CategoryRepository.Update(obj);
                unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();




        }

        public IActionResult Delete(int ob)
        {
            Category category = unitOfWork.CategoryRepository.Get(u => u.Id == ob);
            if (category != null)
            {
                unitOfWork.CategoryRepository.Delete(category);
                unitOfWork.Save();

                TempData["success"] = "Category deleted successfully";
            }
            return RedirectToAction("Index");
        }

    }
}
