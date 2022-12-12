using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Day11
{
    internal class Monkey
    {
        public static Monkey ParseMonkey(IEnumerable<string> block)
        {
            Queue<int>? items = null;
            Func<int, int>? operation = null;
            int divisibilityTest = 0;
            int trueResult = 0;
            int falseResult = 0;

            foreach (var line in block)
            {
                var clean = line.Trim();

                if (string.IsNullOrWhiteSpace(clean))
                {
                    break;
                }

                if (clean.StartsWith("Starting items"))
                {
                    var parts = clean.Split(':');
                    items = new Queue<int>(parts[1].Split(',').Select(i => int.Parse(i)));
                    continue;    
                }

                if (clean.StartsWith("Operation")) 
                {
                    var parts = clean.Split('=');
                    var opParts = parts[1].Trim().Split(' ');

                    var left = opParts[0] == "old" ? -1 : int.Parse(opParts[0]);
                    var right = opParts[2] == "old" ? -1 : int.Parse(opParts[2]);

                    switch (opParts[1][0])
                    {
                        case '+':
                            operation = CreateAdditionOperation(left, right);
                            break;
                        case '*':
                            operation = CreateMultiplyOperation(left, right);
                            break;
                    }

                    continue;
                }

                if (clean.StartsWith("Test")) 
                {
                    var parts = clean.Split(' ');
                    divisibilityTest = int.Parse(parts.Last());
                    continue;
                }

                if (clean.StartsWith("If true")) 
                {
                    var parts = clean.Split(' ');
                    trueResult = int.Parse(parts.Last());
                    continue;
                }

                if (clean.StartsWith("If false"))
                {
                    var parts = clean.Split(' ');
                    falseResult = int.Parse(parts.Last());
                    continue;
                }
            }

            return new Monkey(items, operation, divisibilityTest, trueResult, falseResult);
        }

        private static Func<int, int> CreateAdditionOperation(int left, int right)
        {
            return (int old) =>
            {
                var lOp = left == -1 ? old : left;
                var rOp = right == -1 ? old : right;
                return lOp + rOp;
            };
        }

        private static Func<int, int> CreateMultiplyOperation(int left, int right)
        {
            return (int old) =>
            {
                var lOp = left == -1 ? old : left;
                var rOp = right == -1 ? old : right;
                return lOp * rOp;
            };
        }

        public Queue<int> Items { get; }
        public Func<int, int> Operation { get; }
        public int DivisibilityTest { get; }
        public int TrueResult { get; }
        public int FalseResult { get; }
        public int InspectionCount { get; set; }


        private Monkey(Queue<int>? items, Func<int, int>? operation, int divisibilityTest, int trueResult, int falseResult)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (operation == null) throw new ArgumentNullException("operation");

            Items = items;
            Operation = operation;
            
            DivisibilityTest = divisibilityTest;
            TrueResult = trueResult;
            FalseResult = falseResult;
        }
    }
}
