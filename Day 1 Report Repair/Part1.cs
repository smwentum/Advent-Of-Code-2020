using System;
using System.Collections.Generic;
using System.IO;

namespace Day_1_Report_Repair
{
    public class Part1
    {
        /// <summary>
        /// For part one i just need to find the numbers that add up to 2020 and print out the product
        /// now that i think about it more it wont work right 1010
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<int> expenses = new List<int>();
            foreach (string line in File.ReadLines(@"D:\Documents\random programming stuff\Advent of code\2020\Advent Of Code 2020\Day 1 Report Repair\part1data.txt"))
            {
                expenses.Add(int.Parse(line));
            }

            foreach (int expense in expenses)
            {
                if (expenses.Contains(2020 - expense))
                {
                    Console.WriteLine(expense);

                    Console.WriteLine(expense * (2020 - expense));
                    break;
                }
            }
        }
    }
}
