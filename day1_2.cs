using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day1_2
    {
        static void Main(string[] args)
        {
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int current = 0;
            int previous = 0;
            int increase = 0;
            foreach (string line in File.ReadLines("../../../InputDay1_1.txt"))
            {
                current = Int32.Parse(line);
                if (count1 == 0)
                {
                    sum1 += current;
                    count1++;
                    continue;
                }
                if (count1 == 1)
                {
                    sum1 += current;
                    count1++;
                    sum2 += current;
                    count2++;
                    continue;
                }
                if (count1 == 2)
                {
                    sum1 += current;
                    count1++;
                    sum2 += current;
                    count2++;
                    sum3 += current;
                    count3++;
                    continue;
                }
                if (count1 == 3)
                {
                    sum2 += current;
                    count2++;
                    sum3 += current;
                    count3++;

                    if (previous == 0)
                    {
                        previous = sum1;
                    }
                    else if (sum1 > previous)
                    {                        
                        increase++;
                    }
                    previous = sum1;
                    sum1 = sum2;
                    sum2 = sum3;
                    count1 = count2;
                    count2 = count3;
                    sum3 = current;
                    count3 = 1;                    
                }                
            }
            if (sum1 > previous)
            {
                increase++;
            }
            Console.WriteLine("output: " + increase);
        }

    }
}
