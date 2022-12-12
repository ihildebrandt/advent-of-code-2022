using Pihi.AdventOfCode2022.Common;
using System.Diagnostics;

namespace Pihi.AdventOfCode2022.Day11
{
    public class Runner : RunnerBase
    {
        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var monkeys = new List<Monkey>();
            IList<string> monkeyLines = null;

            foreach (var line in ReadLines())
            {
                var clean = line.Trim();
                if (clean.StartsWith("Monkey"))
                {
                    monkeyLines = new List<string>();
                }
                else if (string.IsNullOrWhiteSpace(clean))
                {
                    var monkey = Monkey.ParseMonkey(monkeyLines);
                    monkeys.Add(monkey);
                }
                else
                {
                    monkeyLines.Add(clean);
                }
            }

            if (monkeyLines.Any())
            {
                monkeys.Add(Monkey.ParseMonkey(monkeyLines));
            }

            for (var round = 0; round < 20; round++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.TryDequeue(out var item))
                    {
                        item = monkey.Operation(item);
                        // item = item / 3;

                        var next = monkey.FalseResult;
                        if ((item % monkey.DivisibilityTest) == 0)
                        {
                            next = monkey.TrueResult;
                        }

                        monkey.InspectionCount++;
                        monkeys[next].Items.Enqueue(item);
                    }
                }
            }

            var mostActive = monkeys.OrderByDescending(m => m.InspectionCount).Take(2).ToArray();
            Console.WriteLine(mostActive[0].InspectionCount * mostActive[1].InspectionCount);
        }
    }
}