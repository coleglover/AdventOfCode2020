using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2020
{
    class PassportProcessing
    {
        public int BirthYear { get; private set; }
        public int IssueYear { get; private set; }
        public int ExpirationYear { get; private set; }
        public string Height { get; private set; }
        public string HairColour { get; private set; }
        public string EyeColour { get; private set; }
        public int PassportID { get; private set; }

        public PassportProcessing(string passport) 
        { 
        
            this.BirthYear = Int32.Parse(passport.Substring(passport.IndexOf("byr:") + 4, 4));
            this.IssueYear = Int32.Parse(passport.Substring(passport.IndexOf("iyr:") + 4, 4));
            this.ExpirationYear = Int32.Parse(passport.Substring(passport.IndexOf("eyr:") + 4, 4));

            this.Height = passport.Substring(passport.IndexOf("hgt:") + 4, 5); //< this will require tailoring
            this.HairColour = passport.Substring(passport.IndexOf("hcl:#") + 4, 6);
            
            this.PassportID = Int32.Parse(passport.Substring(passport.IndexOf("pid:") + 4, 9));



        }

        //< import & transform data into a standardized format
        public static string[] ImportData()
        {
            string[] passports = System.IO.File.ReadAllText(@"#\AoC.2020\InputData\Day04\Day04.Input.txt").
                                                Split(new string[] { "\r\n\r\n" },
                                                StringSplitOptions.RemoveEmptyEntries);           
            return passports;
        }

        public static int PassportCounter(string[] passports) 
        {
            int passportCount = 0;

            foreach (string passport in passports)
            {
                var passportLines = passport.Replace(' ', '\n'); //< might not need this
                //Console.WriteLine($"\n{passportLines}");

                if (IsValid(passportLines) && DetailsCheck(passportLines)) 
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
            
            foreach (string criteria in essentialCriteria)
            {
                if (!passport.Contains(criteria))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool DetailsCheck(string passportUnparsed) 
        {
            PassportProcessing passport = new PassportProcessing(passportUnparsed);

            //< create nested IF loop to optimiize processing time
            bool dateRequirements = (BirthYearCheck(passport.BirthYear) && IssueYearCheck(passport.IssueYear) && ExpirationYearCheck(passport.ExpirationYear));
            bool physicalTraits = (HeightCheck(passport.Height) && HairColourCheck(passport.HairColour) && EyeColourCheck(passport.EyeColour));
            bool originIDs = (PassportIDCheck(passport.PassportID));

            // return (dateRequirements && physicalTraits && originIDs);

            return dateRequirements;
      
        }

        public static bool BirthYearCheck(int birthYear) 
        {
            Console.WriteLine($"Birth year: {birthYear}");

            return true;        
        }
        public static bool IssueYearCheck(int issueYear)
        {
            Console.WriteLine($"Issue year: {issueYear}");

            return true;
        }
        public static bool ExpirationYearCheck(int expYear)
        {
            Console.WriteLine($"Expiry year: {expYear}");

            return true;
        }
        public static bool HeightCheck(string height)
        {
            Console.WriteLine($"Height: {height}");

            return true;
        }
        public static bool HairColourCheck(string hairColour)
        {
            Console.WriteLine($"Hair colour: {hairColour}");

            return true;
        }
        public static bool EyeColourCheck(string eyeColour)
        {
            Console.WriteLine($"Eye colour: {eyeColour}");

            return true;
        }
        public static bool PassportIDCheck(int passportID)
        {
            Console.WriteLine($"Passport ID: {passportID}");

            return true;
        }
        //public static bool CountryIDCheck(int countryID)
        //{
        //    Console.WriteLine();

        //    return true;
        //}
    }
}
