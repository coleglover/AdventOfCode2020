using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2020
{
    class BinaryBoarding
    {
        public static string[] ImportData()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\Cole\source\repos\AoC.2020\InputData\Day05\Day05.Input.txt");           
            //return System.IO.File.ReadAllLines(@"C:\Users\Cole\source\repos\AoC.2020\InputData\Day05\Day05.TestInput.txt"); 
            //< should return: 357, 567, 119, 820, respectively
        }

        public static List<int> FindSeatID(IEnumerable<string> boardingPasses) 
        {
            var seatID = boardingPasses.Select(coords => PartitionBoardingPass(coords));
            
            List<int> seatIDs = seatID.ToList();

            int maxSeatID = seatIDs.Max();
            Console.WriteLine(maxSeatID);

            return seatIDs;
        }

        public static int PartitionBoardingPass(string boardingPass) 
        {
            var xDir = boardingPass[7..];
            var yDir = boardingPass.Substring(0, 7);

            var col = ParseColCoord(xDir);
            var row = ParseRowCoord(yDir);

            Console.WriteLine($"{yDir} {xDir} => row: {row} column: {col} = seat ID: {(row * 8) + col}");
            return row * 8 + col;
        }    

        public static int ParseColCoord(string xCoord)
        {
            double minBound = 0;
            double maxBound = 7;

            for (int i = 1; i < xCoord.Length + 1; i++)
            {
                if (xCoord[i - 1].ToString() == "L")
                {
                    maxBound = maxBound - Math.Ceiling((minBound / Math.Pow(2, i)));
                }

                if (xCoord[i - 1].ToString() == "R")
                {
                    minBound = minBound + Math.Ceiling((maxBound / Math.Pow(2, i)));
                }
            }

            return (int)minBound;
        }

        public static int ParseRowCoord(string yCoord)
        {
            double minBound = 0;
            double maxBound = 128;

            for (int i = 1; i < yCoord.Length + 1; i++)
            {
                if (yCoord[i - 1].ToString() == "F")
                {
                    maxBound = maxBound - Math.Ceiling((minBound / Math.Pow(2, i)));
                }

                if (yCoord[i - 1].ToString() == "B")
                {
                    minBound = minBound + Math.Ceiling((maxBound / Math.Pow(2, i)));
                }
            }

            return (int)minBound;
        }
    }
}
