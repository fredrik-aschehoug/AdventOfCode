using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    class Interpreter
    {
        private List<(string, int)> _instructions;
        private List<int> visited = new List<int>();
        public int accumulator = 0;
        public Interpreter(List<(string, int)> instructions)
        {
            _instructions = instructions;
        }
        public bool Run()
        {
            int currentIndex = 0;
            while (currentIndex < _instructions.Count)
            {
                var instruction = _instructions[currentIndex];
                int accumulatorIncrement = 0;
                int indexIncerment;
                switch (instruction.Item1)
                {
                    case "acc":
                        accumulatorIncrement += instruction.Item2;
                        indexIncerment = 1;
                        break;
                    case "jmp":
                        indexIncerment = instruction.Item2;
                        break;
                    default:
                        indexIncerment = 1;
                        break;
                }
                int newIndex = currentIndex + indexIncerment;
                if (visited.Contains(newIndex))
                {
                    return false;

                }
                visited.Add(currentIndex);
                currentIndex = newIndex;
                accumulator += accumulatorIncrement;
            }
            return true;
        }
    }
}
