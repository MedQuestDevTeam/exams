using System;
using System.Collections.Generic;
using TestOnlineStore;
using TestOnlineStore.OnlineStore;

namespace TestOnlineStore
{
    public class Program
    {
        public static void Main()
        {
            List<Product> productList = new List<Product>
        {
            new Product("Apple", 0.5m, 100),
            new Product("Banana", 0.3m, 50),
            new Product("Orange", 0.6m, 75)
        };

            ShoppingCart cart = new ShoppingCart();

            while (true)
            {
                Console.WriteLine("\n1. View Products");
                Console.WriteLine("2. Add to Cart");
                Console.WriteLine("3. Remove from Cart");
                Console.WriteLine("4. View Cart");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option (1-6): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("--- Product List ---");
                        foreach (var product in productList)
                        {
                            Console.WriteLine($"{product.Name} - ${product.Price} (In Stock: {product.Inventory})");
                        }
                        break;

                    case "2":
                        Console.Write("Enter product name to add: ");
                        string addName = Console.ReadLine();
                        Product prodToAdd = productList.Find(p => p.Name.Equals(addName, StringComparison.OrdinalIgnoreCase));

                        if (prodToAdd == null)
                        {
                            Console.WriteLine("Product not found.");
                            break;
                        }

                        Console.Write("Enter quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int qtyAdd))
                        {
                            cart.AddToCart(prodToAdd, qtyAdd);
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter product name to remove: ");
                        string removeName = Console.ReadLine();
                        cart.RemoveFromCart(removeName);
                        break;

                    case "4":
                        cart.ViewCart();
                        break;

                    case "5":
                        cart.Checkout();
                        break;

                    case "6":
                        Console.WriteLine("Exiting program.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }


}
