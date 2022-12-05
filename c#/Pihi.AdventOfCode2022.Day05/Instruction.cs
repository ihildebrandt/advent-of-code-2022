using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Day05
{
    internal class Instruction
    {
        public int Count { get; }
        public int From { get; }
        public int To { get; }

        public Instruction(string line)
        {
            var match = Regex.Match(line, "move ([\\d]+) from ([\\d]+) to ([\\d]+)");
            Count = int.Parse(match.Groups[1].Value);
            From = int.Parse(match.Groups[2].Value);
            To = int.Parse(match.Groups[3].Value);
        }
    }
}
