using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2020
{
    class PassportProcessing
    {

        //< import & transform data into a standardized format
        public static string[] ImportData()
        {
            string[] passports = System.IO.File.ReadAllText(@"C:\Users\Cole\source\repos\AoC.2020\InputData\Day04\Day04.Input.txt").
                                                Split(new string[] { "\r\n\r\n" },
                                                StringSplitOptions.RemoveEmptyEntries);           
            return passports;
        }

        public static int PassportCounter(string[] passports) 
        {
            int passportCount = 0;

            foreach (string passport in passports)
            {
                var passportLines = passport.Replace(' ', '\n');
                Console.WriteLine($"\n{passportLines}");

                if (IsValid(passportLines)) 
                {
                    passportCount++;
                }
            }

            Console.WriteLine(passportCount);
            return passportCount;
        }

        public static bool IsValid(string passport) 
        {
            string[] essentialCriteria = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            
            int containsCount = 0;

            //< change this to while loop(?)
            foreach (string criteria in essentialCriteria)
            {
                if (!passport.Contains(criteria))
                {
                    return false;
                }
            }

            return true;       
        }
    }
}
