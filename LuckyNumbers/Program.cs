using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int highRange = 0;
            int lowRange = 0;
            int[] guessedNums = new int[6];
            int arrayCount = 0;
            

            Console.WriteLine("Booting LuckyNumbers.exe...");
            Console.WriteLine("\nIf you are able to guess all 6 numbers, you will win the jackpot!!");
            Console.WriteLine("Current jackpot: $10,312,494");
            Console.WriteLine("You can still win great prizes if you guess between 1 and 5 numbers correctly!");
            Console.WriteLine("\nPlease enter 2 numbers that you would like to set as your range.");
            Console.Write("Low range: ");
            lowRange = int.Parse(Console.ReadLine());
            Console.Write("High range: ");
            highRange = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 6; i++)
            {
                Console.Write("\nPlease enter a guess between your number ranges: ");
                guessedNums[arrayCount] = int.Parse(Console.ReadLine());
                while (guessedNums[arrayCount] < lowRange || guessedNums[arrayCount] > highRange)
                {
                    Console.WriteLine("That entry is incorrect");
                    Console.Write("Please enter a valid number: ");
                    guessedNums[arrayCount] = int.Parse(Console.ReadLine());

                } 
                arrayCount++;
            }
            
        }

        public static int[] RandNum(int lowValue, int highValue, int arraySize)
        {
            Random randGen = new Random();
            int[] array = new int[arraySize];

            randGen.Next(lowValue, (highValue + 1));

        }
    }
}
