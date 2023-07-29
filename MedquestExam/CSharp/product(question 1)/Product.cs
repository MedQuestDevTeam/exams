public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }

    public Product(){}
    public Product(string name, decimal price, int inventory)
    {
        this.Name = name;
        this.Price = price;
        this.Inventory = inventory;
    }
}
