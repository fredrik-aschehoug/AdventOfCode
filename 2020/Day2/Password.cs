using System.Linq;

namespace Day2
{
    class Password : IPassword
    {
        char letter;
        int min;
        int max;
        string password;

        public string Input { get; set; }

        public Password()
        {
        }
        void Setup()
        {
            string[] slice1 = Input.Split("-");
            string[] slice2 = slice1.Last().Split(" ", 2);
            string[] slice3 = slice2.Last().Split(": ", 2);

            min = int.Parse(slice1.First());
            max = int.Parse(slice2.First());
            letter = char.Parse(slice3.First());
            password = slice3.Last();
        }
        public bool IsValid()
        {
            Setup();
            bool validPassword = false;
            int count = password.Count(c => c == letter);
            if (count >= min & count <= max)
            {
                validPassword = true;
            }
            return validPassword;
        }
    }
}
