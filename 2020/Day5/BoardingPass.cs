using System;
using System.Collections.Generic;

namespace Day5
{
    class BoardingPass
    {
        private readonly int rowId;
        private readonly int columnId;
        private const int maxRow = 127;
        private const int maxColumn = 7;

        public BoardingPass(List<char> letters)
        {
            rowId = GetId(letters.GetRange(0,7), maxRow, 'F');
            columnId = GetId(letters.GetRange(7, 3), maxColumn, 'L');
        }

        private int GetColumnId(List<char> letters)
        {
            int max = maxColumn;
            int min = 0;
            int mid = 0;
            foreach (var letter in letters)
            {
                mid = (min + max) / 2;
                if (letter == 'L')
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return mid;
        }

        private int GetId(List<char> letters, int maxIndex, char lowLetter)
        {
            int max = maxIndex;
            int min = 0;
            int mid = 0;
            for (int i = 0; i < letters.Count; i++)
            {
                char letter = letters[i];
                bool isLast = i == letters.Count - 1;
                mid = (min + max) / 2;
                if (letter == lowLetter)
                {
                    max = mid;
                    if (isLast) return max;
                }
                else
                {
                    min = mid + 1;
                    if (isLast) return min;
                }
            }
            return mid;
        }

        public int GetSeatId()
        {
            int id = rowId * 8 + columnId;
            return id;
        }
    }
}
