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
            List<string> extractedTexts = ExtractTextBetweenSingleQuotes(inputString);

            foreach (string text in extractedTexts)
            {

                GenerateString.fillList(text);
            }
        }

        static List<string> ExtractTextBetweenSingleQuotes(string input)
        {
            List<string> strings = new List<string>();

            Regex regex = new Regex("(?<=')[^']*(?=')|\\S+");
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                strings.Add(match.Value);
            }

            return strings;

        }

    }
}

