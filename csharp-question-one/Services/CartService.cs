using System;
using System.Collections.Generic;
using System.Linq;
using csharp_question_one.Models;
using Microsoft.Extensions.Logging;

namespace csharp_question_one.Services
{
    public class CartService
    {
        public List<CartItem> cartList = new List<CartItem>();
        private readonly ILogger<CartService> _logger;

        public CartService(ILogger<CartService> logger)
        {
            _logger = logger;
        }
        public void AddToCart(ProductDetail product, int quantity)
        {
            var cartItem = cartList.FirstOrDefault(item => item.Product.Id == product.Id);
            if (cartItem != null)
            {
                if (cartItem.Quantity + quantity > product.ProductInvInfo.Stock)
                {
                    cartItem.Quantity = product.ProductInvInfo.Stock;
                }
                else
                {
                    cartItem.Quantity += quantity;
                }
            }
            else
            {
                cartList.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public void ReduceQuantity(int productId)
        {
            var cartItem = cartList.FirstOrDefault(item => item.Product.Id == productId);
            if (cartItem != null && cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
        }

        public void AddQuantity(ProductDetail product, int quantity)
        {
            var cartItem = cartList.FirstOrDefault(item => item.Product.Id == product.Id);
            var maxAvailableQuantity = GetMaxAvailableQuantity(product);
            if (cartItem != null && cartItem.Quantity < maxAvailableQuantity)
            {
                cartItem.Quantity += quantity;
            }
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = cartList.FirstOrDefault(item => item.Product.Id == productId);
            if (cartItem != null)
            {
                cartList.Remove(cartItem);
            }
        }

        public List<CartItem> GetCartItems(List<ProductDetail> productList)
        {
            return cartList.Select(cartItem => new CartItem
            {
                Product = productList.FirstOrDefault(p => p.Id == cartItem.Product.Id),
                Quantity = cartItem.Quantity
            }).ToList();
        }

        public int GetMaxAvailableQuantity(ProductDetail product)
        {
            return product != null ? product.ProductInvInfo.Stock : 0;
        }

        internal List<ProductDetail> Checkout(List<ProductDetail> productList)
        {
            List<ProductDetail> updateProductList = new List<ProductDetail>();
            foreach (var cartItem in cartList){
                var product = productList.FirstOrDefault(p => p.Id == cartItem.Product.Id);
                if (product != null && product.ProductInvInfo != null){
                    
                    int newStock = product.ProductInvInfo.Stock - cartItem.Quantity;
                    int newSold = product.ProductInvInfo.Sold + cartItem.Quantity;
                    _logger.LogWarning("AFter Product Stock {st}",newStock);
                    _logger.LogWarning("AFter Product Sold {so}",newSold);
                    ProductDetail updateProduct = new ProductDetail{
                        Id = product.Id,
                        Name = product.Name,
                        ProductInvInfo = new ProductInventoryInfo{
                            Stock = newStock,
                            Sold = newSold
                        }
                    };
                    updateProductList.Add(updateProduct);
                }
            }

            foreach (var item in updateProductList)
                {
                    _logger.LogWarning("in Loop");
                    _logger.LogWarning("updateProductList Show Product Id {d}",item.Id);
                    _logger.LogWarning("updateProductList Show Product Name {n}",item.Name);
                    _logger.LogWarning("updateProductList Show Product Stock {st}",item.ProductInvInfo.Stock);
                    _logger.LogWarning("updateProductList Show Product Sold {so}",item.ProductInvInfo.Sold);
                }
            cartList.Clear();
            return updateProductList;
        }
    }
}
