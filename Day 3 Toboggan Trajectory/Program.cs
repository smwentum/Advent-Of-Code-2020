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


            //part 1

            field = expandFieldFactor(File.ReadAllLines(path).ToList(), 3, 1);
            Console.WriteLine( computeAns(field, 3, 1));

            //part 2
            long ans = 1; 
            
            field = expandFieldFactor(File.ReadAllLines(path).ToList(), 7, 1);
            ans *= computeAns(field, 1, 1);

            field = expandFieldFactor(File.ReadAllLines(path).ToList(), 3, 1);
            ans *= computeAns(field,3,1);

            field = expandFieldFactor(File.ReadAllLines(path).ToList(), 5, 1);
            ans *= computeAns(field,5,1);


            field = expandFieldFactor(File.ReadAllLines(path).ToList(), 7, 1);
            ans *= computeAns(field,7,1);


            field = expandFieldFactor(File.ReadAllLines(path).ToList(), 1, 2);
            ans *= computeAns(field,1,2);



            Console.WriteLine(ans);
        }

        private static int computeAns(List<string> field, int right, int down)
        {
            int count = 0;
            int i = 0;
            int j = 0;

            while (i < field.Count && j < field[0].Length)
            {

                if (field[i][j] == '#')
                {
                    count++;
                    //Console.WriteLine(field[i][j] + $" i = {i} j= {j}");
                }
                else
                {
                    //Console.WriteLine(field[i][j] + $" i = {i} j= {j}");
                }
                i += down;
                j += right;

            }
            //Console.WriteLine(count);
            return count;
        }

        private static List<string> expandFieldFactor(List<string> field, int right, int left)
        {
            
            while ( right*field.Count > left*field[0].Length)
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
