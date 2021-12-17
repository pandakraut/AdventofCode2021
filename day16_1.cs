using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day16_1
    {
        public static int totalVersions = 0;
        static void Main(string[] args)
        {
            Dictionary<string, string> hexMap = new Dictionary<string, string>()
            {
                { "0", "0000" },
                { "1", "0001" },
                { "2", "0010" },
                { "3", "0011" },
                { "4", "0100" },
                { "5", "0101" },
                { "6", "0110" },
                { "7", "0111" },
                { "8", "1000" },
                { "9", "1001" },
                { "A", "1010" },
                { "B", "1011" },
                { "C", "1100" },
                { "D", "1101" },
                { "E", "1110" },
                { "F", "1111" }
            };

            Queue<string> input = new Queue<string>();
            foreach (string line in File.ReadLines("../../../InputDay16.txt"))
            {
                foreach (char c1 in line)
                {
                    foreach (char c2 in hexMap[c1.ToString()])
                    {
                        input.Enqueue(c2.ToString());
                    }
                }
            }

            Int64 result = 0;
            while (input.Count > 10)
            {
                result = processCommand(input);
            }
            Console.WriteLine();
            Console.WriteLine("output: " + totalVersions);
        }

        public static Int64 processCommand(Queue<string> input)
        {
            int version = getNextInt(input, 3);
            totalVersions += version;
            int typeId = getNextInt(input, 3);
            if (typeId == 4)
            {
                return getLiteral(input);
            }
            else
            {
                return getOperation(input, typeId);
            }
        }

        public static int getNextInt(Queue<string> input, int total)
        {
            string temp = "";
            for (int i = 0; i < total; i++)
            {
                temp += input.Dequeue();
            }
            return Convert.ToInt32(temp, 2);
        }
        public static string getNextStr(Queue<string> input, int total)
        {
            string temp = "";
            for (int i = 0; i < total; i++)
            {
                temp += input.Dequeue();
            }
            return temp;
        }

        public static Int64 getLiteral(Queue<string> input)
        {
            string temp = "";
            while (input.Dequeue() == "1")
            {
                temp += getNextStr(input, 4);
            }
            temp += getNextStr(input, 4);
            return Convert.ToInt64(temp, 2);
        }

        public static Int64 getOperation(Queue<string> input, int typeId)
        {
            string temp;
            int subPacketLength;
            int numSubPackets;
            List<Int64> currentResults = new List<Int64>();
            Int64 finalResult = -1;
            if (input.Dequeue() == "0")
            {
                subPacketLength = getNextInt(input, 15);
                temp = getNextStr(input, subPacketLength);
                Queue<string> nextQueue = new Queue<string>();
                foreach (char c in temp)
                {
                    nextQueue.Enqueue(c.ToString());
                }
                while (nextQueue.Count != 0)
                {
                    currentResults.Add(processCommand(nextQueue));
                }
            }
            else
            {
                numSubPackets = getNextInt(input, 11);
                for (int i = 0; i < numSubPackets; i++)
                {
                    currentResults.Add(processCommand(input));
                }
            }

            if (typeId == 2)
            {
                finalResult = Int64.MaxValue;
                Console.Write(" min( ");
            }
            else if (typeId == 3)
            {
                Console.Write(" max( ");
            }
            else
            {
                Console.Write("( ");
            }
            foreach (Int64 result in currentResults)
            {
                if (typeId == 0)
                {
                    if (finalResult == -1)
                    {
                        finalResult = result;
                        Console.Write(result);
                    }
                    else
                    {
                        finalResult += result;
                        Console.Write(" + " + result);
                    }                    
                }
                else if (typeId == 1)
                {
                    if (finalResult == -1)
                    {
                        Console.Write(result);
                        finalResult = result;
                    }
                    else
                    {
                        Console.Write(" * " + result);
                        finalResult *= result;
                    }
                }
                else if (typeId == 2)
                {
                    Console.Write(", " + result);
                    if (result < finalResult)
                    {
                        finalResult = result;
                    }
                }
                else if (typeId == 3)
                {
                    Console.Write(", " + result);
                    if (result > finalResult)
                    {
                        finalResult = result;
                    }
                }
                else if (typeId == 5)
                {
                    if (finalResult == -1)
                    {
                        Console.Write(result);
                        finalResult = result;
                    }
                    else if (finalResult > result)
                    {
                        Console.Write(" > " + result);
                        finalResult = 1;
                    }
                    else
                    {
                        Console.Write(" > " + result);
                        finalResult = 0;
                    }
                }
                else if (typeId == 6)
                {
                    if (finalResult == -1)
                    {
                        Console.Write(result);
                        finalResult = result;
                    }
                    else if (finalResult < result)
                    {
                        Console.Write(" < " + result);
                        finalResult = 1;
                    }
                    else
                    {
                        Console.Write(" < " + result);
                        finalResult = 0;
                    }
                }
                else if (typeId == 7)
                {
                    if (finalResult == -1)
                    {
                        Console.Write(result);
                        finalResult = result;
                    }
                    else if (finalResult == result)
                    {
                        Console.Write(" = " + result);
                        finalResult = 1;
                    }
                    else
                    {
                        Console.Write(" = " + result);
                        finalResult = 0;
                    }
                }
            }
            Console.WriteLine(" )");
            return finalResult;
        }

    }
}
