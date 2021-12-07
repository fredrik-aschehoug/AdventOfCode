using System;
using System.Collections.Generic;

namespace Day12
{
    static class Compass
    {
        private static List<char> Directions = new List<char>
        {
           'N', 'E', 'S', 'W'
        };

        public static char TurnRight(int degree, char direction)
        {
            var currentDirection = Directions.IndexOf(direction);
            var directionIncrement = GetIncrement(degree);
            var index = currentDirection + directionIncrement;
            if (index >= Directions.Count)
            {
                return Directions[index - Directions.Count];

            }
            return Directions[index];
        }

        public static char TurnLeft(int degree, char direction)
        {
            var currentDirection = Directions.IndexOf(direction);
            var directionIncrement = GetIncrement(degree);
            var index = currentDirection - directionIncrement;
            if (index < 0)
            {
                return Directions[^Math.Abs(index)];

            }
            return Directions[index];
        }

        private static int GetIncrement(int degree) => degree switch
        {
            90 => 1,
            180 => 2,
            270 => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(degree), $"Not expected direction value: {degree}"),
        };
    }
}
