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
            int mean = 0;
            int total = 0;
            int sum = 0;
            foreach (string line in File.ReadLines("../../../InputDay7.txt"))
            {
                foreach (string crab in line.Split(','))
                {
                    crabs.Add(Convert.ToInt32(crab));
                    total += Convert.ToInt32(crab);
                }
            }

            mean = (int)Math.Ceiling((double)(total / (crabs.Count)));            

            foreach (int crab in crabs)
            {
                int pos = Math.Abs(crab - mean);
                sum += (pos * (pos + 1)) / 2;
            }
            Console.WriteLine("output: " + sum);
        }
    }
}
