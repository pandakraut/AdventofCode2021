using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day10_1
    {

        static void Main(string[] args)
        {
            int count = 0;
            Stack<string> currentChars = new Stack<string>();

            Dictionary<string, string> mapping = new Dictionary<string, string>()
            {
                {")", "("},
                {"]", "["},
                {"}", "{"},
                {">", "<"}
            };

            Dictionary<string, int> scoreMapping = new Dictionary<string, int>()
            {
                {")", 3},
                {"]", 57},
                {"}", 1197},
                {">", 25137}
            };

            string curChar;
            int score = 0;
            foreach (string line in File.ReadLines("../../../InputDay10.txt"))
            {
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
                            score += scoreMapping[curChar];
                            break;
                        }
                    }
                    else
                    {
                        //open char
                        currentChars.Push(curChar);
                    }
                }
            }

            Console.WriteLine("output: " + score);
        }
    }
}
