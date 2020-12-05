using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_4_Passport_Processing
{
    class Program
    {
        //For part 2 there is a better less lazy way of doing this, but i am taking the lazy route 
        static void Main(string[] args)
        {
            // first i need to read in each line but in a weird way 
            string passport = "";
            int countP1 = 0;
            int countP2 = 0;

            using (StreamReader sr = new StreamReader(@"D:\Documents\random programming stuff\Advent of code\2020\Advent Of Code 2020\Day 4 Passport Processing\real.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (isValidPassportArgs(passport))
                        {
                            countP1++;
                            if (isValidatedPassport(passport))
                            {
                                countP2++;
                            }
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
                    countP1++;
                    if (isValidatedPassport(passport))
                    {
                        countP2++;
                    }
                }
            }

            Console.WriteLine(countP1);
            Console.WriteLine(countP2);
        }

        private static bool isValidatedPassport(string passport)
        {
            string[] keyValues = passport.Split(' ');
            string byr = keyValues.First(m => m.StartsWith("byr" + ":")).Split(':')[1];
            string iyr = keyValues.First(m => m.StartsWith("iyr" + ":")).Split(':')[1];
            string eyr = keyValues.First(m => m.StartsWith("eyr" + ":")).Split(':')[1];
            string hcl = keyValues.First(m => m.StartsWith("hcl" + ":")).Split(':')[1];
            string ecl = keyValues.First(m => m.StartsWith("ecl" + ":")).Split(':')[1];
            string pid = keyValues.First(m => m.StartsWith("pid" + ":")).Split(':')[1];
            string hgt = keyValues.First(m => m.StartsWith("hgt" + ":")).Split(':')[1];
            bool ans = isValidByr(byr) && isValidIyr(iyr) && isValidEyr(eyr) && isVaildHgt(hgt)
                                    && isValidHcl(hcl) && isValidEcl(ecl) && isValidPid(pid);
            return ans; 
        }

        private static bool isValidByr(string byr)
        {
            int bYearNum = 0;
            if (!int.TryParse(byr, out bYearNum) || bYearNum > 2002 || bYearNum < 1920)
            {
                return false;
            }

            return true;
        }

        private static bool isValidIyr(string iyr)
        {
            int iYearNum = 0;
            if (!int.TryParse(iyr, out iYearNum) || iYearNum > 2020 || iYearNum < 2010)
            {
                return false;
            }

            return true;
        }


        private static bool isValidEyr(string eyr)
        {
            int eYearNum = 0;
            if (!int.TryParse(eyr, out eYearNum) || eYearNum > 2030 || eYearNum < 2020)
            {
                return false;
            }

            return true;
        }


        private static bool isVaildHgt(string hgt)
        {
            string measurement = hgt.Substring(hgt.Length - 2);
            int value = 0;

            if (measurement == "in")
            {
                if (int.TryParse(hgt.Substring(0, hgt.Length - 2), out value) && value > 58 && value < 77)
                {
                    return true;
                }
            }

            if (measurement == "cm")
            {
                if (int.TryParse(hgt.Substring(0, hgt.Length - 2), out value) && value > 149 && value < 194)
                {
                    return true;
                }
            }


            return false;
        }

        private static bool isValidHcl(string hcl)
        {
            if (!hcl.StartsWith("#") && hcl.Length != 7)
            {
                return false; 
            }

            for (int i = 1; i < 7; i++)
            {
                if (!char.IsDigit(hcl[i]) && ('a' > hcl[i] || hcl[i] > 'f'))
                {

                    return false; 
                }
            }

            return true;

        }

        

        private static bool isValidPid(string pid)
        {
            return pid.Length == 9 && !pid.Any(m => !char.IsDigit(m));
        }

        private static bool isValidEcl(string ecl)
        {
           
            List<string> validEyeColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            return validEyeColors.Any(m => m == ecl);
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
