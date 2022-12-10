using Pihi.AdventOfCode2022.Common;
using System.Transactions;

namespace Pihi.AdventOfCode2022.Day10
{
    public class Runner : RunnerBase
    {


        private int firstCheck = 20;
        private int checkFrequency = 40;

        private int signalStrength = 0;

        private int screenWidth = 40;
        private int screenHeight = 6;

        private int spritePosition = 1;

        private char[,] screenBuffer;

        public Runner(Stream inputStream) : base(inputStream)
        {
            screenBuffer = new char[screenWidth, screenHeight];
            for (var y = 0; y < screenHeight; y++)
            {
                for (var x = 0; x < screenWidth; x++)
                {
                    screenBuffer[x, y] = ' ';
                }
            }
        }

        public override void Run()
        {
            int x = 1;
            int c = 1;

            Console.SetWindowSize(screenWidth, screenHeight + 5);

            foreach (var line in ReadLines())
            {
                var add = 0;
                var parts = line.Split(' ');
                
                if (parts[0] == "addx")
                {
                    Cycle(ref c, x);
                    add = int.Parse(parts[1]);
                    // Console.WriteLine($"addx: {add}");
                }
                else
                {
                    // Console.WriteLine("noop");
                }

                Cycle(ref c, x);
                x += add;
            }

            DrawScreenBuffer();
        }

        private void Cycle(ref int c, int x)
        {
            int l = (c - 1) % screenWidth;
            int t = (c - 1) / screenWidth;

            if (Math.Abs(x - l) <= 1)
            {
                screenBuffer[l, t] = '#';
            }

            c++;
            if (c == firstCheck || ((c - firstCheck) % checkFrequency == 0))
            {
                signalStrength += c * x;
            }
        }
        
        private void DrawScreenBuffer()
        {
            for (var y = 0; y < screenHeight; y++)
            {
                for (var x = 0; x < screenWidth; x++)
                {
                    Console.Write(screenBuffer[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}