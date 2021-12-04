using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    class SeatLayout2 : SeatLayoutBase
    {
        private List<char> seatIdentifiers = new List<char> { 'L', '#' };
        private int GetOccupiedNeighbors(char[,] map, int row, int column)
        {
            var rowBounds = Enumerable.Range(map.GetLowerBound(0), map.GetUpperBound(0) + 1);
            var columnBounds = Enumerable.Range(map.GetLowerBound(1), map.GetUpperBound(1) + 1);

            var up = GetUp(map, row, column);
            var down = GetDown(map, row, column);
            var left = GetLeft(map, row, column);
            var right = GetRight(map, row, column);

            var upLeft = GetUpLeft(map, row, column, rowBounds, columnBounds);
            var upRight = GetUpRight(map, row, column, rowBounds, columnBounds);

            var downLeft = GetDownLeft(map, row, column, rowBounds, columnBounds);
            var downRight = GetDownRight(map, row, column, rowBounds, columnBounds);

            var occupiedNeighbors = new List<char>
            {
                up, down, left, right,
                upLeft, upRight, downLeft, downRight
            }.Where(x => x == '#').Count();
            return occupiedNeighbors;
        }

        private char GetUp(char[,] map, int row, int column)
        {
            if (row == 0) return default;
            return Enumerable.Range(0, row)
                .Select(x => map[x, column])
                .Reverse()
                .FirstOrDefault(x => seatIdentifiers.Contains(x));
        }

        private char GetDown(char[,] map, int row, int column)
        {
            if (row + 1 > map.GetUpperBound(0)) return default;
            return Enumerable.Range(row + 1, map.GetUpperBound(0) - row)
                .Select(x => map[x, column])
                .FirstOrDefault(x => seatIdentifiers.Contains(x));
        }

        private char GetLeft(char[,] map, int row, int column)
        {
            if (column == 0) return default;
            return Enumerable.Range(0, column)
                .Select(x => map[row, x])
                .Reverse()
                .FirstOrDefault(x => seatIdentifiers.Contains(x));
        }

        private char GetRight(char[,] map, int row, int column)
        {
            if (column + 1 > map.GetUpperBound(1)) return default;
            return Enumerable.Range(column + 1, map.GetUpperBound(1) - column)
                .Select(x => map[row, x])
                .FirstOrDefault(x => seatIdentifiers.Contains(x));
        }

        private char GetUpLeft(char[,] map, int row, int column, IEnumerable<int> rowBounds, IEnumerable<int> columnBounds)
        {
            var c = column - 1;
            var r = row - 1;
            while (rowBounds.Contains(r) && columnBounds.Contains(c))
            {
                var currentSeat = map[r, c];
                if (seatIdentifiers.Contains(currentSeat))
                {
                    return currentSeat;
                }
                c--;
                r--;
            }
            return default;
        }

        private char GetUpRight(char[,] map, int row, int column, IEnumerable<int> rowBounds, IEnumerable<int> columnBounds)
        {
            var c = column + 1;
            var r = row - 1;
            while (rowBounds.Contains(r) && columnBounds.Contains(c))
            {
                var currentSeat = map[r, c];
                if (seatIdentifiers.Contains(currentSeat))
                {
                    return currentSeat;
                }
                c++;
                r--;
            }
            return default;
        }

        private char GetDownLeft(char[,] map, int row, int column, IEnumerable<int> rowBounds, IEnumerable<int> columnBounds)
        {
            var c = column - 1;
            var r = row + 1;
            while (rowBounds.Contains(r) && columnBounds.Contains(c))
            {
                var currentSeat = map[r, c];
                if (seatIdentifiers.Contains(currentSeat))
                {
                    return currentSeat;
                }
                c--;
                r++;
            }
            return default;
        }

        private char GetDownRight(char[,] map, int row, int column, IEnumerable<int> rowBounds, IEnumerable<int> columnBounds)
        {
            var c = column + 1;
            var r = row + 1;
            while (rowBounds.Contains(r) && columnBounds.Contains(c))
            {
                var currentSeat = map[r, c];
                if (seatIdentifiers.Contains(currentSeat))
                {
                    return currentSeat;
                }
                c++;
                r++;
            }
            return default;
        }

        public override bool ShouldBeOccupied(char[,] map, int row, int column)
        {
            return GetOccupiedNeighbors(map, row, column) == 0;
        }
        public override bool ShouldBeVacant(char[,] map, int row, int column)
        {
            return GetOccupiedNeighbors(map, row, column) >= 5;
        }
    }
}
