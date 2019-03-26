using CPQUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    static class JuddTest
    {
        public static void test(string[] args)
        {
            Credentials c = new Credentials();
            Console.Write(string.Format("Logging in as {0}", c.Login));
            Console.WriteLine(string.Format(" ... Login {0}", c.DoYouSeeMe() ? "Successful" : "Unsuccessful"));
            User u = new User()
            {
                Username="login",
                Password="123123",
                FirstName="Christopher",
                LastName="Judd"
            };

            Console.WriteLine(u.CreateXml().InnerXml);
            
            Console.ReadLine();

        }
    }
}
