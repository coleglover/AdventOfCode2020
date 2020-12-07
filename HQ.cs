using System;

namespace AoC._2020
{
    class Program
    {      
        static void Main()
        {
            //< Day 01
            ExpenseReport.NumberCruncher(ExpenseReport.ImportData());

            //< Day 02
            var possibleSledPasswords = TobogganPassword.GetValidPasswords();
            Console.WriteLine($"\nTotal possible Sled passwords: {possibleSledPasswords[0]}");
            Console.WriteLine($"Total possible Toboggan passwords: {possibleSledPasswords[1]}");
            Console.ReadLine();
        }
    }
}
