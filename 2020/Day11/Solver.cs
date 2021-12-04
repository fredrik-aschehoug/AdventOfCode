using System;
using System.IO;
using System.Linq;

namespace Day11
{
    class Solver
    {
        public Solver()
        {
            seatMap = GetInput();
        }
        private readonly char[,] seatMap;
        private const string inputPath = "input.txt";
        private static char[,] GetInput()
        {
            // Read txt file and return 2d array with seat map
            var lines = File.ReadLines(inputPath)
                .Select(line => line.Select(c => c).ToArray())
                .ToArray();
            var twa = new char[lines.Length, lines.Max(column => column.Length)];
            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex < lines[lineIndex].Length; columnIndex++)
                {
                    twa[lineIndex, columnIndex] = lines[lineIndex][columnIndex];
                }
            }
            return twa;
        }
        public void Part1()
        {
            Solve<SeatLayout1>("1");
        }

        public void Part2()
        {
            Solve<SeatLayout2>("2");

        }

        private void Solve<TLayout>(string part, bool debug = false) where TLayout : SeatLayoutBase, new()
        {
            var seatLayout = new TLayout() { SeatMap = seatMap };
            while (true)
            {
                var newLayout = seatLayout.Iterate();
                if (debug)
                {
                    PrintLayout(newLayout);
                }
                if (seatLayout.Equals(new TLayout() { SeatMap = newLayout }))
                {
                    seatLayout.SeatMap = newLayout;
                    Console.WriteLine("Part {0}: {1}", part, seatLayout.CountOccupied());
                    break;
                }
                seatLayout.SeatMap = newLayout;
            }
        }

        private void PrintLayout(char[,] map)
        {
            foreach (var i in Enumerable.Range(0, map.GetLength(0)))
            {
                var row = Enumerable.Range(0, map.GetLength(1))
                .Select(x => map[i, x])
                .ToArray();

                Console.WriteLine(string.Join("", row));
            }

            Console.WriteLine("\n\n");

        }
    }
}
