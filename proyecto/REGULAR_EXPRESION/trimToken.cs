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
            GenerateString.fillList("|");
        }

        //private static void trimText(string inputString)
        //{
        //    List<string> extractedTexts = GetStrings(inputString);

        //    for (int i = 0; i < extractedTexts.Count; i++)
        //    {
        //        string text = extractedTexts[i];
        //        if (i == 0) // add '(' to the beginning of the first line
        //        {
        //            text = "(" + text;
        //        }
        //        if (i == extractedTexts.Count - 1) // add ").#" to the end of the last line
        //        {
        //            text += ").#";
        //        }
        //        GenerateString.fillList(text);
        //    }
        //}

        //casos
        //1. no se concatena si es simbolo no terminal
        //2. agregar el simbolo # al final + ()
        //3. que no agarre la llave { o actions 
        //5. colocar una concatenacion entre cada simbolo terminal
        //6. hacer al recorrido prefijo (recorre hijo izquiero, derecho y de ultimo en medio)

        //public static List<string> GetStrings(string input)
        //{
        //    List<string> strings = new List<string>();


        //    for (int i = 0; i < input.Length; i++)
        //    {

        //        // If the current character is a space and the next character is not a *, add a period
        //        if (input[i] == ' ' && (i + 1 >= input.Length || input[i + 1] != '*'))
        //        {
        //            strings.Add(" . ");
        //        }
        //        else if (char.IsLetter(input[i]))
        //        {
        //            i++;
        //        }
        //        else
        //        {
        //            strings.Add(input.Substring(i));
        //            i = input.Length;
        //        }
        //    }

        //    return strings;
        //}


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

        public static List<string> GetStrings(string input1)
        {
            List<string> strings = new List<string>();
            string input = input1.Trim();

            int i = 0;
            while (i < input.Length)
            {  
                if (input[i] == '{') break;
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
                    if (input[i] == ' ' && (i + 1 >= input.Length || input[i + 1] != '*' && input[i + 1] != '+' && input[i + 1] != '?' && input[i + 1] != '.' && input[i + 1] != '|' && input[i + 1] != '(' && input[i + 1] != ')'))
                    {
                        strings.Add(".");
                    }
                    i++;
                }
                else
                {
                    int z = 0;
                    int j = i;
                    while (j < input.Length && !char.IsWhiteSpace(input[j]) && input[j] != '\'')
                    {
                        z++;
                        j++;
                    }

                    //if (z < i)
                    //{
                    //    //if (input[i] == ' ')
                    //    //{
                    //    //    if (i < input.Length)
                    //    //    {
                    //    //        if (input[i + 1] != '*')
                    //    //        {
                    //    //            strings.Add(".");
                    //    //        }

                    //    //    }

                    //    //}
                    //}
                    strings.Add(input.Substring(i, j - i));
                    i = j;
                }
            }
            return strings;
        }

    }
}

