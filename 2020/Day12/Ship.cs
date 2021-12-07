namespace Day12
{
    class Ship
    {
        public char Direction { get; set; } = 'E';
        public int NorthPosition { get; set; }
        public int EastPosition { get; set; }

        public void Take(Instruction instruction)
        {
            switch (instruction.Action)
            {
                case 'L':
                    Direction = Compass.TurnLeft(instruction.Value, Direction);
                    break;
                case 'R':
                    Direction = Compass.TurnRight(instruction.Value, Direction);
                    break;
                case 'F':
                    HandleDirection(Direction, instruction.Value);
                    break;
                default:
                    HandleDirection(instruction.Action, instruction.Value);
                    break;
            }
        }

        private void HandleDirection(char direction, int value)
        {
            switch (direction)
            {
                case 'N':
                    NorthPosition += value;
                    break;
                case 'S':
                    NorthPosition -= value;
                    break;
                case 'E':
                    EastPosition += value;
                    break;
                case 'W':
                    EastPosition -= value;
                    break;
                default:
                    break;
            }
        }
    }
}
