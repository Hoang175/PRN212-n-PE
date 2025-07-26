using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Type { get; set; }

        public double Price { get; set; }

        public Product(int id, string? name, string type, double price)
        {
            this.Id = id;
            Name = name;
            Type = type;
            Price = price;
        }

        public Product()
        {
        }

        public void Display(TaxCalculator c)
        {
            double tax = c(this);
            Console.WriteLine($"Product: ID: {Id} - Name:{Name} - Type:{Type} -Price:{Price} - Tax:{tax}");
            
        }

        public static double Display(List<Product> products , TaxCalculator c) {

            foreach (Product product in products) { 
            product.Display(c);
            }
            return 0;
        }
    }
}
