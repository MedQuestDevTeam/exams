using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOnlineStore
{
    namespace OnlineStore
    {
        public class ShoppingCart
        {
            private List<ShoppingCartItem> items = new List<ShoppingCartItem>();

            public void AddToCart(Product product, int quantity)
            {
                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than zero.");
                    return;
                }

                if (product.Inventory < quantity)
                {
                    Console.WriteLine($"Not enough inventory for {product.Name}. Available: {product.Inventory}");
                    return;
                }

                var existingItem = items.FirstOrDefault(i => i.Product == product);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    items.Add(new ShoppingCartItem { Product = product, Quantity = quantity });
                }

                product.Inventory -= quantity;
                Console.WriteLine($"{quantity} x {product.Name} added to cart.");
            }

            public void RemoveFromCart(string productName)
            {
                var item = items.FirstOrDefault(i => i.Product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
                if (item != null)
                {
                    item.Product.Inventory += item.Quantity;
                    items.Remove(item);
                    Console.WriteLine($"{item.Product.Name} removed from cart.");
                }
                else
                {
                    Console.WriteLine($"{productName} not found in cart.");
                }
            }

            public void ViewCart()
            {
                Console.WriteLine("\n--- Current Cart ---");
                if (!items.Any())
                {
                    Console.WriteLine("Cart is empty.");
                    return;
                }

                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Product.Name} x {item.Quantity} = {item.TotalPrice:C}");
                }
            }

            public void Checkout()
            {
                if (!items.Any())
                {
                    Console.WriteLine("Cart is empty. Nothing to checkout.");
                    return;
                }

                Console.WriteLine("\n--- Checkout Summary ---");
                decimal total = 0;
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Quantity} x {item.Product.Name} = {item.TotalPrice:C}");
                    total += item.TotalPrice;
                }

                Console.WriteLine($"Total: {total:C}");
                items.Clear();
                Console.WriteLine("Thank you for your purchase!");
            }
        }
    }
}
