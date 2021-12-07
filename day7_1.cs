using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day7_1
    {

        public static Dictionary<string, int> clouds = new Dictionary<string, int>();
        public static HashSet<string> maxOverlapIndexes = new HashSet<string>();
        public static int maxOverlaps = 2;
        static void Main(string[] args)
        {
            List<int> crabs = new List<int>();
            int median = 0;
            int sum = 0;
            foreach (string line in File.ReadLines("../../../InputDay7.txt"))
            {
                foreach (string crab in line.Split(','))
                {
                    crabs.Add(Convert.ToInt32(crab));
                }
            }
            crabs.Sort();
            if ((crabs.Count - 1) % 2 == 0)
            {
                // count is even, average two middle elements
                int a = crabs[(crabs.Count - 1) / 2 - 1];
                int b = crabs[(crabs.Count - 1) / 2];
                median = (a + b) / 2;
            }
            else
            {
                // count is odd, return the middle element
                median = crabs[crabs.Count / 2];
            }

            foreach (int crab in crabs)
            {
                sum += Math.Abs(crab - median);
            }
            Console.WriteLine("output: " + sum);
        }
    }
}
