using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day1_1
    {
        static void Main(string[] args)
        {
            int previous = 0;
            int increase = 0;
            foreach (string line in File.ReadLines("../../../InputDay1_1.txt"))
            {
                int current = Int32.Parse(line);
                if (previous == 0)
                {
                    previous = current;
                }
                else if (current > previous)
                {
                    increase++;
                }
                previous = current;
            }
            Console.WriteLine("output: " + increase);
        }

    }
}
