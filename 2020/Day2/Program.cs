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
        static void Solve<T>() where T: IPassword, new()
        {
            var lines = GetInput();
            List<T> passwordList = new List<T>();
            foreach(string line in lines)
            {
                passwordList.Add(new T { Input = line });
            }
            var validPasswords = passwordList.Where(password => password.IsValid());
            Console.WriteLine(validPasswords.Count());
        }
        static void Main(string[] args)
        {
            Solve<Password>();
            Solve<Password2>();
        }
    }
}
