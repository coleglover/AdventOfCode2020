using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2020
{
    class BinaryBoarding
    {
        public static string[] ImportData()
        {
            return System.IO.File.ReadAllLines(@"#\AoC.2020\InputData\Day05\Day05.Input.txt");           
        }

        public static List<int> FindSeatID(string[] boardingPasses) 
        {
            var seatIDs = boardingPasses.Select(coords => PartitionBoardingPass(coords)).ToList();
            seatIDs.Sort();;

            //< Part 1:
            int maxSeatID = seatIDs.Max();
            //< Part 2: 
            int missingSeatID = FindMissingSeat(seatIDs);

            foreach(int ID in seatIDs) 
            {
                Console.WriteLine(ID);
            }

            Console.WriteLine($"\nMax SeatID: {maxSeatID}");
            Console.WriteLine($"Missing SeatID: {missingSeatID}");

            return seatIDs;
        }
        
        public static int FindMissingSeat(List<int> seatIDs)
        {
            int size = seatIDs.Count();

            int a = 0, b = size - 1;
            int mid = 0;

            while ((b - a) > 1)
            {
                mid = (a + b) / 2;
                if ((seatIDs[a] - a) != (seatIDs[mid] - mid))
                    b = mid;
                else if ((seatIDs[b] - b) != (seatIDs[mid] - mid))
                    a = mid;
            }

            return (seatIDs[mid] - 1);
           
        }

        public static int PartitionBoardingPass(string boardingPass) 
        {
            var xDir = boardingPass[7..];
            var yDir = boardingPass.Substring(0, 7);

            var col = ParseColCoord(xDir);
            var row = ParseRowCoord(yDir);

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
