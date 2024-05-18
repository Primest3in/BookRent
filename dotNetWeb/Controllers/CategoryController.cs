using BookRent.DataAccess.Data;
using BookRent.DataAccess.Repository.IRepository;
using BookRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookRent.Controllers
{

    
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository db)
        {
            categoryRepository = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.GetAll().ToList();
            return View(categories);
        }
        public IActionResult CreateNewCategory()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult CreateNewCategory(Category obj)
        {
            if(ModelState.IsValid) {
                categoryRepository.Add(obj);
                categoryRepository.Save();

                TempData["success"] = "New category added successfully";
                return RedirectToAction("Index");
            }
            return View();  
        }

        
        public IActionResult EditEntry(int? id) {
            if (id == null)
            {
                return NotFound();
            }
            Category? category = categoryRepository.Get(u => u.Id == id);
           
            if (category == null) {
                return NotFound();
            }
            



            return View(category);
        }
        [HttpPost]
        public IActionResult EditEntry(Category obj)
        {

            if (ModelState.IsValid)
            {
                categoryRepository.Update(obj);
                categoryRepository.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();




        }

        public IActionResult Delete(int ob)
        {
            Category category = categoryRepository.Get(u => u.Id == ob);
            if (category != null)
            {
                categoryRepository.Delete(category);
                categoryRepository.Save();

                TempData["success"] = "Category deleted successfully";
            }
            return RedirectToAction("Index");
        }

    }
}
