using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day3_2
    {
        public static List<char[]> values = new List<char[]>();

        static void Main(string[] args)
        {
            int oxIndex = 0;
            int co2Index = 0;

            List<int> indexes = new List<int>();
            int count = 0;
            foreach (string line in File.ReadLines("../../../InputDay3.txt"))
            {
                values.Add(line.ToCharArray());
                indexes.Add(count);
                count++;
            }

            oxIndex = findValue(indexes, 0, true);
            co2Index = findValue(indexes, 0, false);

            Console.WriteLine("output: " + Convert.ToInt32(new string(values[oxIndex]), 2) * Convert.ToInt32(new string(values[co2Index]), 2));

        }
        public static int findValue(List<int> currentList, int index, bool mostCommon)
        {
            List<int> newOnes = new List<int>();
            List<int> newZeroes = new List<int>();
            int onesCount = 0;
            int zeroCount = 0;
            if (currentList.Count > 1)
            {
                foreach (int i in currentList)
                {
                    if (values[i][index] == '1')
                    {
                        newOnes.Add(i);
                        onesCount++;
                    }
                    else
                    {
                        newZeroes.Add(i);
                        zeroCount++;
                    }
                }
                if (mostCommon)
                {
                    if (onesCount < zeroCount)
                    {
                        return findValue(newZeroes, ++index, mostCommon);
                    }
                    return findValue(newOnes, ++index, mostCommon);
                }
                else
                {
                    if (onesCount < zeroCount)
                    {
                        return findValue(newOnes, ++index, mostCommon);
                    }
                    return findValue(newZeroes, ++index, mostCommon);
                }
            }
            else
            {
                return currentList[0];
            }
        }                         
    }
}
