using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day2_1
    {
        public static List<int> depths = new List<int>();

        static void Main(string[] args)
        {
            string[] values;

            int currentHoriz = 0;
            int currentDepth = 0;
            foreach (string line in File.ReadLines("../../../InputDay2.txt"))
            {
                values = line.Split(' ');

                if (values[0] == "forward")
                {
                    currentHoriz += Convert.ToInt32(values[1]);
                }
                if (values[0] == "down")
                {
                    currentDepth += Convert.ToInt32(values[1]);
                }
                if (values[0] == "up")
                {
                    currentDepth -= Convert.ToInt32(values[1]);
                }
            }

            Console.WriteLine("output: " + currentHoriz * currentDepth);
        }
    }
}
