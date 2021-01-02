using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Solver
    {
        public Solver()
        {
            numbers = GetInput();
        }
        private readonly List<int> numbers;
        private const string inputPath = "input.txt";
        private static List<int> GetInput()
        {
            var lines = File.ReadLines(inputPath)
                .Select(line => int.Parse(line))
                .ToList();

            return lines;
        }
        public void Part1()
        {
            var adapters = new List<int>(numbers);
            var diffs = new List<int>();
            int currentJoltage = 0;

            while (adapters.Count > 0)
            {
                var currentRange = Enumerable.Range(currentJoltage + 1, 3);
                var newJoltage = adapters
                    .Where(adapter => currentRange.Contains(adapter))
                    .ToList()
                    .Min();
                adapters.Remove(newJoltage);
                diffs.Add(newJoltage - currentJoltage);
                currentJoltage = newJoltage;
            }
            int diff1 = diffs.Where(diff => diff == 1).Count();
            int diff2 = diffs.Where(diff => diff == 3).Count() + 1;

            var result = diff1 * diff2;

            Console.WriteLine("Part 1: {0}", result);
        }
        public void Part2()
        {
            
        }
    }
}
