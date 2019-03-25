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

            Console.ReadLine();
        }
    }
}
