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
            var seatLayout = new SeatLayout1() { SeatMap = seatMap };
            while(true)
            {
                var newLayout = seatLayout.Iterate();
                if (seatLayout.Equals(new SeatLayout1() { SeatMap = newLayout }))
                {
                    seatLayout.SeatMap = newLayout;
                    Console.WriteLine("Part 1: {0}", seatLayout.CountOccupied());
                    break;
                }
                seatLayout.SeatMap = newLayout;
            }
        }
        public void Part2()
        {
        }
    }
}
