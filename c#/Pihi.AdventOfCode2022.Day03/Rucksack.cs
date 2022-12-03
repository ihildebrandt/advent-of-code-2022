using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Day03
{
    internal class Rucksack
    {
        private readonly string _contents;
        private readonly string _compartmentA;
        private readonly string _compartmentB;

        public char SharedItem { get; }
        public IEnumerable<char> Contents => _contents;

        public Rucksack(string contents)
        {
            _contents = contents;

            var length = contents.Length / 2;
            _compartmentA = contents.Substring(0, length);
            _compartmentB = contents.Substring(length);

            foreach (var itemA in _compartmentA)
            {
                foreach (var itemB in _compartmentB)
                {
                    if (itemA == itemB)
                    {
                        SharedItem = itemA;
                        return;
                    }
                }
            }
        }
    }
}
