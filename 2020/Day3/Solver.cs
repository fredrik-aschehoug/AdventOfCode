using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Solver
    {
        private const string inputPath = "input.txt";
        private char[,] treeMap { get; set; }

        public Solver()
        {
            treeMap = GetInput();
        }

        private static char[,] GetInput()
        {
            // Read txt file and return 2d array with tree map
            // 323 rows x 31 colums
            var lines = File.ReadLines(inputPath)
                .Select(line => line.Select(c => c).ToArray())
                .ToArray();
            var twa = new char[lines.Length, lines.Max(column => column.Length)];
            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex < lines[lineIndex].Length; columnIndex++)
                {
                    twa[lineIndex, columnIndex] = lines[lineIndex][columnIndex];
                }
            }
            return twa;
        }
        private int Solve(Instruction instruction)
        {
            (int, int) maxPos = (treeMap.GetLength(0) - 1, treeMap.GetLength(1) - 1);
            int treeCount = 0;
            (int, int) currentPos = (instruction.Down, instruction.Right);
            while (true)
            {
                if (currentPos.Item1 > maxPos.Item1) break;

                char currentValue = treeMap[currentPos.Item1, currentPos.Item2];
                if (currentValue == '#') treeCount++;

                currentPos.Item2 += instruction.Right;
                currentPos.Item1 += instruction.Down;

                if (currentPos.Item2 > maxPos.Item2)
                {
                    currentPos.Item2 = currentPos.Item2 - maxPos.Item2 - 1;
                }

            }
            return treeCount;
        }
        public void Part1()
        {
            var instruction = new Instruction { Down = 1, Right = 3 };
            int treeCount = Solve(instruction);
            Console.WriteLine("Part 1: {0}", treeCount);
        }
        public void Part2()
        {
            var combinations = new List<Instruction>{
                new Instruction { Right = 1, Down = 1},
                new Instruction { Right = 3, Down = 1},
                new Instruction { Right = 5, Down = 1},
                new Instruction { Right = 7, Down = 1},
                new Instruction { Right = 1, Down = 2}
            };
            var results = new List<long>();

            foreach (Instruction instruction in combinations)
            {
                results.Add(Solve(instruction));
            };

            long result = results.Aggregate((acc, val) => acc * val);

            Console.WriteLine("Part 2: {0}", result);

        }
    }
}
