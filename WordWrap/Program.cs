﻿using System;

namespace WordWrap
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog.";
            var formattedText = Wrapper.Wrap(text, 80);

            Console.WriteLine(formattedText);    
        }
    }
}
