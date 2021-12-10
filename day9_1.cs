using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day9_1
    {

        static void Main(string[] args)
        {
            List<point> currentLine = new List<point>();
            List<List<point>> mapping = new List<List<point>>();

            foreach (string line in File.ReadLines("../../../InputDay9.txt"))
            {
                currentLine = new List<point>();
                foreach (char c in line)
                {
                    int height = Convert.ToInt32(c.ToString());
                    currentLine.Add(new point(height));
                }
                mapping.Add(currentLine);
            }

            List<point> currentList;
            point currentPoint;
            int risk = 0;
            for (int row = 0; row < mapping.Count; row++)
            {
                currentList = mapping[row];
                for (int col = 0; col < currentList.Count; col++)
                {
                    currentPoint = currentList[col];
                    if (col == 0 || currentPoint.height < currentList[col - 1].height)
                    {
                        //check left
                        currentPoint.surround++;
                    }
                    if (col == currentList.Count - 1 || currentPoint.height < currentList[col + 1].height)
                    {
                        //check right
                        currentPoint.surround++;
                    }
                    if (row == 0 || currentPoint.height < mapping[row - 1][col].height)
                    {
                        //check up
                        currentPoint.surround++;
                    }
                    if (row == mapping.Count - 1 || currentPoint.height < mapping[row + 1][col].height)
                    {
                        //check down
                        currentPoint.surround++;
                    }
                    if (currentPoint.surround == 4)
                    {
                        risk += 1 + currentPoint.height;
                    }

                }
            }
            Console.WriteLine("output: " + risk);
        }

        public class point
        {
            public int height { get; set; }
            public int left { get; set; }
            public int right { get; set; }

            public int up { get; set; }
            public int down { get; set; }
            public int surround { get; set; }

            public point(int inputHeight)
            {
                height = inputHeight;
                left = 99;
                right = 99;
                up = 99;
                down = 99;
                surround = 0;
            }
        }
    }
}
