using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2020
{
    class TobogganTrajectory
    {
        public int Run { get; private set; }
        public int Rise { get; private set; }

        public TobogganTrajectory(int rise, int run) 
        {
            this.Rise = rise;
            this.Run = run;
            
            
            // create constructor which contains rise / run arrays for each slope
            // send this to the Toboggan Run and generate tree counts
        
        }
        public static string[] ImportData()
        {
            string[] obstacles = System.IO.File.ReadAllLines(@"#\Day03\Day03.Input.txt");

            return obstacles;

        }

        //< Part 1
        public static long TobogganRun(TobogganTrajectory slope)
        {
            string[] obstacles = ImportData();

            long treeCount = 0;
            int xCounter = 0;

            for (int i = 0; i < obstacles.Length; i += slope.Rise)
            {
                int xCord = xCounter * slope.Run;

                string xPlane = obstacles[i];

                char[] xPoints = xPlane.ToCharArray();

                if (xPoints[xCord % xPlane.Length] == '#')
                {
                    xPoints[xCord % xPlane.Length] = 'X';
                    treeCount++;
                }
                else if (xPoints[xCord % xPlane.Length] != 'X')
                {
                    xPoints[xCord % xPlane.Length] = 'O';
                }

                //Console.WriteLine(xPoints);
                xCounter++;
            }

            Console.WriteLine($"\nSlope: {slope.Rise}/{slope.Run} /// Tree impacts: {treeCount} /// Line count:{xCounter}\n");

            return treeCount;

        }


        //< Part 2

        public static long GetSlopeProducts() 
        {
            int[] rise = { 1, 1, 1, 1, 2 };
            int[] run  = { 1, 3, 5, 7, 1 };

            List<TobogganTrajectory> slopeList = new List<TobogganTrajectory>();

            for(int i = 0; i < rise.Length; i++)
            {
                TobogganTrajectory slope = new TobogganTrajectory(rise[i], run[i]);
                slopeList.Add(slope);
            }

            var treeCounts = slopeList.Select(slope => TobogganRun(slope)).ToList();

            long treeCountProduct = treeCounts.Aggregate((total, next) => total * next);

            Console.WriteLine(treeCountProduct);

            return treeCountProduct;

        }
    }
}
