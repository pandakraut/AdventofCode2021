using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day14_2
    {
        public static Dictionary<string, long> trackChars = new Dictionary<string, long>();
        public static Dictionary<string, long> trackPairs = new Dictionary<string, long>();
        public static Dictionary<string, long> newPairs = new Dictionary<string, long>();

        static void Main(string[] args)
        {
            string[] values;
            Dictionary<string, string> mapping = new Dictionary<string, string>();            
            string template = "";
            int maxSteps = 40;

            foreach (string line in File.ReadLines("../../../InputDay14.txt"))
            {
                if (template.Length == 0)
                {
                    template = line;
                }
                else if (line.Length > 0)
                {
                    values = line.Replace(" -> ", ",").Split(',');
                    mapping.Add(values[0], values[1]);
                }            
            }
           
            string currentPair = "";
            for (int i = 0; i < template.Length - 1; i++)
            {
                currentPair = template[i].ToString() + template[i + 1].ToString();
                if (trackPairs.ContainsKey(currentPair))
                {
                    trackPairs[currentPair]++;
                }
                else
                {
                    trackPairs.Add(currentPair, 1);
                }
            }

            string leftPart = "";
            string rightPart = "";
            for (int step = 0; step < maxSteps; step++)
            {
                newPairs = new Dictionary<string, long>();
                foreach (KeyValuePair<string, long> pair in trackPairs)
                {
                    if (mapping.ContainsKey(pair.Key))
                    {
                        leftPart = pair.Key[0].ToString() + mapping[pair.Key];
                        rightPart = mapping[pair.Key] + pair.Key[1].ToString();
                        addPairs(leftPart, pair.Value);
                        addPairs(rightPart, pair.Value);
                    }
                    
                }
                trackPairs = newPairs;
            }

            findCounts();

            long max = 0;
            long min = long.MaxValue;
            foreach (KeyValuePair<string, long> total in trackChars)
            {
                if (total.Value > max)
                {
                    max = total.Value;
                }
                if (total.Value < min)
                {
                    min = total.Value;
                }
            }
            long output = (max / 2) - (min / 2);

            Console.WriteLine("output: " + template.Length);
        }

        public static void addPairs(string inputTemplate, long value)
        {
            if (newPairs.ContainsKey(inputTemplate))
            {
                newPairs[inputTemplate]+= value;
            }
            else
            {
                newPairs.Add(inputTemplate, value);
            }
        }

        public static void findCounts()
        {            
            foreach (KeyValuePair<string, long> pair in trackPairs)
            {
                if (trackChars.ContainsKey(pair.Key[0].ToString()))
                {
                    trackChars[pair.Key[0].ToString()]+= pair.Value;
                }
                else
                {
                    trackChars.Add(pair.Key[0].ToString(), pair.Value);
                }

                if (trackChars.ContainsKey(pair.Key[1].ToString()))
                {
                    trackChars[pair.Key[1].ToString()]+= pair.Value;
                }
                else
                {
                    trackChars.Add(pair.Key[1].ToString(), pair.Value);
                }

            }           
        }
    }
}
