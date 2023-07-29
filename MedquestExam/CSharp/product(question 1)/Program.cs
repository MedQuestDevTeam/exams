using System;

    public class Program
    {

        private static Product[] product = new Product[5];
        public static void Main(string[] args)
        {
            // Create a product(HardCoded).
            product[0] = new Product("iPhone 11 Pro", 4500, 100);
            product[1] = new Product("iPhone 12 Pro Max", 3000, 100);
            product[2] = new Product("iPhone 13", 3500, 100);
            product[3] = new Product("iPhone 14 Mini", 4578, 100);
            product[4] = new Product("iPhone 15 Plus", 1922, 100);

            // Create a shopping cart.
            ShoppingCart cart = new ShoppingCart();

            // Testing the function of adding a product into the shopping cart
            cart.AddProduct(product[0]);
            cart.AddProduct(product[1]);

            // Get the total price of the shopping cart.
            decimal total = cart.GetTotal();

            // Print the total price.
            Console.WriteLine("The total price of iphone 11 pro and iPhone 12 Pro Max: {0}", total);

            // Testing the function of removing a product from the shopping cart
            cart.RemoveProduct(product[1]);
            total = cart.GetTotal();
            Console.WriteLine("The total price of iPhone 11 Pro: {0}", total);
        }
    }
