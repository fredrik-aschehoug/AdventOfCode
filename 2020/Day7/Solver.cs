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
        private static string Strip(string line)
        {
            return line
                .Replace(".", "")
                .Replace(" bags", "")
                .Replace(" bag", "");
        }
        private List<string> GetColors(string line)
        {
            string stripped = Strip(line);
            if (stripped.Contains(", "))
            {
                return stripped.Split(", ").ToList();
            }
            return new List<string>() { stripped };
        }
        private Suitcase CreateSuitcase(string line)
        {
            return new Suitcase()
            {
                Quantity = int.Parse(line[0].ToString()),
                Color = line.Substring(2)
            };
        }
        public List<Suitcase> GetChildren(string color)
        {
            return lines
                .Select(line => line.Split(" bags contain "))
                .Where(line => line[0].Contains(color) && !line[1].Contains("no other"))
                .Select(line => GetColors(line[1]).Select(color => CreateSuitcase(color)).ToList())
                .FirstOrDefault();
        }
        private void PopulateBag(Suitcase myBag)
        {
            /// Generate a tree structure with root node myBag
            /// Uses Breadth-first search to find all children
            Queue<Suitcase> bagQueue = new Queue<Suitcase>();
            bagQueue.Enqueue(myBag);
            while (bagQueue.Count > 0)
            {
                var currentBag = bagQueue.Dequeue();
                var children = GetChildren(currentBag.Color);
                if (children != null)
                {
                    currentBag.Children.AddRange(children);
                    currentBag.Children.ForEach(bag => bagQueue.Enqueue(bag));
                }
            }
        }
        private static int GetSum(Suitcase bag)
        {
            /// Recursive method to calculate the cumulative sum for the entire tree
            int count = 0;
            if (bag.Children.Count() == 0) return 0;

            bag.Children.ForEach(child => {
                count += child.Quantity;
                count += child.Quantity * GetSum(child);
                });

            return count;
        }
        public void Part2()
        {
            var myBag = new Suitcase() { Color = "shiny gold", Quantity = 1 };
            PopulateBag(myBag);

            int sum = GetSum(myBag);
            Console.WriteLine("Part 2: {0}", sum);
        }
    }
}
