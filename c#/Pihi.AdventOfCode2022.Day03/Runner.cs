using Pihi.AdventOfCode2022.Common;

namespace Pihi.AdventOfCode2022.Day03
{
    public class Runner : RunnerBase
    {
        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var rucksacks = new List<Rucksack>();
            foreach (var line in ReadLines())
            {
                rucksacks.Add(new Rucksack(line));
            }

            var groups = rucksacks.Count / 3;
            var groupRucksacks = new List<List<Rucksack>>();

            for (var group = 0; group < groups; group++)
            {
                groupRucksacks.Add(rucksacks.Skip(group * 3).Take(3).ToList());
            }

            Console.WriteLine(groupRucksacks.Sum(r => r.GetPriority()));
        }
    }
}