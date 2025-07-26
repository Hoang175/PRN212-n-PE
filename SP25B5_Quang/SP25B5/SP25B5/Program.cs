using System.Net.Http.Headers;

namespace SP25B5
{
    public delegate double TaxCalculation(Product p);

    public class Product
    {
        public Product(string id, string name, string type, double price)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public void Display(TaxCalculation c)
        {
            double tax = c(this);
        }

        public static double Display(List<Product> products, TaxCalculation c)
        {
            double totalTax = 0;
            foreach (var product in products)
            {
                product.Display(c);
                totalTax = c(product);
            }
            return totalTax; 
        }
    }
}
