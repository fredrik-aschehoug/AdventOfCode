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
            computer.Run();

            Console.WriteLine("Part 1: {0}", computer.accumulator);
        }
        public void Part2()
        {
            var changable = instructions
                .Select((item, index) => (item, index))
                .Where(instruction => instruction.Item1.Item1 == "jmp" || instruction.Item1.Item1 == "nop");

            foreach (var item in changable)
            {
                var newInstruction = item.Item1.Item1 switch
                {
                    "jmp" => "nop",
                    "nop" => "jmp"
                };
                var currentInstructions = new List<(string, int)>(instructions);
                currentInstructions[item.Item2] = (newInstruction, item.Item1.Item2);
                Interpreter computer = new Interpreter(currentInstructions);
                bool result = computer.Run();
                if (result == true)
                {
                    Console.WriteLine("Part 2: {0}", computer.accumulator);
                    break;
                }

            }
        }
    }
}
