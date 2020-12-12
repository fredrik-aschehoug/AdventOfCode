using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = File.ReadLines("input.txt")
                .Select(line => int.Parse(line))
                .ToArray();
            var query = numbers.SelectMany((value, index) => numbers.Skip(index + 1),
                               (first, second) => new { first, second });
            foreach (var number in query)
            {
                int result = number.first + number.second;
                if (result == 2020)
                {
                    Console.WriteLine(number.first * number.second);
                }
            }
        }
    }
}
