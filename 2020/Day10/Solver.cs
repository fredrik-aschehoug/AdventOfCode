using System;
using System.Collections.Concurrent;
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
        private ConcurrentDictionary<int, List<int>> cache = new ConcurrentDictionary<int, List<int>>();
        private List<int> GetCachedChildren(int joltage)
        {
            return cache.GetOrAdd(joltage, x => GetChildren(x));
        }
        private List<int> GetChildren(int joltage)
        {
            var currentRange = Enumerable.Range(joltage + 1, 3);
            return numbers
                .Where(adapter => currentRange.Contains(adapter))
                .ToList();
        }
        public void Part2DFS()
        {
            /// DFS solution, takes forever
            var frontier = new Stack<int>();
            frontier.Push(0);
            long configCount = 0;
            while (frontier.Count > 0)
            {
                var currentJoltage = frontier.Pop();
                var children = GetCachedChildren(currentJoltage);
                if (children.Count == 0)
                {
                    configCount++;
                }
                else
                {
                    children.ForEach(frontier.Push);
                }

            }
            Console.WriteLine("Part 2: {0}", configCount);
        }
        private static long GetValueOrDefault(Dictionary<int, long> dict, int key)
        {
            return dict.ContainsKey(key) ? dict[key] : 0;
        }
        public void Part2()
        {
            var jolts = new List<int>(numbers);
            jolts.Sort();
            jolts.Add(jolts.Last() + 3);

            var combinations = new Dictionary<int, long> { { 0, 1 } };
            foreach (var adapter in jolts)
            {
                combinations[adapter] = GetValueOrDefault(combinations, adapter - 3) 
                    + GetValueOrDefault(combinations, adapter - 2) 
                    + GetValueOrDefault(combinations, adapter - 1);
            }
            Console.WriteLine("part 2: {0}", combinations[jolts.Last()]);
        }
    }
}
