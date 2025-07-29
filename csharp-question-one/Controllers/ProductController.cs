using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharp_question_one.Models;
using Microsoft.Extensions.Logging;
using csharp_question_one.Services;
using System.Linq;

namespace csharp_question_one.Controllers{

    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public List<ProductDetail> productList = new List<ProductDetail>{
            new ProductDetail{
                    Id = 1,
                    Name = "Apple",
                    Price = 1.2,
                    ProductInvInfo = new ProductInventoryInfo
                    {
                        Stock = 50,
                        Sold = 0
                    }
                },
                new ProductDetail{
                    Id = 2,
                    Name = "Orange",
                    Price = 0.9,
                    ProductInvInfo = new ProductInventoryInfo
                    {
                        Stock = 50,
                        Sold = 0
                    }
                },
                new ProductDetail{
                    Id = 3,
                    Name = "Banana",
                    Price = 0.5,
                    ProductInvInfo = new ProductInventoryInfo
                    {
                        Stock = 50,
                        Sold = 0
                    }
                }
        };
        private readonly CartService _cartService;
        public CartService CartService => _cartService;
        public ProductController(ILogger<ProductController> logger, CartService cartService){
            _logger = logger;
            _cartService = cartService;
            
        }
        public IActionResult Index(){
            ViewBag.CartService = _cartService;
            return View(productList);
        }
        
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = productList.FirstOrDefault(p => p.Id == productId);
            _logger.LogWarning("product Id : {Id}",product.Id);
            if (product != null)
            {
                _cartService.AddToCart(product, quantity);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ReduceQuantity(int productId)
        {
            _cartService.ReduceQuantity(productId);
            return RedirectToAction("ViewCart");
        }
        
        [HttpPost]
        public IActionResult AddQuantity(int productId, int quantity)
        {
            var product = productList.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _cartService.AddQuantity(product, quantity);
            }
            return RedirectToAction("ViewCart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var cartItems = _cartService.GetCartItems(productList);
            if(cartItems != null){
                _logger.LogWarning("There is cart data");
                _logger.LogWarning("size : {size}",cartItems.Count);
            
            }
            
            return View(cartItems);
        }
        public IActionResult Checkout()
        {
            productList = new List<ProductDetail>(_cartService.Checkout(productList));                    
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {   
            return View(productList);
        }
    }
}
