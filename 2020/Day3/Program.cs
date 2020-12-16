using System;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        private const string inputPath = "input.txt";
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
        private static int Solve(char[,] treeMap)
        {
            (int, int) maxPos = (treeMap.GetLength(0) - 1, treeMap.GetLength(1) - 1);
            int treeCount = 0;
            (int, int) currentPos = (1, 3);
            while (true)
            {
                if (currentPos.Item1 > maxPos.Item1) break;

                char currentValue = treeMap[currentPos.Item1, currentPos.Item2];
                if (currentValue == '#') treeCount++;

                currentPos.Item1++;
                currentPos.Item2 += 3;

                if (currentPos.Item2 > maxPos.Item2)
                {
                    currentPos.Item2 = currentPos.Item2 - maxPos.Item2 - 1;
                }

            }
            return treeCount;
        }
        static void Main(string[] args)
        {
            var treeMap = GetInput();
            int treeCount = Solve(treeMap);
            Console.WriteLine(treeCount);
        }
    }
}
