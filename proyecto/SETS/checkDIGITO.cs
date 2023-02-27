using System;
using System.Text.RegularExpressions;

namespace proyecto
{
	public class checkDIGITO
	{
        
       
        public static void checkDigito(string line, int b)
        {
            
            if (Regex.IsMatch(line, "(( )*'[0-9]'([..]|[+]))+"))
            {
                int lineNumber = b + 1;
                Console.WriteLine("SET valido linea " + lineNumber);
            }
            else
            {
                Console.WriteLine("No es correcto, error en linea: " + b.ToString());
            }

            //
            //'0'..'9'

        }
    }
}

