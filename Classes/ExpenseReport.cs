using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AoC._2020
{
    class ExpenseReport
    {

        public static int[] ImportData()
        {
            string[] expenseReport = System.IO.File.ReadAllLines(@"C:\Users\Cole\source\repos\AoC.2020\InputData\Day01\Day01.Input.txt");
            return expenseReport.Select(int.Parse).ToArray();
        }


        public static void NumberCruncher(int[] expenseReport) 
        {
            for (int i = 0; i < expenseReport.Length; i++) 
            {
                for (int j = 0; j < expenseReport.Length; j++) 
                {
                    for (int k = 0; k < expenseReport.Length; k++)
                    {

                        if ((expenseReport[i] + expenseReport[j]) == 2020)
                        {
                            Console.WriteLine($"{expenseReport[i]} + {expenseReport[j]} = {expenseReport[i] + expenseReport[j]}");
                            Console.WriteLine($"Product = {expenseReport[i] * expenseReport[j]}\n");
                            break;
                        }
                        else if((expenseReport[i] + expenseReport[j] + expenseReport[k]) == 2020)
                        {
                            Console.WriteLine($"{expenseReport[i]} + {expenseReport[j]} + {expenseReport[k]} = {expenseReport[i] + expenseReport[j] + expenseReport[k]}");
                            Console.WriteLine($"Product = {expenseReport[i] * expenseReport[j] * expenseReport[k]}\n");
                            break;
                        }
                    }       
              
                }
            }  
        } 

    }
}
