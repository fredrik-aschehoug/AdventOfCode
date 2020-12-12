using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static int[] GetInput()
        {
            int[] numbers = File.ReadLines("input.txt")
                .Select(line => int.Parse(line))
                .ToArray();
            return numbers;
        }
        static void Part1()
        {
            int[] numbers = GetInput();
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
        static List<Triplet> GetTriplets(int[] numbers)
        {
            List<Triplet> combinations = new List<Triplet>();
            foreach (int number1 in numbers)
            {
                foreach (int number2 in numbers)
                {
                    foreach (int number3 in numbers)
                    {
                        Triplet combination = new Triplet()
                        {
                            first = number1,
                            second = number2,
                            third = number3
                        };
                        combinations.Add(combination);
                    }

                }

            }
            return combinations;
        }
        static void Part2()
        {
            int[] numbers = GetInput();
            var combinations = GetTriplets(numbers);
            foreach (Triplet combination in combinations)
            {
                int result = combination.first + combination.second + combination.third;
                if (result == 2020)
                {
                    Console.WriteLine(combination.first * combination.second * combination.third);
                }
            }
        }
        static void Main(string[] args)
        {
            Part2();
        }
    }
}
