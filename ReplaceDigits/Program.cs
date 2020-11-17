using System;

namespace ReplaceDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "4 score and 7 years ago, 8 men had the same PIN code: 6571";
            var output = Exercise.ReplaceDigitsFixed(input);
            Console.WriteLine(output);
        }
    }
}
