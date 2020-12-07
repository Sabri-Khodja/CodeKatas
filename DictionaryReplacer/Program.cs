using System;
using System.Collections.Generic;

namespace DictionaryReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"\$temp\$ here comes the name \$name\$";
            var decodingDictionary = new Dictionary<string, string>()
            {
                { "temp", "temporary" },
                { "name", "John Doe" },
            };

            var output = DictionaryReplacer.DecodeString(input, decodingDictionary);
            
            Console.WriteLine(output);
        }
    }
}
