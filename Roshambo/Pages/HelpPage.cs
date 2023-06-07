using Force.DeepCloner;
using Roshambo.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo.Pages
{
    public class HelpPage
    {
        public static bool Help(string[] args)
        {
            string[,] table = GenerateTable(args);
            PrintTable(table, args);
            Console.WriteLine("Enter 0 to go back.");
            string key;
            do
            {
                key = Console.ReadLine();
            } while (key != "0");
            return key == "0";
        }
        static string[,] GenerateTable(string[] args)
        {
            int movesCount = args.Length;
            string[,] table = new string[movesCount, movesCount];
            for(int i=0; i< movesCount; i++)
            {
                for(int j=0; j<movesCount; j++)
                {
                    int diff = (j - i + movesCount) % movesCount;
                    if (diff == 0)
                        table[i, j] = "Draw";
                    else if (diff <= movesCount / 2)
                        table[i, j] = "Win";
                    else
                        table[i, j] = "Lose";
                }
            }
            return table;
        }
        static void PrintTable(string[,] table, string[] moves)
        {
            int moveCount = moves.Length;
            Console.WriteLine();
            Console.Write("{0,-10}", "v PC\\User >");
            for (int i = 0; i < moveCount; i++)
            {
                Console.Write("{0,-10}", moves[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < moveCount; i++)
            {
                Console.Write("{0,-10}", moves[i]);
                for (int j = 0; j < moveCount; j++)
                {
                    Console.Write("{0,-10}", table[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
