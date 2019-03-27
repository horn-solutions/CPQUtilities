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
            p.ProductName = new Translations("AndyProductAPITest1");
            p.Categories = new CategoryList();
            p.Categories.Add(new Translations("Software Devices"));
            //p.CategoryListString = "Software Devices";
            p.ProductType = "Software";
            p.Active = true;

            
           
            //this doesn't do what you think it does.
            Console.WriteLine("Inner XML: " + p.CreateXml().InnerXml);
            //Console.WriteLine("Inner Tex: " + p.CreateXml().InnerText);
            //Push.Product(p, c);
            Console.WriteLine("Tried to push product");

            Console.ReadLine();

        }
    }
}
