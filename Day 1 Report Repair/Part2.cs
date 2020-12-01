using System;
using System.Collections.Generic;
using System.IO;

namespace Day_1_Report_Repair
{
    public class Part2
    {
        /// <summary>
        /// For part one i just need to find three numbers that add up to 2020 and print out the product
        /// going to triple for loop it  but there is probably something more clever i am not thinking about
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<int> expenses = new List<int>();
            foreach (string line in File.ReadLines(@"D:\Documents\random programming stuff\Advent of code\2020\Advent Of Code 2020\Day 1 Report Repair\part2data.txt"))
            {
                expenses.Add(int.Parse(line));
            }


            for (int i = 0; i < expenses.Count; i++)
            {
                for (int j = i+1; j < expenses.Count; j++)
                {
                    for (int k = j+1; k < expenses.Count; k++)
                    {
                        if (expenses[i] + expenses[j] + expenses[k] == 2020)
                        {
                            Console.WriteLine(expenses[i]);
                            Console.WriteLine(expenses[j]);
                            Console.WriteLine(expenses[k]);
                            Console.WriteLine(expenses[i] + expenses[j] + expenses[k]);
                            Console.WriteLine(expenses[i] * expenses[j] * expenses[k]);
                            break;
                        }
                    }
                }
            }
           

        }
    }
}
