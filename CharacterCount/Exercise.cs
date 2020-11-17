
using System.Collections.Generic;

namespace CharacterCount
{
    public static class Exercise
    {
        // TODO: fix this method - remove boxing & unboxing, and return correct result
        public static object GetCharacterCount(string name)
        {
            var result = new Dictionary<object, object>();
            foreach (char c in name)
            {
                result[c] = 1;
            }
            return result;
        }

        public static Dictionary<char, int> GetCharacterCountFixed(string name)
        {
            var result = new Dictionary<char, int>();
            name = name.ToLower();
            foreach (char c in name)
            {
                if (c != ' ')
                {
                    if (result.ContainsKey(c))
                    {
                        result[c]++;
                    }
                    else
                    {
                        result.Add(c, 1);
                    }
                }
            }
            return result;
        }
    }
}