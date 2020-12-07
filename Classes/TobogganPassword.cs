using System;
using System.Collections.Generic;


namespace AoC._2020
{
    class TobogganPassword
    {

        public string PasswordCriteria { get; private set; }
        public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }
        public string LetterID { get; private set; }
        public string Password { get; private set; }

        //< EXAMPLE: 
        //< input: [13-15 c: cqbhncccjsncqcc]
        //< output: [13-15], [c:], [cqbhncccjsncqcc]
        //< output: [13], [15], [c]

        //< constructor for Object "Toboggan Password" that parses an input string
        public TobogganPassword(string passwordCriteria) 
        {
            string[] passwordParts = passwordCriteria.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] bounds = passwordParts[0].Split(new Char [] { '-' });
            string[] letterID = passwordParts[1].Split(new Char[] { ':' });


            this.PasswordCriteria = passwordCriteria;
            this.LowerBound = Int32.Parse(bounds[0]);
            this.UpperBound = Int32.Parse(bounds[1]);
            this.LetterID = letterID[0].ToString();
            this.Password = passwordParts[2].ToString();
        }

        public static string[] ImportData()
        {
            string[] tobogganPasswords = System.IO.File.ReadAllLines(@"C:\Users\Cole\source\repos\AoC.2020\InputData\Day02\Day02.Input.txt");

            return tobogganPasswords;

        }
        public static List<int> GetValidPasswords() 
        {
            string[] tobogganPasswords = ImportData();

            List<int> validPasswordCount = new List<int>();

            int countIsGoodp1 = 0;
            int countIsGoodp2 = 0;



            for (int i = 0; i < tobogganPasswords.Length; i++)
            {
                //Console.WriteLine($"\nTesting: {tobogganPasswords[i]}");

                //< sending Password to Sled Rental Password Policy Tester (Part 1)
                if (TestSledPassword(tobogganPasswords[i]))                
                {
                    countIsGoodp1++;
                }

                //< sending Password to Toboggan Rental Password Policy Tester (Part 2)
                if (TestTobogganPasswords(tobogganPasswords[i])) 
                {
                    countIsGoodp2++;
                }

            }

            validPasswordCount.Add(countIsGoodp1);
            validPasswordCount.Add(countIsGoodp2);

            return validPasswordCount;
        }

        //< testing if "LetterID" exists between or equal to the "Boundaries"
        public static bool TestSledPassword(string possPass) 
        {
            TobogganPassword password = new TobogganPassword(possPass);

            int letterCounter = 0;

            for (int i = 0; i <  password.Password.Length; i++) 
            {
                
                if (password.Password[i].ToString() == password.LetterID) 
                {
                    letterCounter++;
                }
            }


            if ((letterCounter >= password.LowerBound) && (letterCounter <= password.UpperBound)) 
            {
                //Console.WriteLine("Sled Policy: VALID");
                return true;
            }

            //Console.WriteLine("Sled Policy: INVALID");
            return false;

        }

        //< testing if "Letter ID" is at one and only one of the given "Boundaries"
        public static bool TestTobogganPasswords(string possPass) 
        {
            TobogganPassword password = new TobogganPassword(possPass);

          
            //< subtract one because character 1 of 'password' is at position 1
            if ((password.Password[password.LowerBound - 1].ToString() == password.LetterID) & (password.Password[password.UpperBound - 1].ToString() == password.LetterID))
            {
                //Console.WriteLine("Toboggan Policy: INVALID");
                return false;
            }

            if ((password.Password[password.LowerBound - 1].ToString() == password.LetterID) || (password.Password[password.UpperBound - 1].ToString() == password.LetterID)) 
            {
                //Console.WriteLine("Toboggan Policy: VALID");
                return true;
            }

            //Console.WriteLine("Toboggan Policy: INVALID");
            return false;
        }
    }
}
