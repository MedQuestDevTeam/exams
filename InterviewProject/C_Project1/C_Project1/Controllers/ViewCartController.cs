using C_Project1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_Project1.Controllers
{
    public class ViewCartController : Controller
    {
        private DbDataContext _dbContext;

        public ViewCartController(DbDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cartItem = _dbContext.Carts.Find(id);

            var product = _dbContext.Products.Find(cartItem.ProductId);
            product.ProductQuantity += cartItem.ProductQuantity;

            _dbContext.Carts.Remove(cartItem);
            _dbContext.SaveChanges();
            return RedirectToAction("ViewCart", "Home");
        }

        public IActionResult CheckOut()
        {

            var products = _dbContext.Products.ToList();
            var carts = _dbContext.Carts.ToList();
            foreach (var cartItem in carts)
            {
                var product = products.Find(a => a.Id == cartItem.ProductId);
                //product.ProductQuantity -= cartItem.ProductQuantity;
            }

            _dbContext.Carts.RemoveRange(carts);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
