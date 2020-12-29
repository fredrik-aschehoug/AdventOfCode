using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    class Solver
    {
        public Solver()
        {
            instructions = GetInput();
        }
        private readonly List<(string, int)> instructions;
        private const string inputPath = "input.txt";
        private static List<(string, int)> GetInput()
        {
            var lines = File.ReadLines(inputPath)
                .Select(line => line.Split(" "))
                .Select(line => (line[0], int.Parse(line[1])))
                .ToList();

            return lines;

        }
        public void Part1()
        {
            Interpreter computer = new Interpreter(instructions);

            Console.WriteLine("Part 1: {0}", computer.Run());
        }
        public void Part2()
        {
            Console.WriteLine("Part 2: {0}", 0);
        }
    }
}
