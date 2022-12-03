using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Day03
{
    internal static class Extensions
    {
        public static int GetPriority(this char item)
        {
            if (!char.IsLetter(item)) throw new Exception();

            if (char.IsLower(item))
            {
                return ((int)item - (int)'a') + 1;
            }

            return ((int)item - (int)'A') + 27;
        }

        public static int GetPriority(this List<Rucksack> groupRucksacks)
        {
            foreach (var itemA in groupRucksacks[0].Contents)
            {
                foreach (var itemB in groupRucksacks[1].Contents)
                {
                    if (itemA != itemB) continue;

                    foreach(var itemC in groupRucksacks[2].Contents)
                    {
                        if (itemB != itemC) continue;
                        return GetPriority(itemA);
                    }
                }
            }

            throw new Exception();
        }
    }
}
