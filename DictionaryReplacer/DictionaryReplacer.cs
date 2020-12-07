using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryReplacer
{
    public class DictionaryReplacer
    {
        private const string PatternDelimiter = @"\$";
        public static string DecodeString(string input, Dictionary<string, string> decodeDictionary)
        {
            if(input == null) throw new ArgumentException("can't accept null input string", nameof(input));
            if (decodeDictionary == null) throw new ArgumentException("can't accept null decodeDictionary", nameof(decodeDictionary));
            if (input == String.Empty) return String.Empty;
            if (decodeDictionary.Count == 0) return input;

            //Scan input for /$key/$ patterns and replace with corresponding values
            StringBuilder builder = new StringBuilder(input);
            var patternStarted = false;
            StringBuilder currentPatternBuilder = new StringBuilder(20);
            StringBuilder outputStringBuilder = new StringBuilder(input.Length);
            for (int i = 0; i < builder.Length; i++)
            {
                if (builder[i] == '\\' && builder[i+1] == '$')
                {
                    if (patternStarted)
                    {
                        var currentPattern = currentPatternBuilder.ToString();
                        if (decodeDictionary.ContainsKey(currentPattern))
                        {
                            outputStringBuilder.Append(decodeDictionary[currentPattern]);
                        }
                        else
                        {
                            outputStringBuilder.Append(PatternDelimiter);
                            outputStringBuilder.Append(currentPattern);
                            outputStringBuilder.Append(PatternDelimiter);
                        }
                            
                        patternStarted = false;
                        currentPatternBuilder.Clear();
                    }
                    else
                    {
                        patternStarted = true;
                    }

                    i += 1;
                }
                else
                {
                    if (patternStarted)
                    {
                        currentPatternBuilder.Append(builder[i]);
                    }
                    else
                    {
                        outputStringBuilder.Append(builder[i]);
                    }
                }
            }
            return outputStringBuilder.ToString();
        }
    }
}
