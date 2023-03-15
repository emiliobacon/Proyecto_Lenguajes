using System;
using System.Text.RegularExpressions;

namespace proyecto.REGULAR_EXPRESION
{
	public class trimToken
	{
        public static void extractToken(string token)
        {
            string limiter = "=";
            int index = token.IndexOf(limiter);
            string extractedToken = token.Substring(index + 1);

            trimText(extractedToken);
        }

        private static void trimText(string inputString)
        {
            List<string> extractedTexts = GetStrings(inputString);

            foreach (string text in extractedTexts)
            {

                GenerateString.fillList(text);
            }
        }

        public static List<string> GetStrings(string input)
        {
            List<string> strings = new List<string>();

            int i = 0;
            while (i < input.Length)
            {
                if (input[i] == '\'')
                {
                    int j = i + 1;
                    while (j < input.Length && input[j] != '\'')
                    {
                        j++;
                    }
                    if (j < input.Length && input[j] == '\'')
                    {
                        strings.Add(input.Substring(i, j - i + 1));
                        i = j + 1;
                    }
                    else
                    {
                        strings.Add(input.Substring(i));
                        i = input.Length;
                    }
                }
                else if (char.IsWhiteSpace(input[i]))
                {
                    i++;
                }
                else
                {
                    int j = i;
                    while (j < input.Length && !char.IsWhiteSpace(input[j]) && input[j] != '\'')
                    {
                        j++;
                    }
                    strings.Add(input.Substring(i, j - i));
                    i = j;
                }
            }

            return strings;
        }

        //static List<string> ExtractTextBetweenSingleQuotes(string input)
        //{
        //    List<string> strings = new List<string>();

        //    Regex regex = new Regex("(?<=')[^']*(?=')|\\S+");
        //    MatchCollection matches = regex.Matches(input);

        //    foreach (Match match in matches)
        //    {
        //        strings.Add(match.Value);
        //    }

        //    return strings;

        //}

    }
}

