using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Day01
{
    internal class Item
    {
        public int Calories { get; }

        public Item(string line)
        {
            Calories = int.Parse(line);
        }
    }
}
