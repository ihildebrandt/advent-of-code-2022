using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Day09
{
    internal class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate()
        {

        }

        public Coordinate(Coordinate other)
        {
            X = other.X;
            Y = other.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Coordinate other) return false;
            return other.Y == Y && other.X == X;
        }
    }
}
