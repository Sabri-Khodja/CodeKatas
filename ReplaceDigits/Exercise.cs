using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ReplaceDigits
{
    public static class Exercise
    {
        // TODO: fix this method - fix bugs, make more efficient, and return correct result
        public static string ReplaceDigits(string sentence)
        {
            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            for (var i = 0; i < words.Length; i++)
            {
                sentence = sentence.Replace(i.ToString(), words[i]);
            }
            return sentence;
        }
        
        static readonly Dictionary<char, string> DigitToString = new Dictionary<char, string>()
        {
            { '0', "zero"},
            { '1', "one"},
            { '2', "two"},
            { '3', "three"},
            { '4', "four"},
            { '5', "five"},
            { '6', "six"},
            { '7', "seven"},
            { '8', "eight"},
            { '9', "nine"},
        };

        public static string ReplaceDigitsFixed(string sentence)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(sentence);

            int i = 0;
            List<char> foundDigits = new List<char>(10);

            while (i < builder.Length)
            {
                var c = builder[i];
                var endReached = false;
                while (!endReached && IsDigit(c))
                {
                    foundDigits.Add(c);
                    builder.Remove(i, 1);
                    if (i < builder.Length)
                    {
                        c = builder[i];
                    }
                    else
                    {
                        endReached = true;
                    }
                }
                
                for (int j = 0; j < foundDigits.Count; j++)
                {
                    var stringToInsert = DigitToString[foundDigits[j]];

                    builder.Insert(i, stringToInsert);
                    i += stringToInsert.Length;
                    if (j < foundDigits.Count - 1)
                    {
                        builder.Insert(i, ' ');
                        i++;
                    }
                }

                foundDigits.Clear();
                i++;
            }

            return builder.ToString();
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}