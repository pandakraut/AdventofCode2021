using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day15_1
    {
        public static Dictionary<Location, int> costMap = new Dictionary<Location, int>();

        static void Main(string[] args)
        {
            var grid = new SquareGrid(100, 100);
            int risk = 0;
            int y = 0;
            int x = 0;
            Location curLoc;
            foreach (string line in File.ReadLines("../../../InputDay15.txt"))
            {
                foreach (char c in line)
                {
                    risk = Convert.ToInt32(c.ToString());
                    curLoc = new Location(x, y);
                    grid.points.Add(curLoc);
                    costMap.Add(curLoc, risk);
                    x++;
                }
                y++;
                x = 0;
            }

            // Run A* -- remove heuristic to be dijkstra instead of A*
            var astar = new AStarSearch(grid, new Location(0, 0),
                                        new Location(99, 99));

            Console.WriteLine("output: " + astar.costSoFar[new Location(99, 99)]);
        }
        public class SquareGrid : WeightedGraph<Location>
        {
            public static readonly Location[] DIRS = new[]
                {
                    new Location(1, 0),
                    new Location(0, -1),
                    new Location(-1, 0),
                    new Location(0, 1)
                };

            public int width, height;
            public HashSet<Location> points = new HashSet<Location>();

            public SquareGrid(int width, int height)
            {
                this.width = width;
                this.height = height;
            }

            public bool InBounds(Location id)
            {
                return 0 <= id.x && id.x < width
                    && 0 <= id.y && id.y < height;
            }

            public int Cost(Location a, Location b)
            {
                return costMap[b];
            }

            public IEnumerable<Location> Neighbors(Location id)
            {
                foreach (var dir in DIRS)
                {
                    Location next = new Location(id.x + dir.x, id.y + dir.y);
                    if (InBounds(next))
                    {
                        yield return next;
                    }
                }
            }
        }

        public class PriorityQueue<T>
        {
            private List<Tuple<T, double>> elements = new List<Tuple<T, double>>();

            public int Count
            {
                get { return elements.Count; }
            }

            public void Enqueue(T item, double priority)
            {
                elements.Add(Tuple.Create(item, priority));
            }

            public T Dequeue()
            {
                int bestIndex = 0;

                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Item2 < elements[bestIndex].Item2)
                    {
                        bestIndex = i;
                    }
                }

                T bestItem = elements[bestIndex].Item1;
                elements.RemoveAt(bestIndex);
                return bestItem;
            }
        }

        public class AStarSearch
        {
            public Dictionary<Location, Location> cameFrom = new Dictionary<Location, Location>();
            public Dictionary<Location, double> costSoFar = new Dictionary<Location, double>();

            public AStarSearch(WeightedGraph<Location> graph, Location start, Location goal)
            {
                var frontier = new PriorityQueue<Location>();
                frontier.Enqueue(start, 0);

                cameFrom[start] = start;
                costSoFar[start] = 0;

                while (frontier.Count > 0)
                {
                    var current = frontier.Dequeue();

                    if (current.Equals(goal))
                    {
                        break;
                    }

                    foreach (var next in graph.Neighbors(current))
                    {
                        double newCost = costSoFar[current]
                            + graph.Cost(current, next);
                        if (!costSoFar.ContainsKey(next)
                            || newCost < costSoFar[next])
                        {
                            costSoFar[next] = newCost;
                            double priority = newCost;
                            frontier.Enqueue(next, priority);
                            cameFrom[next] = current;
                        }
                    }
                }
            }
        }

        public interface WeightedGraph<L>
        {
            int Cost(Location a, Location b);
            IEnumerable<Location> Neighbors(Location id);
        }

        public struct Location
        {
            public readonly int x, y;
            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
