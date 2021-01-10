using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    class SeatLayout1 : SeatLayoutBase
    {
        private static int GetOccupiedNeighbors(char[,] map, int row, int column)
        {
            int occupiedNeighbors = 0;
            var rowBounds = Enumerable.Range(map.GetLowerBound(0), map.GetUpperBound(0) + 1);
            var columnBounds = Enumerable.Range(map.GetLowerBound(1), map.GetUpperBound(1) + 1);
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
        public override bool ShouldBeOccupied(char[,] map, int row, int column)
        {
            return GetOccupiedNeighbors(map, row, column) == 0;
        }
        public override bool ShouldBeVacant(char[,] map, int row, int column)
        {
            return GetOccupiedNeighbors(map, row, column) >= 4;
        }
    }
}
