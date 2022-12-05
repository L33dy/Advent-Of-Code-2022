using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Advent_Of_Code_2022
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Day2();
        }

        private static void Day1()
        {
            var input = File.ReadAllLines("inputs/day1.txt");
            var str = string.Join(" ", input);

            int currentCalories = 0;
            string curr = "";

            int mostCalories = 0;

            for (int i = 0; i <= str.Length; i++)
            {
                //Console.WriteLine("str[i] = " + str[i]);

                if (str[i] == ' ')
                {
                    if (curr == " ")
                    {
                        if (mostCalories < currentCalories)
                        {
                            mostCalories = currentCalories;

                            Console.WriteLine("Most Calories: " + mostCalories);
                        }

                        currentCalories = 0;
                    }
                    else
                    {
                        currentCalories += int.Parse(curr);

                        curr = " ";
                        //Console.WriteLine("Current Calories: " + currentCalories);
                    }
                }
                else
                {
                    curr += str[i];
                }
            }

            Console.WriteLine("Most Calories: " + mostCalories);
        }

        private static void Day2()
        {
            /* Score for the shape
             * ROCK - 1
             * PAPER - 2
             * SCISSORS - 3
             */

            /* Score for the outcome
             * LOST - 0
             * DRAW - 3
             * WIN - 6
             */

            var input = File.ReadAllLines("inputs/day2.txt");
            var totalScore = 0;

            Dictionary<char, int> opponent = new Dictionary<char, int>
            {
                { 'A', 1 },
                { 'B', 2 },
                { 'C', 3 }
            };

            Dictionary<char, int> me = new Dictionary<char, int>
            {
                { 'X', 1 },
                { 'Y', 2 },
                { 'Z', 3 }
            };


            for (int i = 0; i < input.Length; i++)
            {
                var splited = input[i];
                var opponentShape = 0;
                var myShape = 0;
                int gameState;

                foreach (var c in splited)
                {
                    if (c == ' ') continue;

                    if (opponentShape == 0)
                    {
                        opponentShape = SearchInDictionary(c, opponent);
                    }

                    if (myShape == 0)
                    {
                        myShape = SearchInDictionary(c, me);
                    }

                    Console.WriteLine(c);
                }

                gameState = DetermineState(opponentShape, myShape);
                totalScore += (myShape + gameState);
                
                Console.WriteLine("Opponent shape: " + opponentShape);
                Console.WriteLine("My shape: " + myShape);
                Console.WriteLine("Game State: " + gameState);
                Console.WriteLine("Total Score: " + totalScore);
                Console.WriteLine("");
            }

            Console.WriteLine(" ");
            Console.WriteLine(totalScore);


            int SearchInDictionary(char c, Dictionary<char, int> dict)
            {
                foreach (var ch in dict)
                {
                    if (ch.Key == c)
                    {
                        return ch.Value;
                    }
                }

                return 0;
            }

            int DetermineState(int opponentValue, int meValue)
            {
                int lost = 0;
                int draw = 3;
                int win = 6;

                if (opponentValue == 1 && meValue == 2 || opponentValue == 2 && meValue == 3 ||
                    opponentValue == 3 && meValue == 2)
                {
                    return win;
                }

                if (opponentValue == 1 && meValue == 1 || opponentValue == 2 && meValue == 2 ||
                    opponentValue == 3 && meValue == 3)
                {
                    return draw;
                }

                return lost;
            }
            
            Console.ReadLine();
        }
    }
}