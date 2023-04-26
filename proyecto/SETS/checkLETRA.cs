using System;
using System.Text.RegularExpressions;

namespace proyecto
{
    public class checkLETRA
    {
        public static void checkLetra(string line, int b)
        {
            //extraer los caracteres entre comillas simples
            extract_LETRA.extract_LETRA.Main(line);

            string pattern = @"'(.)'(?:\+\.\.|$)";
            string message = Regex.IsMatch(line.Trim(), pattern)
                ? $"SET válido línea {b + 1}"
                : $"No es correcto, error en línea: {b + 1}";

            Console.WriteLine(message);
        }
    }
}

