using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_3_Toboggan_Trajectory
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Documents\random programming stuff\Advent of code\2020\Advent Of Code 2020\Day 3 Toboggan Trajectory\real.txt";

            List<string> field = new List<string>();
          
                field = File.ReadAllLines(path).ToList();

            field = expandField(field);

            int count = 0;
            int i = 0; 
            int j = 0;
            
            while (i < field.Count && j < field[0].Length)
            {

                if (field[i][j] == '#')
                {
                    count++;
                    Console.WriteLine(field[i][j] + $" i = {i} j= {j}");
                }
                else
                {
                    Console.WriteLine(field[i][j] +$" i = {i} j= {j}");
                }
                i  += 1;
                 j += 3;
                
            }
            Console.WriteLine(count);

        }

        private static List<string> expandField(List<string> field)
        {
            
            while ( 3*field.Count > field[0].Length)
            {
                for (int i = 0; i < field.Count; i++)
                {
                    field[i] += field[i];
                    
                }
            }

            return field;
        }
    }
}
