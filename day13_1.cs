using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day13_1
    {

        static void Main(string[] args)
        {
            Dictionary<int, List<int>> mapping = new Dictionary<int, List<int>>();
            string[] values;
            int yVal = 0;
            int xVal = 0;
            List<KeyValuePair<string, int>> instructionList = new List<KeyValuePair<string, int>>();
            int maxX = 0;
            int maxY = 0;
            int step = 0;

            foreach (string line in File.ReadLines("../../../InputDay13.txt"))
            {
                if (line.Contains(","))
                {
                    values = line.Split(",");
                    xVal = Convert.ToInt32(values[0]);
                    yVal = Convert.ToInt32(values[1]);
                    if (yVal > maxY)
                    {
                        maxY = yVal;
                    }
                    if (xVal > maxX)
                    {
                        maxX = xVal;
                    }
                    if (mapping.ContainsKey(yVal))
                    {
                        mapping[yVal].Add(xVal);
                    }
                    else
                    {
                        mapping.Add(yVal, new List<int>() { xVal });
                    }
                }
                else if (line != "")
                {
                    values = line.Split(" ");
                    values = values[2].Split("=");
                    instructionList.Add(new KeyValuePair<string, int>(values[0], Convert.ToInt32(values[1])));
                }
            }

            foreach (KeyValuePair<string, int> instruction in instructionList)
            {
                if (step == 0)
                {
                    if (instruction.Key == "x")
                    {
                        for (int y = 0; y < maxY; y++)
                        {
                            if (mapping.ContainsKey(y))
                            {
                                for (int x = instruction.Value + 1; x <= maxX; x++)
                                {
                                    if (mapping[y].Contains(x))
                                    {
                                        int updateRow = instruction.Value - (x - instruction.Value);
                                        if (updateRow > 0)
                                        {
                                            if (!mapping[y].Contains(updateRow))
                                            {
                                                mapping[y].Add(updateRow);
                                            }
                                        }
                                        mapping[y].Remove(x);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int y = instruction.Value + 1; y <= maxY; y++)
                        {
                            if (mapping.ContainsKey(y))
                            {
                                int updateLine = instruction.Value - (y - instruction.Value);
                                foreach (int x in mapping[y])
                                {
                                    if (mapping.ContainsKey(updateLine))
                                    {
                                        if (!mapping[updateLine].Contains(x))
                                        {
                                            mapping[updateLine].Add(x);
                                        }
                                    }
                                    else
                                    {
                                        mapping.Add(updateLine, new List<int>() { x });
                                    }
                                }
                                mapping.Remove(y);
                            }
                        }
                    }
                }
                step++;
            }

            int count = 0;
            foreach (List<int> line in mapping.Values)
            {
                foreach (int item in line)
                {
                    count++;
                }
            }

            Console.WriteLine("output: " + count);
        }
    }
}
