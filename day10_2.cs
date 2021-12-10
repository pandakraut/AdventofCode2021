using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day10_1
    {

        static void Main(string[] args)
        {
            Stack<string> currentChars = new Stack<string>();
            List<long> completedLines = new List<long>();

            Dictionary<string, string> mapping = new Dictionary<string, string>()
            {
                {")", "("},
                {"]", "["},
                {"}", "{"},
                {">", "<"}
            };

            Dictionary<string, string> reverseMapping = new Dictionary<string, string>()
            {
                {"(", ")"},
                {"[", "]"},
                {"{", "}"},
                {"<", ">"}
            };

            Dictionary<string, int> scoreMapping = new Dictionary<string, int>()
            {
                {")", 1},
                {"]", 2},
                {"}", 3},
                {">", 4}
            };

            string curChar;
            long score = 0;
            bool corrupted;
            foreach (string line in File.ReadLines("../../../InputDay10.txt"))
            {
                score = 0;
                corrupted = false;
                currentChars.Clear();
                foreach (char c in line)
                {
                    curChar = c.ToString();
                    if (mapping.ContainsKey(curChar))
                    {
                        //closing char
                        if (mapping[curChar] == currentChars.Peek())
                        {
                            //valid
                            currentChars.Pop();
                        }
                        else
                        {
                            //corrupted
                            corrupted = true;
                            break;
                        }
                    }
                    else
                    {
                        //open char
                        currentChars.Push(curChar);
                    }
                }

                if (!corrupted)
                {
                    while (currentChars.Count > 0)
                    {
                        string updatedLine = line + reverseMapping[currentChars.Peek()];
                        score *= 5;
                        score += scoreMapping[reverseMapping[currentChars.Peek()]];
                        currentChars.Pop();
                    }
                    completedLines.Add(score);
                }
            }
            completedLines.Sort();            
            long result = completedLines[(int)Math.Ceiling((double)(completedLines.Count / 2))];

            Console.WriteLine("output: " + result);
        }
    }
}
