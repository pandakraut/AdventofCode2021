using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day6_1
    {
        public static List<int> depths = new List<int>();

        static void Main(string[] args)
        {
            List<int> fishPop = new List<int>();
            int numDays = 1;
            int maxDays = 80;

            foreach (string line in File.ReadLines("../../../InputDay6.txt"))
            {
                foreach (string fish in line.Split(','))
                {
                    fishPop.Add(Convert.ToInt32(fish));
                }
            }

            while (numDays <= maxDays)
            {
                for (int i = fishPop.Count - 1; i >= 0; i--)
                {
                    if (fishPop[i] == 0)
                    {
                        fishPop.Add(8);
                        fishPop[i] = 6;
                    }
                    else
                    {
                        fishPop[i]--;
                    }
                }
                numDays++;
            }

            Console.WriteLine("output: " + fishPop.Count);
        }
    }
}
