using System;
using System.Text.RegularExpressions;

namespace proyecto
{
	public class checkDIGITO
	{
        
       
        public static void checkDigito(string line)
        {
            
            if (Regex.IsMatch(line, "(( )*'[0-9]'([..]|[+]))+"))
            {
                Console.WriteLine("Correcto");
            }
            else
            {
                Console.WriteLine("No es correcto");
            }

            //
            //'0'..'9'

        }
    }
}

