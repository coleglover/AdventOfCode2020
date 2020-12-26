using System;
using System.Linq;

namespace AoC._2020
{
    class CustomsDeclaration
    {
        public static string[] ImportData()
        {
            string[] customsForms = System.IO.File.ReadAllText(@"C:\Users\Cole\source\repos\AoC.2020\InputData\Day06\Day06.Input.txt").
                                                Split(new string[] { "\r\n\r\n" },
                                                StringSplitOptions.RemoveEmptyEntries);
            return customsForms;
        }

        public static int CountDeclarations(string[] customsForms) 
        {
            int totalDeclarations = 0;

            foreach(var formEntry in customsForms) 
            {                             
                var anyoneCount = formEntry.Replace("\r\n", "").Distinct().Count();                       
                totalDeclarations += anyoneCount;           
            }

            Console.WriteLine(totalDeclarations);

            return totalDeclarations;
        }
    }
}
