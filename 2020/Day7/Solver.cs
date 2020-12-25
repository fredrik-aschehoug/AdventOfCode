using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Solver
    {
        public Solver()
        {
            lines = GetInput();
        }
        private readonly List<string> lines;
        private const string inputPath = "input.txt";
        private static List<string> GetInput()
        {
            var lines = File.ReadLines(inputPath)
                .ToList();

            return lines;

        }
        private List<string> GetBags(string color)
        {
            return lines
                .Select(line => line.Split(" bags contain "))
                .Where(line => line[1].Contains(color))
                .Select(line => line[0])
                .ToList();
        }
        public void Part1()
        {
            var bags = GetBags("shiny gold");
            var compatibleBags = new List<string>(bags);
            var currentBags = new List<string>(bags);
            while (true)
            {
                var newBags = new List<string>();
                foreach (var bag in currentBags)
                {
                    newBags.AddRange(GetBags(bag));
                }
                if (newBags.Count() == 0)
                {
                    break;
                }
                currentBags = newBags;
                compatibleBags.AddRange(newBags);
            }

            int bagCount = compatibleBags.Distinct().Count();

            Console.WriteLine("Part 1: {0}", bagCount);
        }
    }
}
