using Pihi.AdventOfCode2022.Common;

namespace Pihi.AdventOfCode2022.Day04
{
    public class Runner : RunnerBase
    {
        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var c = 0;
            foreach (var line in ReadLines())
            {
                var parts = line.Split(',');
                var a = parts[0].Split('-').Select(i => int.Parse(i)).ToArray();
                var b = parts[1].Split('-').Select(i => int.Parse(i)).ToArray();

                if ((a[0] <= b[1] && a[1] >= b[0]) ||
                    (b[0] <= a[1] && b[1] >= a[0]))
                    c++;
            }

            Console.WriteLine(c);
        }
    }
}