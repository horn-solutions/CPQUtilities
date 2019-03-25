using CPQUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    public static class AndyTest
    {
        public static void test(string[] args)
        {
            Credentials c = new Credentials();
            Console.Write(string.Format("Logging in as {0}", c.Login));
            Console.WriteLine(string.Format(" ... Login {0}", c.DoYouSeeMe() ? "Successful" : "Unsuccessful"));

            Product p = new Product();
            p.ProductName = new Translations("ProductName1");
            p.Categories = new CategoryList();
            p.Categories.Add(new Translations("Category 1"));
            p.ProductType = "Product Type 1";

            //this doesn't do what you think it does.
            Console.WriteLine(p.CreateXml().ToString());

            Console.ReadLine();

        }
    }
}
