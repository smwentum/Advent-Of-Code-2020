using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_2_Password_Philosophy
{
     public class Part1
    {
        static void Main(string[] args)
        {
            List<Password> passwords = new List<Password>();
            string amount;
            string charIwant;
            string password;
            int count;
            foreach (string line in File.ReadLines(@"D:\Documents\random programming stuff\Advent of code\2020\Advent Of Code 2020\Day 2 Password Philosophy\real.txt"))
            {
                amount = line.Split(' ')[0];
                charIwant = line.Split(' ')[1];
                password = line.Split(' ')[2];
                passwords.Add(new Password()
                {
                    minLength = int.Parse(amount.Split('-')[0]),
                    maxLength = int.Parse(amount.Split('-')[1]),
                    requriedLetter = charIwant[0],
                    password = password
                }) ;
                
            }

            count = passwords.Count(m => isValidPassword(m));

            Console.WriteLine(count);

        }

        private static bool isValidPassword(Password m)
        {
            int count = 0;
            for (int i = 0; i < m.password.Length; i++)
            {
                if (m.password[i] == m.requriedLetter)
                {
                    count++;
                }
            }
            return m.minLength <= count && m.maxLength >= count;
        }
    }
}
