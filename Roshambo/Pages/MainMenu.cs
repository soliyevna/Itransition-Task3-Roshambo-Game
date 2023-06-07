using DZen.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo.Pages
{
    public class MainMenu
    {
        public static (string hmacHex, int computerMove, string randomKeyHex) MakeComputerMoveAndDisplayTheHMACWithAvailabeMoves(string[] args)
        {
            byte[] randomKey = GenerateRandomKey(256);
            string randomKeyHex = BitConverter.ToString(randomKey).Replace("-", "");
            int argsSize = args.Length;
            Random random = new Random();
            int computerMove = random.Next(0, argsSize + 1);
            string moveWithRandomKey = args[computerMove] + randomKeyHex;
            byte[] hmacBytes = GenerateHMAC(moveWithRandomKey);
            string hmacHex = BitConverter.ToString(hmacBytes).Replace("-", "");
            DisplayMainMenu(hmacHex, args);
            return (hmacHex: hmacHex, computerMove: computerMove, randomKeyHex: randomKeyHex);
        }
        public static void DisplayMainMenu(string hmacHex, string[] args)
        {
            Console.WriteLine($"HMAC: {hmacHex}\nAvailable moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {args[i]}");
            }
            Console.WriteLine("0 - exit\n? - help");
        }
        static byte[] GenerateRandomKey(int keyLengthInBits)
        {
            int keyLengthInBytes = keyLengthInBits / 8;
            // Generate the random key
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[keyLengthInBytes];
                rng.GetBytes(key);
                return key;
            }
        }
        static byte[] GenerateHMAC(string message)
        {
            using (var sha3 = SHA3.Create())
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                return sha3.ComputeHash(messageBytes);
            }
        }
    }
}
