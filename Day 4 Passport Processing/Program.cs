using System;
using System.IO;
using System.Linq;

namespace Day_4_Passport_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            // first i need to read in each line but in a weird way 
            string passport = "";
            int count = 0; 

            using (StreamReader sr = new StreamReader(@"D:\Documents\random programming stuff\Advent of code\2020\Advent Of Code 2020\Day 4 Passport Processing\real.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (isValidPassportArgs(passport))
                        {
                            count++;
                        }
                        passport = "";
                    }
                    else
                    {
                        passport += line + " "; 
                    }

                   
                }
                if (isValidPassportArgs(passport))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private static bool isValidPassportArgs(string passport)
        {
            string[] keyValues = passport.Split(' '); 


            
            if (!checkKey(keyValues, "byr") )
            {
                return false;
            }
            if (!checkKey(keyValues, "iyr"))
            {
                return false;
            }
            if (!checkKey(keyValues, "eyr"))
            {
                return false;
            }
            if (!checkKey(keyValues, "hgt"))
            {
                return false;
            }

            if (!checkKey(keyValues, "hcl"))
            {
                return false;
            }
            if (!passport.Contains("ecl:"))
            {
                return false;
            }
            if (!passport.Contains("pid:"))
            {
                return false;
            }
            return true;

        }

        private static bool checkKey(string[] keys, string key)
        {
            if (keys.Any(m => m.StartsWith(key+":")))
            {
                return true;
            }
            return false;
        }

    }
}
