using C_Project3.Data;
using C_Project3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace C_Project3.Controllers
{
    public class HomeController : Controller
    {
        private DbDataContext _dbContext;

        public HomeController(DbDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Books.Where(a=>a.Availability == true).ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Books.Find(id);

            _dbContext.Books.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BorrowBook(int id)
        {
            var book = _dbContext.Books.Find(id);
            book.Availability = false;

            var bookBorrow = new BookBorrowModel
            {
                BookId = book.Id,
                BookBorrowDate = DateTime.Now,
                //BookBorrowDate = DateTime.Now.AddDays(-18),
                BookInfo = book
            };

            _dbContext.BookBorrow.Add(bookBorrow);

            _dbContext.SaveChanges();
                

            return RedirectToAction("Index");
        }

        public IActionResult BorrowList()
        {
            var books = _dbContext.BookBorrow.Include(a=>a.BookInfo).ToList();
            foreach (var book in books)
            {
                var weekPassed = ((int)(DateTime.Now - book.BookBorrowDate).TotalDays / 7);
                book.PriceCharged = weekPassed;
            }

            _dbContext.SaveChanges();

            return View(books);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
