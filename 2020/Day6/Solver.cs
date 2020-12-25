using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day6
{
    class Solver
    {
        public Solver()
        {
            lines = GetInput();
        }
        private readonly List<List<char>> lines;
        private const string inputPath = "input.txt";
        private static List<List<char>> GetInput()
        {
            var lines = File.ReadAllText(inputPath)
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(part => part.Replace(Environment.NewLine, ""))
                .Select(line => line.Select(c => c).ToList()).ToList();

            return lines;

        }
        
        public void Part1()
        {
            var uniqueAnswers = lines.Select(line => line.Distinct().ToList());
            int sum = uniqueAnswers.Aggregate(0, (acc, next) => acc + next.Count());
            Console.WriteLine("Part 1: {0}", sum);
        }
    }
}
