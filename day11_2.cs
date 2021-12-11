using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day11_2
    {
        public static List<List<point>> mapping = new List<List<point>>();
        public static int flashes = 0;
        public static int maxLines = 9;
        public static int currentFlashes;
        public static int maxFlashes = 100;

        static void Main(string[] args)
        {
            List<point> currentLine = new List<point>();

            foreach (string line in File.ReadLines("../../../InputDay11.txt"))
            {
                currentLine = new List<point>();
                foreach (char c in line)
                {
                    int energy = Convert.ToInt32(c.ToString());
                    currentLine.Add(new point(energy));
                }
                mapping.Add(currentLine);
            }

            point currentPoint;
            int step = 0;
            while (currentFlashes != maxFlashes)
            {
                step++;
                currentFlashes = 0;

                //Debug code
                //Console.WriteLine("");

                for (int row = 0; row < mapping.Count; row++)
                {
                    currentLine = mapping[row];
                    for (int col = 0; col < currentLine.Count; col++)
                    {
                        currentPoint = currentLine[col];
                        flashNeighbors(currentPoint, col, row, step);
                    }
                }

                //Debug code
                //for (int row = 0; row < mapping.Count; row++)
                //{
                //    currentLine = mapping[row];
                //    string print = "";                    
                //    for (int col = 0; col < currentLine.Count; col++)
                //    {                        
                //        currentPoint = currentLine[col];
                //        print += currentPoint.energy.ToString();                        
                //    }
                //    Console.WriteLine(print);
                //}
            }
            Console.WriteLine("output: " + step);
        }

        public static void flashNeighbors(point currentPoint, int col, int row, int step)
        {
            if (currentPoint.stepFlashed != step)
            {
                currentPoint.energy++;

            }
            point movingPoint;

            if (currentPoint.energy > 9 && currentPoint.stepFlashed != step)
            {
                flashes++;
                currentFlashes++;
                currentPoint.energy = 0;
                currentPoint.stepFlashed = step;

                if (col != 0)
                {
                    //W
                    movingPoint = mapping[row][col - 1];
                    flashNeighbors(movingPoint, col - 1, row, step);
                }

                if (col < maxLines)
                {
                    //E
                    movingPoint = mapping[row][col + 1];
                    flashNeighbors(movingPoint, col + 1, row, step);
                }
                if (row != 0)
                {
                    //N
                    movingPoint = movingPoint = mapping[row - 1][col];
                    flashNeighbors(movingPoint, col, row - 1, step);
                }
                if (row < maxLines)
                {
                    //S
                    movingPoint = movingPoint = mapping[row + 1][col];
                    flashNeighbors(movingPoint, col, row + 1, step);
                }
                if (col != 0 && row != 0)
                {
                    //NW
                    movingPoint = mapping[row - 1][col - 1];
                    flashNeighbors(movingPoint, col - 1, row - 1, step);
                }
                if (col < maxLines && row != 0)
                {
                    //NE
                    movingPoint = mapping[row - 1][col + 1];
                    flashNeighbors(movingPoint, col + 1, row - 1, step);
                }
                if (col != 0 && row < maxLines)
                {
                    //SW
                    movingPoint = mapping[row + 1][col - 1];
                    flashNeighbors(movingPoint, col - 1, row + 1, step);
                }
                if (col < maxLines && row < maxLines)
                {
                    //SE
                    movingPoint = mapping[row + 1][col + 1];
                    flashNeighbors(movingPoint, col + 1, row + 1, step);
                }
            }
        }

        public class point
        {
            public int energy { get; set; }
            public int stepFlashed { get; set; }

            public point(int inputEnergy)
            {
                energy = inputEnergy;
                stepFlashed = -1;
            }
        }

    }
}
