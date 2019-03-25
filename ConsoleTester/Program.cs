using CPQUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Credentials c = new Credentials();
            c.DoYouSeeMe();
            //Push.AddProduct(c.Username, c.Password, "TestProductName");
            

            

            //Console.ReadLine();




            CategoryList cl = new CategoryList();
            cl.Add(new Translations("Category 1"));
            Product p1 = new Product()
            {
                ProductName = new Translations("Test Product"),
                ProductType = "Stuff",
                Categories = cl
            };

            Console.WriteLine(Push.Product(p1, c).ProductId);

            Push.Product(p1, c);

            Console.ReadLine();


        }
    }
}
