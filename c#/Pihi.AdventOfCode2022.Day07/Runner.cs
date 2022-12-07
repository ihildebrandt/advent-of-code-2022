using Pihi.AdventOfCode2022.Common;
using System.Diagnostics;

namespace Pihi.AdventOfCode2022.Day07
{
    public class Runner : RunnerBase
    {
        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var root = new FileSystemNode("/");
            var current = root;

            var readingLs = false;

            foreach (var line in ReadLines())
            {
                var parts = line.Split(' ');
                if (parts[0] == "$")
                {
                    readingLs = false;
                    switch (parts[1])
                    {
                        case "cd":
                            if (parts[2] == "/")
                            {
                                current = root;
                            }
                            else if (parts[2] == "..")
                            {
                                current = current.Parent;
                            }
                            else
                            {
                                current = current.Children.Single(c => c.Name == parts[2]);
                            }
                            break;
                        case "ls":
                            readingLs = true;
                            break;
                    }
                }
                else if (readingLs)
                {
                    if (parts[0] == "dir")
                    {
                        var directory = new FileSystemNode(parts[1], current);
                        current.Children.Add(directory);
                    }
                    else
                    {
                        var size = int.Parse(parts[0]);
                        var file = new FileSystemNode(parts[1], current, size);
                        current.Children.Add(file);
                    }
                }
            }

            //var ds = root.FindDirectories().Where(d => d.Size <= 100000).ToArray();

            var totalSpace = 70000000;
            var requiredSpace = 30000000;

            var availableSpace = totalSpace - root.Size;
            var neededSpace = requiredSpace - availableSpace;

            var ds = root.FindDirectories().Where(d => d.Size > neededSpace).OrderBy(d => d.Size).ToArray();

            Console.WriteLine(ds.First().Size);
        }
    }
}