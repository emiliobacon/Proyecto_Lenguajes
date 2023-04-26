using System;
using System.Collections.Generic;
using proyecto.Fase_3;

namespace extract_LETRA
{
    class extract_LETRA
    {
        public static void Main(string input)
        {
            List<char> charactersBetweenQuotes = ExtractCharactersBetweenQuotes(input);

            GenerateJava.printIdentifySet(charactersBetweenQuotes);
        }

        static List<char> ExtractCharactersBetweenQuotes(string input)
        {
            List<char> extractedCharacters = new List<char>();
            bool insideQuotes = false;

            foreach (char c in input)
            {
                if (c == '\'')
                {
                    insideQuotes = !insideQuotes;
                }
                else if (insideQuotes)
                {
                    extractedCharacters.Add(c);
                }
            }

            return extractedCharacters;
        }
    }
}
