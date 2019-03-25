using CPQUtilities;
using Microsoft.Extensions.CommandLineUtils;
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

            var app = new CommandLineApplication();
            var debugTarget = app.Option("-dt | --debugtarget", "Either judd or andy", CommandOptionType.SingleValue);

            app.OnExecute(() =>
                {
                    if (!debugTarget.HasValue())
                    {
                        Console.WriteLine("You must specify the debug target using -dt judd or -dt andy");
                        return 0;
                    }

                    switch (debugTarget.Value())
                    {
                        case "judd": JuddTest.test(args); break;
                        case "andy": AndyTest.test(args); break;
                        default:
                            break;
                    }
                    return 1;
                }
            );

            app.Execute(args);

        }
    }
}
