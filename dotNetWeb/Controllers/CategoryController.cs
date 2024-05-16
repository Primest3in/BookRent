using dotNetWeb.DataAccess.Data;
using dotNetWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetWeb.Controllers
{

    
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
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
                _db.Categories.Add(obj);
                _db.SaveChanges();

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
            Category? category = _db.Categories.Find(id);
           
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
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();




        }

        public IActionResult Delete(int ob)
        {
            Category category = _db.Categories.Find(ob);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();

                TempData["success"] = "Category deleted successfully";
            }
            return RedirectToAction("Index");
        }

    }
}
