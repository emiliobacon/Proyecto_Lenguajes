using System;
using System.Text.RegularExpressions;

namespace proyecto.REGULAR_EXPRESION
{
	public class trimToken
	{
        public static void extractToken(string token, int contador, bool escribirOr)
        {
            
            string limiter = "=";
            int index = token.IndexOf(limiter);
            string extractedToken = token.Substring(index + 1);
            
            // me agrega el parentesis para manejar precedencia
            if (contador == 0) extractedToken = "(" + extractedToken;
            
            trimText(extractedToken, escribirOr);
        }

        private static void trimText(string inputString, bool escribirOr)

        {
            List<string> extractedTexts = GetStrings(inputString);

            foreach (string text in extractedTexts)
            {
                GenerateString.fillList(text);
            }
            //solo agrega el | cuando se le envia true
            if(escribirOr== true) GenerateString.fillList("|");

        }
        //quita el ultimo elemento de la lista
        public static void RemoveText()
        {
            GenerateString.RemoveLastAtList();
        }

        //casos
        //1. no se concatena si es simbolo no terminal  ya
        //2. agregar el simbolo # al final + ()
        //3. que no agarre la llave { o actions   ya
        //5. colocar una concatenacion entre cada simbolo terminal   ya
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
                        if (input.Length > j + 1)
                        {
                            if (input[j + 1] == '\'') //aca valido mi problema conlas ''' CHARSET '''
                            {
                                strings.Add(input.Substring(i, j - i + 2));
                                i = j + 2;
                            }
                            else
                            {
                                strings.Add(input.Substring(i, j - i + 1));
                                i = j + 1;
                            }

                        }
                        else
                        {
                            strings.Add(input.Substring(i, j - i + 1));
                            i = j + 1;
                        }
                    }
                    else
                    {
                        strings.Add(input.Substring(i));
                        i = input.Length;
                    }
                }
                else if (char.IsWhiteSpace(input[i])) //Agregar las concatenaciones
                {
                    if (input[i] == ' ' && (i + 1 >= input.Length || input[i + 1] != '*' && input[i + 1] != '+' && input[i + 1] != '?' && input[i + 1] != '.' && input[i + 1] != '|' && input[i - 1] != '|' && input[i - 1] != '(' && input[i + 1] != ')'))
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
                    strings.Add(input.Substring(i, j - i));
                    i = j;
                }
            }
            return strings;
        }
    }
}

