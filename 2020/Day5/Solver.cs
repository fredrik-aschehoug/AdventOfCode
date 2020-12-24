using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Solver
    {
        private const string inputPath = "input.txt";
        private static List<List<char>> GetInput()
        {
            var lines = File.ReadLines(inputPath)
                .Select(line => line.Select(c => c).ToList())
                .ToList();

            return lines;
        }
        public void Part1()
        {
            var input = GetInput();
            List<int> ids = new List<int>();

            foreach (var line in input)
            {
                ids.Add(new BoardingPass(line).GetSeatId());
            }
            int highest = ids.Max();
            Console.WriteLine("Part 1: {0}", highest);
        }
    }
}
