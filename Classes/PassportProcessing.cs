using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2020
{
    class PassportProcessing
    {
        public string PassportUnparsed { get; private set; }
        public int BirthYear { get; private set; }
        public int IssueYear { get; private set; }
        public int ExpirationYear { get; private set; }
        public string Height { get; private set; }
        public string HairColour { get; private set; }
        public string EyeColour { get; private set; }
        public string PassportID { get; private set; }

        public PassportProcessing(string passport) 
        { 
        
            this.BirthYear = Int32.Parse(passport.Substring(passport.IndexOf("byr:") + 4, 4));
            this.IssueYear = Int32.Parse(passport.Substring(passport.IndexOf("iyr:") + 4, 4));
            this.ExpirationYear = Int32.Parse(passport.Substring(passport.IndexOf("eyr:") + 4, 4));

            this.Height = passport.Substring(passport.IndexOf("hgt:") + 4, 4);
            this.HairColour = passport.Substring(passport.IndexOf("hcl:#") + 4, 7);
            this.EyeColour = passport.Substring(passport.IndexOf("ecl:") + 4, 3);

            this.PassportID = passport.Substring(passport.IndexOf("pid:") + 4, 1);

            if (this.PassportID != "#")
            {
                try
                {
                    this.PassportID = passport.Substring(passport.IndexOf("pid:") + 4, 10);
                }
                catch (Exception)
                {
                    //Console.WriteLine("\nPassport ID search out of bounds!");
                    this.PassportID = passport.Substring(passport.IndexOf("pid:") + 4, 9);
                }
            }
        }

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
                if (hasValidCriteria(passport) && DetailsCheck(passport)) 
                {
                    passportCount++;
                }
            }

            Console.WriteLine(passportCount);
            return passportCount;
        }

        public static bool hasValidCriteria(string passport) 
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

            bool dateRequirements = (BirthYearCheck(passport.BirthYear) && IssueYearCheck(passport.IssueYear) && ExpirationYearCheck(passport.ExpirationYear));
            bool physicalTraits = (HeightCheck(passport.Height) && HairColourCheck(passport.HairColour) && EyeColourCheck(passport.EyeColour));
            bool originIDs = (PassportIDCheck(passport.PassportID));

            if (dateRequirements) 
            {
                if (physicalTraits) 
                {
                    if (originIDs) 
                    {
                        Console.WriteLine(">> Passport valid <<\n");
                        return true;
                    }
                }
            }

            return false;    
        }

        public static bool BirthYearCheck(int birthYear) 
        {
            if (birthYear.ToString().Length == 4)
            {
                if ((birthYear >= 1920) && (birthYear <= 2002)) 
                {
                    return true;
                }
            }
            Console.WriteLine($"Birth year: {birthYear} >> invalid <<");

            return false;        
        }
        public static bool IssueYearCheck(int issueYear)
        {
            if (issueYear.ToString().Length == 4)
            {
                if ((issueYear >= 2010) && (issueYear <= 2020))
                {
                    return true;
                }
            }
            
            Console.WriteLine($"Issued: {issueYear} - invalid");
            return false;
        }
        public static bool ExpirationYearCheck(int expYear)
        {
            if (expYear.ToString().Length == 4)
            {
                if ((expYear >= 2020) && (expYear <= 2030))
                {
                    return true;
                }
            }
            Console.WriteLine($"Expiry: {expYear} >> invalid <<");
            return false;

        }
        public static bool HeightCheck(string height)
        {
            if (height.Contains("c")) 
            {
                //height = height.Substring(0, 3);
                height = Regex.Replace(height, "[^0-9]+", string.Empty);

                if ((Int32.Parse(height) >= 150) && (Int32.Parse(height) <= 193)) 
                {
                    return true;
                }

            }

            if (height.Contains("in"))
            {
                height = Regex.Replace(height, "[^0-9]+", string.Empty);

                if ((Int32.Parse(height) >= 59) && (Int32.Parse(height) <= 76))
                {
                    return true;
                }

            }

            Console.WriteLine($"Height: {height} >> invalid <<");

            return false;
        }
        public static bool HairColourCheck(string hairColourStr)
        {
            char[] hairColour = hairColourStr.ToCharArray();
            char[] colourIndex = "0123456789abcdef".ToCharArray();
            int containsCount = 0;

            for (int i = 0; i < hairColour.Length + 1; i++) 
            {

                if (hairColour[0].ToString() != "#")
                {
                    return false;
                }

                if (i == 7 && containsCount == 6)
                {
                    return true;
                }

                if ((colourIndex).Contains(hairColour[i]))
                {
                    containsCount++;
                }

            }

            Console.WriteLine($"Hair colour: {hairColourStr} >> invalid <<");

            return false;
        }
        public static bool EyeColourCheck(string eyeColour)
        {
            string[] validEyeColours = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            if (validEyeColours.Contains(eyeColour)) 
            {
                return true;
            }

            Console.WriteLine($"Eye colour: {eyeColour} >> invalid <<");

            return false;
        }
        public static bool PassportIDCheck(string passportID)
        {
            passportID = passportID = Regex.Replace(passportID, "[^0-9]+", string.Empty);

            if (passportID.Length == 9) 
            {
                Console.WriteLine($"Passport ID: {passportID}");
                return true;
            }

            Console.WriteLine($"Passport ID: {passportID} >> invalid <<");

            return false;
        }

    }
}
