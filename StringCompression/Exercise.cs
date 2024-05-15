
using System;
using System.Collections.Generic;

namespace StringCompression
{
    public static class Exercise
    {
        public static int Compress(char[] chars)
        {
            if (chars.Length == 0)
            {
                return 0;
            }

            var previousChar = chars[0];
            for(int i = 1; i < chars.Length; i++)
            {
                var currentChar = chars[i];
                if (currentChar == previousChar)
                {
                    throw new ArgumentException("Case not supported");
                }

                previousChar = currentChar;
            }
            return chars.Length;
        }

    }
}
