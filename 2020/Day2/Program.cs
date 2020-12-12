using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static string[] GetInput()
        {
            string[] lines = File.ReadLines("input.txt")
                .Select(line => line)
                .ToArray();
            return lines;
        }
        static void Part1()
        {
            var lines = GetInput();
            List<Password> passwordList = new List<Password>();
            foreach(string line in lines)
            {
                passwordList.Add(new Password(line));
            }
            var validPasswords = passwordList.Where(password => password.isValid());
            Console.WriteLine(validPasswords.Count());
        }
        static void Main(string[] args)
        {
            Part1();
        }
    }
}
