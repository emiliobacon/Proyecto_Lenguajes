using System;
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
                GenerateString.fillList("'" + text + "'");
            }
        }

        static List<string> ExtractTextBetweenSingleQuotes(string inputString)
        {
            List<string> extractedTexts = new List<string>();
            int startIndex = 0;

            while (startIndex < inputString.Length)
            {
                int openingQuoteIndex = inputString.IndexOf('\'', startIndex);
                if (openingQuoteIndex == -1)
                {
                    break; // No more single quotes found
                }

                int closingQuoteIndex = inputString.IndexOf('\'', openingQuoteIndex + 1);
                if (closingQuoteIndex == -1)
                {
                    break; // No matching closing quote found
                }

                int textStartIndex = openingQuoteIndex + 1;
                int textLength = closingQuoteIndex - textStartIndex;

                string extractedText = inputString.Substring(textStartIndex, textLength);
                extractedTexts.Add(extractedText);

                startIndex = closingQuoteIndex + 1;
            }

            return extractedTexts;
        }

    }
}

