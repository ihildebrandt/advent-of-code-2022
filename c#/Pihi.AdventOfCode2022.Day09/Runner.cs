using Pihi.AdventOfCode2022.Common;

namespace Pihi.AdventOfCode2022.Day09
{
    public class Runner : RunnerBase
    {
        private readonly ISet<Coordinate> _visitedPositions = new HashSet<Coordinate>();

        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            IList<Vector> moves = new List<Vector>();
            foreach (var  line in ReadLines())
            {
                var parts = line.Split(' ');
                var direction = parts[0][0];
                var magnitude = int.Parse(parts[1]);
                moves.Add(new Vector { Direction = direction, Magnitude = magnitude });
            }

            var rope = new Coordinate[10]
            {
                new Coordinate(),
                new Coordinate(),
                new Coordinate(),
                new Coordinate(),
                new Coordinate(),
                new Coordinate(),
                new Coordinate(),
                new Coordinate(),
                new Coordinate(),
                new Coordinate()
            };

            foreach (var move in moves)
            {

                for (var m = move.Magnitude; m > 0; m--)
                {

                    MoveHead(rope[0], move.Direction);


                    for (var k = 1; k < rope.Length; k++)
                    {
                        MoveTail(rope[k - 1], rope[k]);
                    }

                    _visitedPositions.Add(new Coordinate(rope.Last()));
                }
            }

            Console.WriteLine(_visitedPositions.Count);
        }

        private void MoveHead(Coordinate position, char direction)
        {
            switch (direction)
            {
                case 'U':
                    position.Y--;
                    break;
                case 'D':
                    position.Y++;
                    break;
                case 'L':
                    position.X--;
                    break;
                case 'R':
                    position.X++;
                    break;
            }
        }

        private void MoveTail(Coordinate head, Coordinate tail)
        {
            var hD = tail.X - head.X;
            var vD = tail.Y - head.Y;
            var ahD = Math.Abs(hD);
            var avD = Math.Abs(vD);

            // If adjacent don't move
            if (avD <= 1 && ahD <= 1) return;

            if (avD > 1) // Need to move vertically
            {
                var vM = vD > 0 ? -1 : 1;
                tail.Y = tail.Y + vM;

                if (ahD > 0) // Need to move horizontally
                {
                    var hM = hD > 0 ? -1 : 1;
                    tail.X = tail.X + hM;
                }

                return;
            }

            if (ahD > 1) // Need to move horizontally
            {
                var hM = hD > 0 ? -1 : 1;
                tail.X = tail.X + hM;

                if (avD > 0) // Need to move vertically
                {
                    var vM = vD > 0 ? -1 : 1;
                    tail.Y = tail.Y + vM;
                }

                return;
            }
        }
    }
}