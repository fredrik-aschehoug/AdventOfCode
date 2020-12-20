using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day4
{
    class Solver
    {
        public Solver()
        {
            lines = GetInput();
            passports = PopulatePassportList(lines);
        }
        private readonly IEnumerable<string[]> lines;
        private readonly List<Passport> passports;
        private const string inputPath = "input.txt";
        private static IEnumerable<string[]> GetInput()
        {
            var lines = File.ReadAllText(inputPath)
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(part => part.Replace(Environment.NewLine, " "))
                .Select(line => line.Split(" "));

            return lines;

        }
        private static List<Passport> PopulatePassportList(IEnumerable<string[]> lines)
        {
            var passports = new List<Passport>();
            foreach (var line in lines)
            {
                Passport currentPassport = new Passport();
                foreach (string field in line)
                {
                    string fieldName = field.Split(":")[0];
                    string fieldValue = field.Split(":")[1];

                    switch (fieldName)
                    {
                        case "byr":
                            currentPassport.Byr = fieldValue;
                            break;
                        case "iyr":
                            currentPassport.Iyr = fieldValue;
                            break;
                        case "eyr":
                            currentPassport.Eyr = fieldValue;
                            break;
                        case "hgt":
                            currentPassport.Hgt = fieldValue;
                            break;
                        case "hcl":
                            currentPassport.Hcl = fieldValue;
                            break;
                        case "ecl":
                            currentPassport.Ecl = fieldValue;
                            break;
                        case "pid":
                            currentPassport.Pid = fieldValue;
                            break;
                        case "cid":
                            currentPassport.Cid = fieldValue;
                            break;
                        default:
                            break;
                    }
                }
                passports.Add(currentPassport);
            }

            return passports;
        }
        public void Part1()
        {
            int validPassports = passports.Where(passport => passport.IsValid()).Count();
            Console.WriteLine("Part 1: {0}", validPassports);
        }
        public void Part2()
        {
            int validPassports = passports.Where(passport => passport.IsStrictValid()).Count();
            Console.WriteLine("Part 2: {0}", validPassports);
        }
    }
}
