using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
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
            var lines = File.ReadAllText(inputPath)
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            return lines;

        }
        private static int GetSum(IEnumerable<IEnumerable<char>> answers)
        {
            return answers.Aggregate(0, (acc, next) => acc + next.Count());
        }
        public void Part1()
        {
            var uniqueAnswers = lines
                .Select(part => part.Replace(Environment.NewLine, ""))
                .Select(line => line.Select(c => c).ToList())
                .ToList()
                .Select(line => line.Distinct().ToList());
            int sum = GetSum(uniqueAnswers);
            Console.WriteLine("Part 1: {0}", sum);
        }
        public void Part2()
        {
            var answers = lines.Select(part =>
                part.Split(Environment.NewLine)
                    .Select(line => line.Select(c => c).ToList())
                    .ToList()
                )
                .ToList();
            var intersectAnswers = answers.Select(answer =>
                answer.Skip(1)
                    .Aggregate(
                        new HashSet<char>(answer.First()),
                        (h, e) => { h.IntersectWith(e); return h; }
                        )
                    ).ToList();
            int sum = GetSum(intersectAnswers);

            Console.WriteLine("Part 2: {0}", sum);
        }
    }
}
