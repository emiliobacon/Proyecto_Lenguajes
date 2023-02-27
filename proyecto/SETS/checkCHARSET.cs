using System;
using System.Text.RegularExpressions;

namespace proyecto
{
	public class checkCHARSET
    {
        public static void checkCharset(string line, int b)
        {
            if (Regex.IsMatch(line.Trim(), @"^CHR\(\d{1,3}\)([\+\.]{2}CHR\(\d{1,3}\))*$"))
            {
                int lineNumber = b + 1;
                Console.WriteLine("SET valido linea " + lineNumber);
            }
            else
            {
                Console.WriteLine("No es correcto, error en linea: " + (b+1).ToString());
            }

            //CHR(32)..CHR(254)

        }
    }
}

