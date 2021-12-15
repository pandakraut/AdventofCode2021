using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day14_1
    {
        public static Dictionary<string, int> trackChars = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            string[] values;
            Dictionary<string, string> mapping = new Dictionary<string, string>();
            string template = "";
            int maxSteps = 10;

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

            int step = 0;
            string newTemplate = "";
            string currentPair = "";
            while (step < maxSteps)
            {
                for (int i = 0; i < template.Length - 1; i++)
                {
                    currentPair = template[i].ToString() + template[i + 1].ToString();
                    if (mapping.ContainsKey(currentPair))
                    {
                        newTemplate += template[i].ToString() + mapping[currentPair];
                    }

                }
                newTemplate += template[template.Length - 1].ToString();
                template = newTemplate;
                newTemplate = "";
                step++;
            }

            findCounts(template);


            Console.WriteLine("output: " + template.Length);
        }

        public static void findCounts(string inputTemplate)
        {
            foreach (char c in inputTemplate)
            {
                if (trackChars.ContainsKey(c.ToString()))
                {
                    trackChars[c.ToString()]++;
                }
                else
                {
                    trackChars.Add(c.ToString(), 1);
                }
            }
        }
    }
}
