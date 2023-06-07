using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo.Helper
{
    public class ArgumentChecker
    {
        public static bool Check(string[] args)
        {
            if(args.Length % 2 != 1 || args.Length <3)
            {
                Console.WriteLine($"The number of arguments should be more or equal to 3, and an odd number.The number of arguments you entered is {args.Length}.\nPlease try to enter a valid number of arguments.\nFor example: arg1 arg2 arg3 arg4 arg5");
                return false;
            }
            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("The arguments should be unique. The arguments you have entered have duplicate values.\nPlease try to enter not repeating values.\nFor example: arg1 arg2 arg3");
                return false;
            }
            else return true;
        }
    }
}
