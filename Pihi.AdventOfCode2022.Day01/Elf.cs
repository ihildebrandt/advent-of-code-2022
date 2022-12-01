using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Day01
{
    internal class Elf
    {
        public List<Item> Items = new List<Item>();

        public int Calories => Items.Sum(x => x.Calories);

        public Elf() 
        {
        }
    }
}
