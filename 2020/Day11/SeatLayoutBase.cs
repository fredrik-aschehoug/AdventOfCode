using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day11
{
    abstract class SeatLayoutBase
    {
        public char[,] SeatMap { get; set; }
        public char[,] Iterate()
        {
            var newMap = new char[SeatMap.GetLength(0), SeatMap.GetLength(1)];
            for (int rowIndex = 0; rowIndex < SeatMap.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < SeatMap.GetLength(1); columnIndex++)
                {
                    var newValue = SeatMap[rowIndex, columnIndex] switch
                    {
                        'L' => ShouldBeOccupied(SeatMap, rowIndex, columnIndex) ? '#' : 'L',
                        '#' => ShouldBeVacant(SeatMap, rowIndex, columnIndex) ? 'L' : '#',
                        '.' => '.'
                    };
                    newMap[rowIndex, columnIndex] = newValue;
                }
            }
            return newMap;
        }

        public abstract bool ShouldBeVacant(char[,] oldMap, int rowIndex, int columnIndex);

        public abstract bool ShouldBeOccupied(char[,] oldMap, int rowIndex, int columnIndex);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            for (int rowIndex = 0; rowIndex < SeatMap.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < SeatMap.GetLength(1); columnIndex++)
                {
                    if (SeatMap[rowIndex, columnIndex] != ((SeatLayoutBase)obj).SeatMap[rowIndex, columnIndex])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public  int CountOccupied()
        {
            return SeatMap.Cast<char>()
                .Where(seat => seat == '#')
                .Count();
        }
    }
}
