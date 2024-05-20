using BookRent.DataAccess.Data;
using BookRent.DataAccess.Repository.IRepository;
using BookRent.Models;
using BookRent.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookRent.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductController(IUnitOfWork db)
        {
            unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Product> products = unitOfWork.ProductRepository.GetAll().ToList();
            return View(products);
        }
    }
}
