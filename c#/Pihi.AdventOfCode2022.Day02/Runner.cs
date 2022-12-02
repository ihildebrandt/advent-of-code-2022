using Pihi.AdventOfCode2022.Common;
using System.ComponentModel.DataAnnotations;

namespace Pihi.AdventOfCode2022.Day02
{
    public class Runner : RunnerBase
    {


        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var rockScore = 1;
            var paperScore = 2;
            var scissorsScore = 3;

            var moves = new List<(char op, char me)>();

            char pick;
            foreach (var line in ReadLines())
            {
                var parts = line.Split(' ');
                
                switch (parts[1][0])
                {
                    case 'X': // Lose
                        switch (parts[0][0])
                        {
                            case 'A':
                                pick = 'Z';
                                break;
                            case 'B':
                                pick = 'X';
                                break;
                            case 'C':
                                pick = 'Y';
                                break;
                            default:
                                throw new Exception();
                        }
                        break;
                    case 'Y': // Draw
                        switch (parts[0][0])
                        {
                            case 'A':
                                pick = 'X';
                                break;
                            case 'B':
                                pick = 'Y';
                                break;
                            case 'C':
                                pick = 'Z';
                                break;
                            default:
                                throw new Exception();
                        }
                        break;
                    case 'Z': // Win
                        switch (parts[0][0])
                        {
                            case 'A':
                                pick = 'Y';
                                break;
                            case 'B':
                                pick = 'Z';
                                break;
                            case 'C':
                                pick = 'X';
                                break;
                            default:
                                throw new Exception();
                        }
                        break;
                    default:
                        throw new Exception();
                }

                moves.Add((parts[0][0], pick));
            }

            var score = 0;
            foreach (var move in moves)
            {
                score += MoveScore(move.me);

                if (Win(move.op, move.me))
                {
                    score += 6;
                }
                else if (Draw(move.op, move.me))
                {
                    score += 3;
                }
            }

            Console.WriteLine(score);
        }

        public int MoveScore(char me)
        {
            if (me == 'X') return 1;
            if (me == 'Y') return 2;
            return 3;
        }

        public bool Win(char op, char me)
        {
            return (op == 'A' && me == 'Y') ||
                   (op == 'B' && me == 'Z') ||
                   (op == 'C' && me == 'X');
        }

        public bool Draw(char op, char me)
        {
            return (op == 'A' && me == 'X') ||
                   (op == 'B' && me == 'Y') ||
                   (op == 'C' && me == 'Z');
        }
    }
}