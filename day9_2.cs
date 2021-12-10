using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day9_2
    {
        public static List<List<point>> mapping = new List<List<point>>();
        public static int currentBasin;

        static void Main(string[] args)
        {
            List<point> currentLine = new List<point>();
            List<int> largestBasins = new List<int>();

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

            point currentPoint;
            int risk = 0;
            List<lowPoint> lowPointList = new List<lowPoint>();
            for (int row = 0; row < mapping.Count; row++)
            {
                currentLine = mapping[row];
                for (int col = 0; col < currentLine.Count; col++)
                {
                    currentPoint = currentLine[col];
                    if (col == 0 || currentPoint.height < currentLine[col - 1].height)
                    {
                        //check left
                        currentPoint.surround++;
                    }
                    if (col == currentLine.Count - 1 || currentPoint.height < currentLine[col + 1].height)
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
                        lowPointList.Add(new lowPoint(currentPoint, row, col));
                    }
                }
            }

            foreach (lowPoint low in lowPointList)
            {
                currentBasin = 0;
                checkBasin(low.basinFloor, low.column, low.row);
                //check if basin is largest
                if (largestBasins.Count < 3)
                {
                    largestBasins.Add(currentBasin);
                }
                else
                { 
                    for (int i = 0; i < largestBasins.Count; i++)
                    {
                        if (currentBasin > largestBasins[i])
                        {
                            largestBasins[i] = currentBasin;
                            break;
                        }
                    }
                    largestBasins.Sort();
                }
            }            

            foreach (int basin in largestBasins)
            {
                if (risk == 0)
                {
                    risk = basin;
                }
                else
                {
                    risk *= basin;
                }
            }
            Console.WriteLine("output: " + risk);
        }

        public static void checkBasin(point currentPoint, int col, int row)
        {
            List<point> currentList = mapping[row];
            point movingPoint;
            if (currentPoint.height != 9 && currentPoint.inBasin == false)
            {
                currentBasin++;
                currentPoint.inBasin = true;                
            }                       
            else
            {
                return;
            }


            if (col == 0 || currentPoint.height < currentList[col - 1].height)
            {
                //check left
                if (col != 0 && currentList[col - 1].height != 9)
                {                    
                    movingPoint = currentList[col - 1];
                    checkBasin(movingPoint, col - 1, row);                    
                }
            }
            if (col == currentList.Count - 1 || currentPoint.height < currentList[col + 1].height)
            {
                //check right
                if (col != currentList.Count - 1 && currentList[col + 1].height != 9)
                {                    
                    movingPoint = currentList[col + 1];
                    checkBasin(movingPoint, col + 1, row);
                }
            }
            if (row == 0 || currentPoint.height < mapping[row - 1][col].height)
            {
                //check up
                if (row != 0 && mapping[row - 1][col].height != 9)
                {                    
                    movingPoint = mapping[row - 1][col];
                    checkBasin(movingPoint, col, row - 1);
                }
            }
            if (row == mapping.Count - 1 || currentPoint.height < mapping[row + 1][col].height)
            {
                //check down
                if (row != mapping.Count - 1 && mapping[row + 1][col].height != 9)
                {                    
                    movingPoint = mapping[row + 1][col];
                    checkBasin(movingPoint, col, row + 1);
                }
            }            
        }

        public class point
        {
            public int height { get; set; }
            public int left { get; set; }
            public int right { get; set; }
            public int up { get; set; }
            public int down { get; set; }
            public int surround { get; set; }
            public bool inBasin { get; set; }

            public point(int inputHeight)
            {
                height = inputHeight;
                left = 99;
                right = 99;
                up = 99;
                down = 99;
                surround = 0;
                inBasin = false;
            }
        }

        public class lowPoint
        {
            public point basinFloor { get; set; }
            public int row { get; set; }
            public int column { get; set; }            

            public lowPoint(point inputLowPoint, int inputRow, int inputColumn)
            {
                basinFloor = inputLowPoint;
                row = inputRow;
                column = inputColumn;                
            }
        }
    }
}
