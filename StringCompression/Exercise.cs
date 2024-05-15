
using System;
using System.Collections.Generic;
using System.Linq;
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
                    writeIndex = WriteCompressedCharsGroup(chars, writeIndex, previousChar, numberOfConsecutiveChars);
                    
                    numberOfConsecutiveChars = 1;
                }

                previousChar = currentChar;
            }
            
            writeIndex = WriteCompressedCharsGroup(chars, writeIndex, previousChar, numberOfConsecutiveChars);

            return writeIndex;
        }

        private static int WriteCompressedCharsGroup(char[] chars, int writeIndex, char charToWrite,
            int numberOfOccurences)
        {
            chars[writeIndex++] = charToWrite;
            if (numberOfOccurences > 1)
            {
                foreach (var c in numberOfOccurences.ToString())
                {
                    chars[writeIndex++] = c;
                }
            }

            return writeIndex;
        }
    }
}
