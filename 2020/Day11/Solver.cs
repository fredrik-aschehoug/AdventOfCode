using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    class Solver
    {
        public Solver()
        {
            seatMap = GetInput();
        }
        private readonly char[,] seatMap;
        private const string inputPath = "input.txt";
        private static char[,] GetInput()
        {
            // Read txt file and return 2d array with seat map
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
        private static int GetOccupiedNeighbors(char[,] map, int row, int column)
        {
            int occupiedNeighbors = 0;
            var rowBounds = Enumerable.Range(map.GetLowerBound(0), map.GetUpperBound(0)+1);
            var columnBounds = Enumerable.Range(map.GetLowerBound(1), map.GetUpperBound(1)+1);
            var neighborIndices = new List<(int, int)>
            {
                (row - 1, column - 1), (row - 1, column), (row - 1, column + 1),
                (row, column - 1), (row, column + 1),
                (row + 1, column - 1), (row + 1, column), (row + 1, column + 1)
            };
            foreach (var (r, c) in neighborIndices)
            {
                if (rowBounds.Contains(r) && columnBounds.Contains(c) && map[r, c] == '#')
                {
                    occupiedNeighbors++;
                }
            }
            return occupiedNeighbors;
        }
        private bool ShouldBeOccupied(char[,] map, int row, int column)
        {
            return GetOccupiedNeighbors(map, row, column) == 0;
        }
        private bool ShouldBeVacant(char[,] map, int row, int column)
        {
            return GetOccupiedNeighbors(map, row, column) >= 4;
        }
        private char[,] Iterate(char[,] oldMap)
        {
            var newMap = new char[oldMap.GetLength(0), oldMap.GetLength(1)];
            for (int rowIndex = 0; rowIndex < oldMap.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < oldMap.GetLength(1); columnIndex++)
                {
                    var newValue = oldMap[rowIndex, columnIndex] switch
                    {
                        'L' => ShouldBeOccupied(oldMap, rowIndex, columnIndex) ? '#' : 'L',
                        '#' => ShouldBeVacant(oldMap, rowIndex, columnIndex) ? 'L' : '#',
                        '.' => '.'
                    };
                    newMap[rowIndex, columnIndex] = newValue;
                }
            }
            return newMap;
        }
        private static bool IsEqual(char[,] arr1, char[,] arr2)
        {
            for (int rowIndex = 0; rowIndex < arr1.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < arr1.GetLength(1); columnIndex++)
                {
                    if (arr1[rowIndex, columnIndex] != arr2[rowIndex, columnIndex])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static int CountOccupied(char[,] map)
        {
            return map.Cast<char>()
                .Where(seat => seat == '#')
                .Count();
        }
        public void Part1()
        {
            var currentMap = seatMap.Clone() as char[,];
            while (true)
            {
                var newMap = Iterate(currentMap);

                if (IsEqual(newMap, currentMap))
                {
                    Console.WriteLine("Part 1: {0}", CountOccupied(newMap));
                    break;
                }
                currentMap = newMap;
            }
        }
        public void Part2()
        {
        }
    }
}
