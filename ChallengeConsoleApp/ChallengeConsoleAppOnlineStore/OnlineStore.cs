using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeConsoleAppOnlineStore
{
    // Represents a product in the store
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }

        public Product(int id, string name, decimal price, int inventory)
        {
            ProductId = id;
            Name = name;
            Price = price;
            Inventory = inventory;
        }
    }

    // Represents an item inside the shopping cart
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }

    // Manages the user's cart and checkout process
    public class ShoppingCart
    {
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = new List<CartItem>();
        }

        // Add a product to the cart
        public void AddProduct(Product product, int quantity = 1)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            // Check if there is enough inventory in the store
            if (product.Inventory < quantity)
                throw new InvalidOperationException($"Not enough inventory for {product.Name}. Only {product.Inventory} left.");

            var existingItem = _items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);

            if (existingItem != null)
            {
                // Ensure adding more doesn't exceed total inventory
                if (product.Inventory < existingItem.Quantity + quantity)
                    throw new InvalidOperationException($"Cannot add {quantity} more of {product.Name}. Stock exceeded.");

                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = quantity });
            }

            Console.WriteLine($"Added {quantity} x {product.Name} to the cart.");
        }

        // Remove a product entirely from the cart
        public void RemoveProduct(int productId)
        {
            var item = _items.FirstOrDefault(i => i.Product.ProductId == productId);
            if (item != null)
            {
                _items.Remove(item);
                Console.WriteLine($"Removed {item.Product.Name} from the cart.");
            }
            else
            {
                Console.WriteLine("Product not found in the cart.");
            }
        }

        // View the current contents of the cart
        public void ViewCart()
        {
            Console.WriteLine("\n--- Shopping Cart ---");
            if (!_items.Any())
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            decimal total = 0;
            foreach (var item in _items)
            {
                Console.WriteLine($"{item.Product.Name} (x{item.Quantity}) - ${item.GetTotalPrice():0.00}");
                total += item.GetTotalPrice();
            }
            Console.WriteLine($"Estimated Total: ${total:0.00}\n---------------------\n");
        }

        // Process checkout, deduct inventory, and return the final total
        public decimal Checkout()
        {
            if (!_items.Any())
                throw new InvalidOperationException("Cannot checkout. The cart is empty.");

            decimal finalTotal = 0;

            foreach (var item in _items)
            {
                // Double-check inventory right before checkout (in case it changed while in cart)
                if (item.Product.Inventory < item.Quantity)
                    throw new InvalidOperationException($"Sorry, {item.Product.Name} is no longer in stock.");

                // Deduct from the actual product inventory
                item.Product.Inventory -= item.Quantity;
                finalTotal += item.GetTotalPrice();
            }

            // Clear the cart after a successful checkout
            _items.Clear();

            Console.WriteLine($"Checkout successful! Your card was charged: ${finalTotal:0.00}");
            return finalTotal;
        }
    }
}