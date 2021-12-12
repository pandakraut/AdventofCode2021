using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day12_1
    {
        public static Dictionary<string, List<string>> mapping = new Dictionary<string, List<string>>();
        public static int paths = 0;
        public static HashSet<string> existingPaths = new HashSet<string>();

        static void Main(string[] args)
        {

            string[] values;

            foreach (string line in File.ReadLines("../../../InputDay12.txt"))
            {
                values = line.Split('-');
                if (mapping.ContainsKey(values[1]))
                {
                    mapping[values[1]].Add(values[0]);
                }
                else
                {
                    mapping.Add(values[1], new List<string>() { values[0] });
                }
                if (mapping.ContainsKey(values[0]))
                {
                    mapping[values[0]].Add(values[1]);
                }
                else
                {
                    mapping.Add(values[0], new List<string>() { values[1] });
                }


            }

            checkAllPaths("end", "");
            Console.WriteLine("output: " + paths);
        }

        public static void checkAllPaths(string endPoint, string currentPath)
        {
            if (endPoint != "start")
            {
                if (mapping.ContainsKey(endPoint))
                {
                    if (endPoint.ToUpper() != endPoint && currentPath.Contains(endPoint))
                    {
                        //invalid path;
                        return;
                    }
                    else
                    {
                        currentPath += endPoint;
                        foreach (string nextPoint in mapping[endPoint])
                        {
                            checkAllPaths(nextPoint, currentPath);
                        }
                    }
                }
            }
            else
            {
                paths++;
            }
        }
    }
}
