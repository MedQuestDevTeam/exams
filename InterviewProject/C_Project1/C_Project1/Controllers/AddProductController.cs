using C_Project1.Data;
using C_Project1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_Project1.Controllers
{
    public class AddProductController : Controller
    {
        private DbDataContext _dbContext;

        public AddProductController(DbDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductInfoModel product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(product);
        }
    }
}
