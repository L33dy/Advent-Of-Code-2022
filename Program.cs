using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Advent_Of_Code_2022
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Day1();
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
                        Console.WriteLine(" NEW ELF ");

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
    }
}