using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day12
{
    class Solver
    {
        private const string inputPath = "input.txt";

        public Solver()
        {
        }

        private static List<Instruction> GetInput()
        {
            return File.ReadLines(inputPath)
                .Select(line => new Instruction { Action = line.First(), Value = int.Parse(line.Substring(1)) })
                .ToList();
            
        }
        public void Part1()
        {
            var instructions = GetInput();
            var ship = new Ship();

            foreach (var instruction in instructions)
            {
                ship.Take(instruction);
            }

            var ManhattanDistance = Math.Abs(ship.NorthPosition) + Math.Abs(ship.EastPosition);

            Console.WriteLine("Part 1: {0}", ManhattanDistance);
        }

        public void Part2()
        {
            Console.WriteLine("Part 2:");
        }

    }
}
