using Pihi.AdventOfCode2022.Common;
using System.Diagnostics;

namespace Pihi.AdventOfCode2022.Day12
{
    public class Runner : RunnerBase
    {
        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var width = 0;
            var height = 0;

            var lines = new List<string>();
            foreach (var line in ReadLines())
            {
                if (width == 0) width = line.Length;
                lines.Add(line);
                height++;
            }

            int startX = 0, startY = 0;
            int endX = 0, endY = 0;

            var grid = new Node[height,width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var c = lines[y][x];
                    switch (c)
                    {
                        case 'S':
                            startX = x;
                            startY = y;
                            grid[y, x] = new Node(0, x, y);
                            break;
                        case 'E':
                            endX = x;
                            endY = y;
                            grid[y, x] = new Node((int)'z' - (int)'a' + 1, x, y);
                            break;
                        default:
                            grid[y,x] = new Node((int)c - (int)'a' + 1, x, y);
                            break;
                    }
                }
            }

            var startingPoints = new List<Node>();
            var distances = new List<int>();

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (grid[y,x].Height == 1)
                    {
                        startingPoints.Add(grid[y, x]);
                    }
                }
            }

            foreach (var startingPoint in startingPoints)
            {
                var openList = new List<Node> { startingPoint };

                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        grid[y, x].G = int.MaxValue / 2;
                    }
                }

                startingPoint.G = 0;

                do
                {
                    openList.Sort();

                    var node = openList[0];
                    openList.RemoveAt(0);

                    if (node.X == endX && node.Y == endY)
                    {
                        distances.Add(node.G);
                        break;
                    }

                    var neighbors = new List<(int y, int x)>();

                    if (node.Y > 0)
                        neighbors.Add((node.Y - 1, node.X));

                    if (node.Y < height - 1)
                        neighbors.Add((node.Y + 1, node.X));

                    if (node.X > 0)
                        neighbors.Add((node.Y, node.X - 1));

                    if (node.X < width - 1)
                        neighbors.Add((node.Y, node.X + 1));

                    foreach (var neighbor in neighbors)
                    {
                        int testG = node.G + 1;
                        var nextNode = grid[neighbor.y, neighbor.x];

                        if (node.CanReach(nextNode))
                        {
                            if (testG <= nextNode.G)
                            {
                                nextNode.G = testG;
                                nextNode.H = Math.Abs(endX - nextNode.X) + Math.Abs(endY - nextNode.Y);
                                if (!openList.Any(n => n.X == nextNode.X && n.Y == nextNode.Y))
                                {
                                    openList.Add(nextNode);
                                }
                            }
                        }
                    };
                } while (openList.Any());
            }

            Console.WriteLine(distances.OrderBy(d => d).Take(1).First());
        }
    }

    public class Node : IComparable<Node>
    {
        public int G { get; set; }
        public int H { get; set; }
        public int F => G + H;

        public int X { get; set; }
        public int Y { get; set; }

        public int Height { get; set; }

        public Node(int height, int x, int y)
        {
            Height = height;
            G = int.MaxValue / 2;
            X = x;
            Y = y;
        }

        public bool CanReach(Node other)
        {
            return other.Height <= Height + 1;
        }

        public int CompareTo(Node? other)
        {
            return F.CompareTo(other?.F);
        }
    }
}