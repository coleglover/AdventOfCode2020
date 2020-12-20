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
        }

        public static List<int> FindSeatID(IEnumerable<string> boardingPasses) 
        {
            //List<int> seatIDs = new List<int>();

            var seatID = boardingPasses.Select(coords => PartitionBoardingPass(coords));
            //seatIDs.Add((seatID).ToList());
            List<int> seatIDs = seatID.ToList();

            foreach (int ID in seatIDs) 
            {
                Console.WriteLine(ID);
                break;
            }          

            return seatIDs;
        }

        public static int PartitionBoardingPass(string boardingPass) 
        {
            var xDir = boardingPass.Substring(0, 7);
            var yDir = boardingPass.Substring(7);

            Console.WriteLine($"{xDir} {yDir}");

            var row = ParseRowCoord(xDir);
            var col = ParseColCoord(yDir);

            //return row * col;

            return 2 * 2;
        }

        public static int ParseRowCoord(string xCoord) 
        { 

        
        }

        public static int ParseColCoord(string yCoord)
        {

        }
    }
}
