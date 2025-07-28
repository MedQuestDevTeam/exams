using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOnlineStore
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }

        public Product(string name, decimal price, int inventory)
        {
            Name = name;
            Price = price;
            Inventory = inventory;
        }
    }

}
