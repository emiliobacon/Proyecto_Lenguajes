using System;
using System.Text.RegularExpressions;

namespace proyecto
{
	public class checkCHARSET
    {
        public static void checkCharset(string line, int b)
        {
            if (Regex.IsMatch(line, "(( )*CHR[(]([0-9]+)[)]([..]|[+]))+"))
            {
                Console.WriteLine("Correcto");
            }
            else
            {
                Console.WriteLine("No es correcto, error en linea: " + b.ToString());
            }

            //CHR(32)..CHR(254)

        }
    }
}

