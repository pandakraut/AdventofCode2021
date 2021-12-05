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
            string currentIndex;
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            int temp = 0;
                        
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
                if (x1 == x2 || y1 == y2)
                { 
                    if (x1 > x2)
                    {
                        temp = x1;
                        x1 = x2;
                        x2 = temp;
                    }
                    if (y1 > y2)
                    {
                        temp = y1;
                        y1 = y2;
                        y2 = temp;
                    }

                    for (int currentX = x1; currentX <= x2; currentX++)
                    {
                        for (int currentY = y1; currentY <= y2; currentY++)
                        {
                            currentIndex = currentX.ToString() + "-" + currentY.ToString();
                            addIndex(currentIndex);                            
                        }
                    }
                }
                else if (x1 > x2)
                {
                    if (y1 > y2)
                    {
                        int currentX = x1;
                        int currentY = y1;
                        while (currentX != x2 && currentY != y2)
                        {
                            currentIndex = currentX.ToString() + "-" + currentY.ToString();
                            addIndex(currentIndex);
                            currentX--;
                            currentY--;
                        }
                        currentIndex = currentX.ToString() + "-" + currentY.ToString();
                        addIndex(currentIndex);
                    }
                    else
                    {
                        int currentX = x1;
                        int currentY = y1;
                        while (currentX != x2 && currentY != y2)
                        {
                            currentIndex = currentX.ToString() + "-" + currentY.ToString();
                            addIndex(currentIndex);
                            currentX--;
                            currentY++;
                        }
                        currentIndex = currentX.ToString() + "-" + currentY.ToString();
                        addIndex(currentIndex);
                    }
                }
                else
                {
                    if (y1 > y2)
                    {
                        int currentX = x1;
                        int currentY = y1;
                        while (currentX != x2 && currentY != y2)
                        {
                            currentIndex = currentX.ToString() + "-" + currentY.ToString();
                            addIndex(currentIndex);
                            currentX++;
                            currentY--;
                        }
                        currentIndex = currentX.ToString() + "-" + currentY.ToString();
                        addIndex(currentIndex);
                    }
                    else
                    {
                        int currentX = x1;
                        int currentY = y1;
                        while (currentX != x2 && currentY != y2)
                        {
                            currentIndex = currentX.ToString() + "-" + currentY.ToString();
                            addIndex(currentIndex);
                            currentX++;
                            currentY++;
                        }
                        currentIndex = currentX.ToString() + "-" + currentY.ToString();
                        addIndex(currentIndex);
                    }
                }                
            }
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
    }
}
