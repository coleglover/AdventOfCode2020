using System;
using System.Collections.Generic;
using System.Text;

namespace AoC._2020
{
    class BinaryBoarding
    {
        public static string[] ImportData()
        {
            string[] seating = System.IO.File.ReadAllLines(@"#\AoC.2020\InputData\Day05\Day05.Input.txt");

            return seating;

        }
    }
}
