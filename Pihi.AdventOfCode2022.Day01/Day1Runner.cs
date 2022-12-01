﻿using Pihi.AdventOfCode2022.Common;

namespace Pihi.AdventOfCode2022.Day01
{
    public class Day1Runner : RunnerBase
    {
        public Day1Runner(Stream inputStream) : base(inputStream)
        {
        }

        public void Run()
        {
            var elves = new List<Elf>();
            var elf = new Elf();

            elves.Add(elf);

            foreach (var line in ReadLines())
            {
                if (string.IsNullOrEmpty(line))
                {
                    elf = new Elf();
                    elves.Add(elf);
                    continue;
                }
                elf.Items.Add(new Item(line));
            }

            var calories = elves.OrderByDescending(e => e.Calories).Take(3).Sum(e => e.Calories);
            Console.WriteLine(calories);
        }
    }
}