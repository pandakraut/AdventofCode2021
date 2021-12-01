using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day1_2
    {        
        public static List<int> depths = new List<int>();

        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines("../../../InputDay1_1.txt"))
            {
                depths.Add(int.Parse(line));
            }

            int countIncrease = findDepth(3);

            Console.WriteLine("output: " + countIncrease);
        }

        public static int findDepth(int window)
        {
            int increase = 0;

            for (int currentDepth = 0; currentDepth < depths.Count - window; currentDepth++)
            {
               if (windowTotal(currentDepth, window) < windowTotal(currentDepth + 1, window))
               {
                    increase++;
               }
            }
            return increase;
        }

        public static int windowTotal(int startIndex, int window)
        {
            int total = 0;
            for (int windowDepth = 0; windowDepth < window; windowDepth++)
            {
                total += Convert.ToInt32(depths[startIndex + windowDepth]);
            }
            return total;           
        }    
    }
}
