using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Solver
    {
        private const string inputPath = "input.txt";
        private readonly List<int> ids;

        public Solver()
        {
            ids = GetIds(GetInput());
        }
        private static List<List<char>> GetInput()
        {
            var lines = File.ReadLines(inputPath)
                .Select(line => line.Select(c => c).ToList())
                .ToList();

            return lines;
        }
        private static List<int> GetIds(List<List<char>> lines)
        {
            List<int> ids = new List<int>();

            foreach (var line in lines)
            {
                ids.Add(new BoardingPass(line).GetSeatId());
            }
            return ids;
        }
        public void Part1()
        {
            int highest = ids.Max();
            Console.WriteLine("Part 1: {0}", highest);
        }
        public void Part2()
        {
            List<int> sorted = new List<int>(ids);
            sorted.Sort();

            for (int i = 0; i < sorted.Count(); i++)
            {
                if (sorted[i+1] != sorted[i] + 1)
                {
                    Console.WriteLine("Part 2: {0}", sorted[i] + 1);
                    break;
                }
            }
        }
    }
}
