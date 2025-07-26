using System;
using System.Collections.Generic;

namespace Q1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Testcase 1:");
            Product p = new Product(1, "Dell XPS 13 7390", "Computer", 1000);
            p.Display(x => (x.Type.Equals("Computer") ? x.Price * 0.1 : x.Price * 0.05));

            Console.WriteLine("\nTestcase 2:");
            List<Product> products = new List<Product> {
                new Product(2, "Dell Inspiron 15 5505", "Computer", 850),
                new Product(2, "Dell XPS 15 9550", "Computer", 2500),
                new Product(2, "Inspot 5.7L", "Houseware", 200)
                };
            Product.Display(products,
                (x => (x.Type.Equals("Computer") ? x.Price * 0.15 : x.Price * 0.05))
                );
        }
    }
}
