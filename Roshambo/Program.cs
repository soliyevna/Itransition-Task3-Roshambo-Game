using Roshambo.GameLogic;
using Roshambo.Helper;
using Roshambo.Pages;

public class Program
{
    public static void Main(string[] args)
    {
        bool isChecked = ArgumentChecker.Check(args);
        if(isChecked)
        {
            var computerMoveResult = MainMenu.MakeComputerMoveAndDisplayTheHMACWithAvailabeMoves(args);
            bool isTrueChoice = false;
            bool isDigit;
            string userChoice = null;
            while(userChoice == null)
            {
                Console.Write("Enter your move: ");
                userChoice = Console.ReadLine();
                if (userChoice == "?" || userChoice.ToLower() == "help")
                {
                    bool toGoBack = HelpPage.Help(args);
                    if (toGoBack)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (userChoice == "0" || userChoice.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }
            }
            var checkedUserChoice = UserChoiceChecker.Check(userChoice, args);
            isTrueChoice = checkedUserChoice.isTrueChoice;
            isDigit = checkedUserChoice.isDigit;
            while(isTrueChoice is false)
            {
                Console.WriteLine($"Incorrect choice. Please try to select a number from 1 to {args.Length}, or the word next to the number.");
                MainMenu.DisplayMainMenu(computerMoveResult.hmacHex, args);
                userChoice = Console.ReadLine();
                if (userChoice == "?" || userChoice.ToLower() == "help")
                {
                    bool toGoBack = HelpPage.Help(args);
                    if (toGoBack)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (userChoice == "0" || userChoice.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    checkedUserChoice = UserChoiceChecker.Check(userChoice, args);
                    isTrueChoice = checkedUserChoice.isTrueChoice;
                    isDigit = checkedUserChoice.isDigit;
                }
            } 
            if(userChoice.ToLower() != "exit" || userChoice != "0")
            {
                WinnerFinder.FindTheWinner(userChoice, isDigit, args, computerMoveResult.computerMove, computerMoveResult.randomKeyHex);
            }
        }
        
    }
}