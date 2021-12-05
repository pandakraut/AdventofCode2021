using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day5_2
    {
        public static Dictionary<string, int> clouds = new Dictionary<string, int>();
        public static HashSet<string> maxOverlapIndexes = new HashSet<string>();        
        public static int maxOverlaps = 2;
        static void Main(string[] args)
        {
            string[] currentValues;
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            List<(int, int, int, int)> lines = new List<(int, int, int, int)>();

            foreach (string line in File.ReadLines("../../../InputDay5.txt"))
            {
                currentValues = line.Replace(" -> ", ",").Split(',');
                for (int i = 0; i < currentValues.Length; i++)
                {
                    if (i == 0)
                    {
                        x1 = Convert.ToInt32(currentValues[i]);
                    }
                    if (i == 1)
                    {
                        y1 = Convert.ToInt32(currentValues[i]);
                    }
                    if (i == 2)
                    {
                        x2 = Convert.ToInt32(currentValues[i]);
                    }
                    if (i == 3)
                    {
                        y2 = Convert.ToInt32(currentValues[i]);
                    }
                }
                lines.Add((x1, y1, x2, y2));                                
            }
            DoPart(lines, false);

            Console.WriteLine("output: " + maxOverlapIndexes.Count);
        }

        public static void addIndex(string currentIndex)
        {
            if (clouds.ContainsKey(currentIndex))
            {
                clouds[currentIndex]++;
                if (clouds[currentIndex] >= maxOverlaps)
                {
                    if (!maxOverlapIndexes.Contains(currentIndex))
                    {
                        maxOverlapIndexes.Add(currentIndex);
                    }
                }
            }
            else
            {
                clouds.Add(currentIndex, 1);
            }
        }
        public static void DoPart(List<(int x1, int y1, int x2, int y2)> lines, bool skipDiagonals)
        {
            string currentIndex;            
            foreach (var (x1, y1, x2, y2) in lines)
            {
                if (skipDiagonals && x1 != x2 && y1 != y2) continue;

                var xDir = Math.Sign(x2 - x1);
                var yDir = Math.Sign(y2 - y1);
                for (int currentX = x1, currentY = y1; currentX != (x2 + xDir) || currentY != (y2 + yDir); currentX += xDir, currentY += yDir)
                {
                    currentIndex = currentX.ToString() + "-" + currentY.ToString();
                    addIndex(currentIndex);
                }

            }
        }
    }
}
