using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    class Passport
    {
        public string Byr { get; set; } = string.Empty;
        public string Iyr { get; set; } = string.Empty;
        public string Eyr { get; set; } = string.Empty;
        public string Hgt { get; set; } = string.Empty;
        public string Hcl { get; set; } = string.Empty;
        public string Ecl { get; set; } = string.Empty;
        public string Pid { get; set; } = string.Empty;
        public string Cid { get; set; } = string.Empty;

        private bool ValidByr()
        {
            int value = int.Parse(Byr);
            return value >= 1920 && value <= 2002;
        }
        private bool ValidIyr()
        {
            int value = int.Parse(Iyr);
            return value >= 2010 && value <= 2020;
        }
        private bool ValidEyr()
        {
            int value = int.Parse(Eyr);
            return value >= 2020 && value <= 2030;
        }
        private bool ValidHgt()
        {
            if (Hgt.Length < 4) return false;
            string unit = Hgt.Substring(Hgt.Length - 2);
            int length = int.Parse(Hgt.Substring(0, Hgt.Length - 2));
            if (unit == "cm")
            {
                return length >= 150 && length <= 193;
            }
            if (unit == "in")
            {
                return length >= 59 && length <= 76;
            }
            return false;
        }
        private bool ValidHcl()
        {
            Regex rx = new Regex(@"^#[0-9a-f]{6}$");
            return rx.IsMatch(Hcl);
        }
        private bool ValidEcl()
        {
            List<string> colors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            return colors.Contains(Ecl);
        }
        private bool ValidPid()
        {
            Regex rx = new Regex(@"^[0-9]{9}$");
            return rx.IsMatch(Pid);
        }
        public bool IsValid()
        {
            bool isValid = !string.IsNullOrEmpty(Byr)
                && !string.IsNullOrEmpty(Iyr)
                && !string.IsNullOrEmpty(Eyr)
                && !string.IsNullOrEmpty(Hgt)
                && !string.IsNullOrEmpty(Hcl)
                && !string.IsNullOrEmpty(Ecl)
                && !string.IsNullOrEmpty(Pid);
            return isValid;
        }
        public bool IsStrictValid()
        {
            bool isValid = IsValid() && ValidByr() && ValidIyr() && ValidEyr() && ValidHgt() && ValidHcl() && ValidEcl() && ValidPid();
            return isValid;
        }

    }
}
