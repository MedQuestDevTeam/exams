using ChallengeConsoleAppOnlineStore;

class Program
{
    static void Main(string[] args)
    {
        // Initialize some store products
        Product laptop = new Product(1, "Developer Laptop", 1200.00m, 10);
        Product mouse = new Product(2, "Wireless Mouse", 25.50m, 50);
        Product keyboard = new Product(3, "Mechanical Keyboard", 85.00m, 5);

        // Create a shopping cart
        ShoppingCart cart = new ShoppingCart();

        try
        {
            // Add items to the cart
            cart.AddProduct(laptop, 1);
            cart.AddProduct(mouse, 2);
            cart.AddProduct(keyboard, 1);

            // View cart contents
            cart.ViewCart();

            // User removes an item
            cart.RemoveProduct(mouse.ProductId);

            // View cart again
            cart.ViewCart();

            // Checkout
            cart.Checkout();

            // Verify inventory was deducted
            Console.WriteLine($"Remaining Laptops in Stock: {laptop.Inventory}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}