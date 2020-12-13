using System;
using System.Linq;

namespace Day2
{
    class Password2 : IPassword
    {
        private char letter;
        private int index1;
        private int index2;
        private string password;

        public string Input { get; set; }

        public Password2()
        {

        }
        void Setup()
        {
            string[] slice1 = Input.Split("-");
            string[] slice2 = slice1.Last().Split(" ", 2);
            string[] slice3 = slice2.Last().Split(": ", 2);

            index1 = int.Parse(slice1.First()) - 1;
            index2 = int.Parse(slice2.First()) - 1;
            letter = char.Parse(slice3.First());
            password = slice3.Last();
        }

        public bool IsValid()
        {
            Setup();
            try
            {
                if (password[index1] == letter & password[index2] != letter)
                {
                    return true;
                }
                if (password[index1] != letter & password[index2] == letter)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

            return false;
        }
    }
}
