using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2020
{
    class TobogganTrajectory
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public TobogganTrajectory(int y, int x) 
        {
            this.Y = y;
            this.X = x;        
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

            for (int i = 0; i < obstacles.Length; i += slope.Y)
            {
                int xCord = xCounter * slope.X;

                string xPlane = obstacles[i];

                char[] xPoints = xPlane.ToCharArray();

                if (xPoints[xCord % xPlane.Length] == '#')
                {
                    treeCount++;
                }

                xCounter++;
            }

            //Console.WriteLine($"\nSlope: {slope.Rise}/{slope.Run} /// Tree impacts: {treeCount} /// Line count:{xCounter}\n");

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
