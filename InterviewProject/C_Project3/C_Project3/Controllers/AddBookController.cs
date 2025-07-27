using C_Project3.Data;
using C_Project3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_Project3.Controllers
{
    public class AddBookController : Controller
    {
        private DbDataContext _dbContext;

        public AddBookController(DbDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookInfoModel product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(product);
        }
    }
}
