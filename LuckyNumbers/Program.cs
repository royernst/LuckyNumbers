﻿using System;
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
            decimal numCorrect = 0;
            decimal jackpot = 10312494.00m;
            string answer;

            Console.WriteLine("Booting LuckyNumbers.exe...");

            do
            {
                Console.WriteLine("\nIf you are able to guess all 6 numbers, you will win the jackpot!!");
                Console.WriteLine("Current jackpot: $10,312,494");
                Console.WriteLine("\nYou can still win a percentage of the jackpot if you guess between.");
                Console.WriteLine("1 and 5 numbers correctly!");
                Console.WriteLine("\nPlease enter 2 numbers that you would like to set as your range.");
                Console.Write("Low range: ");
                lowRange = int.Parse(Console.ReadLine());
                Console.Write("High range: ");
                highRange = int.Parse(Console.ReadLine());
                Console.WriteLine("\nNow, please guess 6 numbers within your ranges.");
                Console.WriteLine();
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("Please enter a guess between your number ranges: ");
                    guessedNums[i] = int.Parse(Console.ReadLine());
                    while (guessedNums[i] < lowRange || guessedNums[i] > highRange)
                    {
                        Console.WriteLine("That entry is incorrect");
                        Console.Write("Please enter a valid number: ");
                        guessedNums[i] = int.Parse(Console.ReadLine());

                    }

                }
                int[] randArray = RandNum(lowRange, highRange, guessedNums.Length);

                Console.WriteLine("\nHere are today's lucky numbers:");
                for (int i = 0; i < randArray.Length; i++)
                {
                    Console.WriteLine(randArray[i]);
                }

                for (int i = 0; i < randArray.Length; i++)
                {
                    if (randArray.Contains(guessedNums[i]))
                    {
                        numCorrect++;
                    }
                }

                Console.WriteLine("\nYou guessed {0} numbers correctly!", numCorrect);
                Console.WriteLine("\nYou won $" + Math.Round(Winnings(jackpot, numCorrect), 2));
                Console.Write("\nWould you like to play again? (YES/NO)");
                answer = Console.ReadLine().Trim().ToLower();
                numCorrect = 0;
            } while (answer == "yes");
            Console.WriteLine("Thanks for playing!");
        }

        public static int[] RandNum(int lowValue, int highValue, int arraySize)
        {
            Random randGen = new Random();
            int[] array = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                int randNum = randGen.Next(lowValue, (highValue + 1));
                
                while (array.Contains(randNum) && i != 0)
                {
                    randNum = randGen.Next(lowValue, (highValue + 1));
                }
                array[i] = randNum;
            }
            return array;


        }

        public static decimal Winnings(decimal jackpot, decimal correct)
        {
            decimal totalWinnings = jackpot * (correct / 6m);
            totalWinnings = Math.Round(totalWinnings, 2);
            return totalWinnings;

        }
    }
}
