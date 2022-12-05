using Pihi.AdventOfCode2022.Common;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Pihi.AdventOfCode2022.Day05
{
    public class Runner : RunnerBase
    {
        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var stackWidth = 4;
            var readInstructions = false;
            var instructions = new List<Instruction>();
            LinkedList<Char>[] stacks = null;

            foreach (var line in ReadLines())
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    readInstructions = true;
                    continue;
                }

                if (readInstructions)
                {
                    instructions.Add(new Instruction(line));
                }
                else
                {
                    var stackCount = (int)Math.Ceiling((float)line.Length / stackWidth);
                    if (stacks == null)
                    {
                        stacks = new LinkedList<char>[stackCount];
                        for (var i = 0; i < stackCount; i++)
                        {
                            stacks[i] = new LinkedList<Char>();
                        }
                    }

                    for (var i = 0; i < stackCount; i++)
                    {
                        var maybeCrate = line.Substring(i * stackWidth, 3);
                        if (!string.IsNullOrWhiteSpace(maybeCrate))
                        {
                            var crate = maybeCrate[1];
                            stacks[i].AddLast(crate);
                        }
                    }
                }
            }

            foreach (var instruction in instructions)
            {
                var pickup = new LinkedList<Char>();
                for (var i = 0; i < instruction.Count; i++)
                {
                    var c = stacks[instruction.From - 1].First.Value;
                    stacks[instruction.From - 1].RemoveFirst() ;
                    pickup.AddLast(c);
                }

                while (pickup.Any())
                {
                    var c = pickup.Last.Value;
                    pickup.RemoveLast();
                    stacks[instruction.To - 1].AddFirst(c);
                }
            }

            var sb = new StringBuilder();
            foreach (var stack in stacks)
            {
                sb.Append(stack.First.Value);
            }

            Console.WriteLine(sb);
        }
    }
}