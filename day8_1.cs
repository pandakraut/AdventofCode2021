using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day8_1
    {

        static void Main(string[] args)
        {
            int count = 0;
            string[] values;
            Dictionary<string, Dictionary<string, int>> mapping;

            foreach (string line in File.ReadLines("../../../InputDay8.txt"))
            {
                mapping = new Dictionary<string, Dictionary<string, int>>();
                values = line.Split('|');              
                foreach (string output in values[1].Split(' '))
                {
                    if (output.Length > 0)
                    {
                        if (output.Length == 7 || output.Length == 4 || output.Length == 3 || output.Length == 2)
                        {
                            count++;                            
                        }                        
                    }
                }
            }

            Console.WriteLine("output: " + count);
        }          
    }
}
