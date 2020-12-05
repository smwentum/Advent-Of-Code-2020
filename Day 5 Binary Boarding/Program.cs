using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_5_Binary_Boarding
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Documents\random programming stuff\Advent of code\2020\Advent Of Code 2020\Day 5 Binary Boarding\real.txt";
            //read in the text
            List<string> boardingPasses = File.ReadAllLines(path).ToList();
            long maxValue = -1;
            foreach (string boardingPass in boardingPasses)
            {
                maxValue = Math.Max(maxValue, getSeatId(boardingPass));
            }
            Console.WriteLine(maxValue);
        }

        private static long getSeatId(string boardingPass)
        {
            int max = 127;
            int min = 0;
            for (int i = 0; i < 7; i++)
            {
                if (boardingPass[i] == 'F')
                {
                    max = (int) Math.Floor((max + min) / 2.0);
                }
                if (boardingPass[i] == 'B')
                {
                    min = (int)Math.Ceiling((max + min) / 2.0);
                }
                //Console.WriteLine($"min: {min} max: {max}");
            }
            int minRow = 0;
            int maxRow = 7; 
            for (int i = 7; i < 10; i++)
            {
                if (boardingPass[i] == 'L')
                {
                    maxRow = (int)Math.Floor((maxRow + minRow) / 2.0);
                }
                if (boardingPass[i] == 'R')
                {
                    minRow = (int)Math.Ceiling((maxRow + minRow) / 2.0);
                }
                //Console.WriteLine($"min: {minRow} max: {maxRow}");
            }
            //Console.WriteLine($"The seat number is: {min * 8+minRow}");
            return min * 8 + minRow;
        }
    }
}
