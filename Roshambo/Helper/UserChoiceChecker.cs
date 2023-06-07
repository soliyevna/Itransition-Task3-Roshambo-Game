using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo.Helper
{
    public class UserChoiceChecker
    {
        public static (bool isTrueChoice, bool isDigit) Check(string userChoice, string[] args)
        {
            int digit;
            int? userChoiceInINt = int.TryParse(userChoice, out digit) ? digit : null;
            if (userChoiceInINt is not null) return (isTrueChoice: userChoiceInINt <= args.Length, isDigit: true);
            else return (isTrueChoice: args.Contains(userChoice), isDigit: false);
        }
    }
}
