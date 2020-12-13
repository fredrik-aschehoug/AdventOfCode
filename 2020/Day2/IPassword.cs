namespace Day2
{
    interface IPassword
    {
        string Input { get; set; }

        bool IsValid();
    }
}