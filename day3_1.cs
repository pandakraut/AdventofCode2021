using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day3_1
    {
        public static List<int> depths = new List<int>();

        static void Main(string[] args)
        {
            string gamma = "";
            string episolon = "";
            int totalLines = 0;
            List<int> counts = new List<int>
            {
                0,0,0,0,0,0,0,0,0,0,0,0
                //0,0,0,0,0
            };
            int count = 0;
            foreach (string line in File.ReadLines("../../../InputDay3.txt"))
            {
                totalLines++;
                count = 0;
                foreach (char a in line)
                {
                    counts[count] += Convert.ToInt32(a.ToString());
                    count++;
                }
            }

            foreach (int total in counts)
            {
                if (totalLines - total < total)
                {
                    gamma += "1";
                    episolon += "0";
                }
                else
                {
                    gamma += "0";
                    episolon += "1";
                }
            }

            Console.WriteLine("output: " + Convert.ToInt32(gamma, 2) * Convert.ToInt32(episolon, 2));
        }
    }
}
