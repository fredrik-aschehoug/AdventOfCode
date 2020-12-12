using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2
{
    class Password
    {
        public char letter;
        public int min;
        public int max;
        public string password;

        public Password(string password)
        {
            string[] slice1 = password.Split("-");
            string[] slice2 = slice1.Last().Split(" ", 2);
            string[] slice3 = slice2.Last().Split(": ", 2);

            this.min = int.Parse(slice1.First());
            this.max = int.Parse(slice2.First());
            this.letter = char.Parse(slice3.First());
            this.password = slice3.Last();
        }

        public bool isValid()
        {
            bool validPassword = false;
            int count = password.Count(c => c == letter);
            if(count >= min & count <= max)
            {
                validPassword = true;
            }
            return validPassword;
        }
    }
}
