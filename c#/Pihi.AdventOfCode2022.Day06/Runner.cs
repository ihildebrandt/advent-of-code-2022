using Pihi.AdventOfCode2022.Common;

namespace Pihi.AdventOfCode2022.Day06
{
    public class Runner : RunnerBase
    {
        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var line = ReadLines().ElementAt(0);
            for (var i = 0; i < line.Length - 14; i++)
            {
                var segment = line.Substring(i, 14);
                if (segment.Distinct().Count() == 14)
                {
                    Console.WriteLine(i + 14);
                    return;
                }
            }
        }
    }
}