using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo.GameLogic
{
    public class WinnerFinder
    {
        public static void FindTheWinner(string userChoice, bool isDigit, string[] args, int computerChoice, string randomKey)
        {
            int indexOfChoice = isDigit ? int.Parse(userChoice) - 1 : args.ToList().IndexOf(userChoice);
            int[] nextMoves = FindNextHalfIndexes(args, indexOfChoice);
            int[] previousMoves = FindPreviousHalfIndexes(args, indexOfChoice);
            Console.WriteLine($"Your move: {args[indexOfChoice]}");
            Console.WriteLine($"Computer move: {args[computerChoice]}");
            if (nextMoves.Contains(computerChoice))
            {
                Console.WriteLine("You lose.");
            }
            else if(previousMoves.Contains(computerChoice))
            {
                Console.WriteLine("You win!");
            }
            else if(computerChoice == indexOfChoice)
            {
                Console.WriteLine("Draw.");
            }
            Console.WriteLine($"HMAC key : {randomKey}");
        }
        public static int[] FindNextHalfIndexes(string[] args, int selectedIndex)
        {
            int totalElements = args.Length;
            int halfElements = totalElements / 2;
            int[] nextIndexes = new int[halfElements];
            for (int i = 1; i <= halfElements; i++)
            {
                int nextIndex = (selectedIndex + i) % totalElements;
                nextIndexes[i - 1] = nextIndex;
            }
            return nextIndexes;
        }

        public static int[] FindPreviousHalfIndexes(string[] args, int selectedIndex)
        {
            int totalElements = args.Length;
            int halfElements = totalElements / 2;
            int[] previousIndexes = new int[halfElements];
            for (int i = 1; i <= halfElements; i++)
            {
                int previousIndex = (selectedIndex - i + totalElements) % totalElements;
                previousIndexes[i - 1] = previousIndex;
            }
            return previousIndexes;
        }
    }
}
