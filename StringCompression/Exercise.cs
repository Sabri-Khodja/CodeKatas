
using System;
using System.Collections.Generic;
using System.Text;

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
            var numberOfConsecutiveChars = 1;
            var writeIndex = 0;
            for(int i = 1; i < chars.Length; i++)
            {
                var currentChar = chars[i];
                if (currentChar == previousChar)
                {
                    numberOfConsecutiveChars++;
                }
                else
                {
                    chars[writeIndex++] = previousChar;
                    if (numberOfConsecutiveChars > 1)
                    {
                        chars[writeIndex++] = char.Parse(numberOfConsecutiveChars.ToString());
                    }
                    
                    numberOfConsecutiveChars = 1;
                }

                previousChar = currentChar;
            }
            
            chars[writeIndex++] = previousChar;
            if (numberOfConsecutiveChars > 1)
            {
                chars[writeIndex++] = char.Parse(numberOfConsecutiveChars.ToString());
            }
            
            return writeIndex;
        }

    }
}
