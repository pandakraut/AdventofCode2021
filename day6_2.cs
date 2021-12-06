using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day6_2
    {
        public static List<int> depths = new List<int>();

        static void Main(string[] args)
        {
            List<int> fishPop = new List<int>();
            int numDays = 1;
            int maxDays = 256;
            List<generations> generations = new List<generations>();

            foreach (string line in File.ReadLines("../../../InputDay6.txt"))
            {
                foreach (string fish in line.Split(','))
                {
                    fishPop.Add(Convert.ToInt32(fish));
                }
            }

            while (numDays <= maxDays)
            {
                long spawned = 0;
                for (int i = fishPop.Count -1; i >= 0; i--)
                {
                    if (fishPop[i] == 0)
                    {
                        spawned++;                        
                        fishPop[i] = 6;
                    }
                    else
                    {
                        fishPop[i]--;
                    }
                }
                if (generations.Count > 0)
                {
                    foreach (generations currentGen in generations)
                    {
                        if (currentGen.tilSpawn == 0)
                        {
                            spawned += currentGen.count;
                            currentGen.tilSpawn = 6;
                        }
                        else
                        {
                            currentGen.tilSpawn--;
                        }
                    }
                }
                if (spawned > 0)
                { 
                    generations.Add(new generations(8, spawned));
                }
                numDays++;
            }

            long total = fishPop.Count;
            foreach (generations currentGen in generations)
            {
                total += currentGen.count;
            }
            Console.WriteLine("output: " + total);
        }
    }

    public class generations
    {
        public long tilSpawn { get; set; }
        public long count { get; set; }        

        public generations(long numDays, long currentCount)
        {
            tilSpawn = numDays;
            count = currentCount;            
        }
    }
}
