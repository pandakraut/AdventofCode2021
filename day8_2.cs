using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class day8_2
    {
        public static Dictionary<string, int> mapping = new Dictionary<string, int>();
        public static Dictionary<int, string> reverseMapping = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            int mapsTo = 0;
            int totalMapped = 0;
            string[] values;
            int matches = 0;
            string sortedSignal = "";
            int outputValue = 0;

            foreach (string line in File.ReadLines("../../../InputDay8.txt"))
            {
                mapping = new Dictionary<string, int>();
                reverseMapping = new Dictionary<int, string>();
                totalMapped = 0;
                values = line.Split('|');
                
                foreach (string signal in values[0].Split(' '))
                {
                    sortedSignal = SortString(signal);
                    mapsTo = -1;
                    if (sortedSignal.Length > 0)
                    {                        
                        //signals.Add(signal);
                        if (sortedSignal.Length == 7)
                        {
                            //displays as 8  
                            mapsTo = 8;
                            totalMapped++;
                        }
                        else if (sortedSignal.Length == 4)
                        {
                            //displays as 4
                            mapsTo = 4;
                            totalMapped++;
                        }
                        else if (sortedSignal.Length == 3)
                        {
                            //displays as 7
                            mapsTo = 7;
                            totalMapped++;
                        }
                        else if (sortedSignal.Length == 2)
                        {
                            //displays as 1
                            mapsTo = 1;
                            totalMapped++;
                        }
                        mapping.Add(sortedSignal, mapsTo);
                        if (mapsTo >= 0)
                        {
                            reverseMapping.Add(mapsTo, sortedSignal);
                        }
                    }
                }
                while (totalMapped < 10)
                {
                    matches = 0;
                    foreach (string signal in mapping.Keys)
                    {
                        if (signal.Length > 0 && mapping[signal] < 0)
                        {                            
                            if (signal.Length == 6)
                            {
                                //either 9, 6, 0
                                matches = 0;
                                foreach (char a in reverseMapping[1])
                                if (signal.Contains(a))
                                {
                                    matches++;
                                }
                                if (matches == reverseMapping[1].Length)
                                {
                                    //is 9 or 0 
                                    matches = 0;
                                    foreach (char a in reverseMapping[4])
                                        if (signal.Contains(a))
                                        {
                                            matches++;
                                        }
                                    if (matches == reverseMapping[4].Length)
                                    {
                                        //is 9                                    
                                        totalMapped++;
                                        reverseMapping.Add(9, signal);
                                        mapping[signal] = 9;
                                        break;
                                    }
                                    else
                                    {
                                        //is 0             
                                        totalMapped++;
                                        reverseMapping.Add(0, signal);
                                        mapping[signal] = 0;
                                        break;
                                    }
                                }
                                else
                                {
                                    //is 6
                                    totalMapped++;
                                    reverseMapping.Add(6, signal);
                                    mapping[signal] = 6;
                                    break;
                                }                                                         
                            }
                            else if (signal.Length == 5)
                            {
                                //either 5, 2, 3 
                                matches = 0;
                                foreach (char a in reverseMapping[7])
                                    if (signal.Contains(a))
                                    {
                                        matches++;
                                    }
                                if (matches == reverseMapping[7].Length)
                                {
                                    //is 3                                    
                                    totalMapped++;
                                    reverseMapping.Add(3, signal);
                                    mapping[signal] = 3;
                                    break;
                                }
                                else
                                {
                                    //is 5 or 2      
                                    matches = 0;
                                    if (reverseMapping.ContainsKey(9))
                                    { 
                                        foreach (char a in reverseMapping[9])
                                            if (signal.Contains(a))
                                            {
                                                matches++;
                                            }
                                        if (matches == signal.Length)
                                        {
                                            //is 5                                    
                                            totalMapped++;
                                            reverseMapping.Add(5, signal);
                                            mapping[signal] = 5;
                                            break;
                                        }
                                        else
                                        {
                                            //is 2             
                                            totalMapped++;
                                            reverseMapping.Add(2, signal);
                                            mapping[signal] = 2;
                                            break;
                                        }
                                    }
                                }
                            }
                            //mapping[signal] = mapsTo;
                        }
                    }
                }

                string outputString = "";
                foreach (string output in values[1].Split(' '))
                {
                    if (output.Length > 0)
                    {
                        outputString += mapping[SortString(output)].ToString();                        
                    }
                }
                outputValue += Convert.ToInt32(outputString);
            }

            Console.WriteLine("output: " + outputValue);
        }

        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
}
