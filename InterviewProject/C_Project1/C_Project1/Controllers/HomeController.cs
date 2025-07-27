using C_Project1.Data;
using C_Project1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace C_Project1.Controllers
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
            var products = _dbContext.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null) return NotFound();

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (_dbContext.Carts.Any(a=>a.ProductId == id))
            {
                var cartItem = _dbContext.Carts.Where(a=>a.ProductId == id).FirstOrDefault();
                cartItem.ProductQuantity += 1;
                //_dbContext.Carts.Update(cartItem);
            }
            else
            {
                ProductCartModel cart = new ProductCartModel
                {
                    ProductId = id,
                    ProductQuantity = 1
                };
                _dbContext.Carts.Add(cart);
            }

            product.ProductQuantity -= 1;

            _dbContext.SaveChanges();
                

            return RedirectToAction("Index");
        }

        public IActionResult ViewCart()
        {
            var cartItems = _dbContext.Carts.Include(c => c.Product).ToList();
            return View(cartItems);
        }

        public IActionResult AddProduct()
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
