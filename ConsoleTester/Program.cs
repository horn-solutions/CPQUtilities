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
            Console.WriteLine("Adding Product1");
            bool result = Push.Product("product1");



            Console.WriteLine(string.Format("Product1 push response: {0}", result));
            Console.ReadLine();
        }
    }
}
