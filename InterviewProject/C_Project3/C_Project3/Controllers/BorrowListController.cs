using C_Project3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_Project3.Controllers
{
    public class BorrowListController : Controller
    {
        private DbDataContext _dbContext;

        public BorrowListController(DbDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var books = _dbContext.BookBorrow.Include(a => a.BookInfo).ToList();
            foreach (var book in books)
            {
                var weekPassed = ((int)(DateTime.Now - book.BookBorrowDate).TotalDays / 7);
                book.PriceCharged = weekPassed;
            }

            _dbContext.SaveChanges();

            return View(books);
        }

        [HttpPost]
        public IActionResult Return(int id)
        {
            var bookBorrow = _dbContext.BookBorrow.Find(id);

            var book = _dbContext.Books.Find(bookBorrow.BookId);
            book.Availability = true;

            _dbContext.BookBorrow.Remove(bookBorrow);
            _dbContext.SaveChanges();
            return RedirectToAction("BorrowList", "Home");
        }

    }
}
