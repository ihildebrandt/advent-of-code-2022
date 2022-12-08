using Pihi.AdventOfCode2022.Common;

namespace Pihi.AdventOfCode2022.Day08
{
    public class Runner : RunnerBase
    {
        public Runner(Stream inputStream) : base(inputStream)
        {
        }

        public override void Run()
        {
            var rows = new List<int[]>();

            foreach (var line in ReadLines())
            {
                rows.Add(line.Select(c => int.Parse(c.ToString())).ToArray());
            }

            var visible = (rows.Count * 2) + ((rows[0].Length - 2) * 2);
            var maxScore = 0;

            for (var row = 1; row < rows.Count - 1; row++)
            {
                for (var col = 1; col < rows[row].Length - 1; col++)
                {
                    if (IsVisible(row, col, rows))
                    {
                        visible++;
                    }

                    var scenicScore = CalculateScenicScore(row, col, rows);
                    maxScore = Math.Max(scenicScore, maxScore);
                }
            }

            Console.WriteLine(visible);
            Console.WriteLine(maxScore);
        }

        private bool IsVisible(int row, int col, List<int[]> grid)
        {
            return (IsVisibleFromLeft(row, col, grid) ||
                    IsVisibleFromTop(row, col, grid) ||
                    IsVisibleFromRight(row, col, grid) ||
                    IsVisibleFromBottom(row, col, grid));
        }

        private bool IsVisibleFromLeft(int row, int col, List<int[]> grid)
        {
            var treeHeight = grid[row][col];
            for (var c = col - 1; c >= 0; c--)
            {
                if (grid[row][c] >= treeHeight)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsVisibleFromTop(int row, int col, List<int[]> grid)
        {
            var treeHeight = grid[row][col];
            for (var r = row - 1; r >= 0; r--)
            {
                if (grid[r][col] >= treeHeight)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsVisibleFromRight(int row, int col, List<int[]> grid)
        {
            var treeHeight = grid[row][col];
            for (var c = col + 1; c < grid[row].Length; c++)
            {
                if (grid[row][c] >= treeHeight)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsVisibleFromBottom(int row, int col, List<int[]> grid)
        {
            var treeHeight = grid[row][col];
            for (var r = row + 1; r < grid.Count; r++)
            {
                if (grid[r][col] >= treeHeight)
                {
                    return false;
                }
            }
            return true;
        }

        private int CalculateScenicScore(int row, int col, List<int[]> grid)
        {
            return CalculateScenicScoreLeft(row, col, grid) *
                   CalculateScenicScoreTop(row, col, grid) *
                   CalculateScenicScoreRight(row, col, grid) *
                   CalculateScenicScoreBottom(row, col, grid);
        }

        private int CalculateScenicScoreLeft(int row, int col, List<int[]> grid)
        {
            var distance = 0;
            var treeHeight = grid[row][col];
            for (var c = col - 1; c >= 0; c--)
            {
                distance++;
                if (grid[row][c] >= treeHeight)
                {
                    break;
                }
            }
            return distance;
        }

        private int CalculateScenicScoreTop(int row, int col, List<int[]> grid)
        {
            var distance = 0;
            var treeHeight = grid[row][col];
            for (var r = row - 1; r >= 0; r--)
            {
                distance++;
                if (grid[r][col] >= treeHeight)
                {
                    break;
                }
            }
            return distance;
        }

        private int CalculateScenicScoreRight(int row, int col, List<int[]> grid)
        {
            var distance = 0;
            var treeHeight = grid[row][col];
            for (var c = col + 1; c < grid[row].Length; c++)
            {
                distance++;
                if (grid[row][c] >= treeHeight)
                {
                    break;
                }
            }
            return distance;
        }

        private int CalculateScenicScoreBottom(int row, int col, List<int[]> grid)
        {
            var distance = 0;
            var treeHeight = grid[row][col];
            for (var r = row + 1; r < grid.Count; r++)
            {
                distance++;
                if (grid[r][col] >= treeHeight)
                {
                    break;
                }
            }
            return distance;
        }
    }
}