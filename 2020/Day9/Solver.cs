using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    class Solver
    {
        public Solver()
        {
            numbers = GetInput();
        }
        private readonly List<long> numbers;
        private const string inputPath = "input.txt";
        private static List<long> GetInput()
        {
            var lines = File.ReadLines(inputPath)
                .Select(line => long.Parse(line))
                .ToList();

            return lines;
        }
        public void Part1()
        {
            int currentIndex = 25;
            while (currentIndex < numbers.Count)
            {
                var previousNumbers = numbers.GetRange(currentIndex - 25, 25);
                var matches = previousNumbers
                    .SelectMany((value, index) => numbers.Skip(index + 1),
                               (first, second) => new { first, second })
                    .Where(values => values.first + values.second == numbers[currentIndex])
                    .ToList();
                if (matches.Count == 0)
                {
                    Console.WriteLine("XMAS stopped at index: {0}", currentIndex);
                    Console.WriteLine("The value is: {0}", numbers[currentIndex]);
                    Part2(numbers[currentIndex]);
                    break;
                }
                currentIndex++;
            }
        }
        public void Part2(long target)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                long currentResult = 0;
                int counter = 1;
                while (currentResult < target &&  i + counter < numbers.Count)
                {
                    var range = numbers.GetRange(i, counter);
                    currentResult = range.Sum();
                    if (currentResult == target)
                    {
                        Console.WriteLine("Part 2: {0}", range.Min() + range.Max());
                        return;
                    }
                    counter++;
                }
            }
        }
    }
}
