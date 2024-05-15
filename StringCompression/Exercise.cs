
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

            return chars.Length;
        }

    }
}
