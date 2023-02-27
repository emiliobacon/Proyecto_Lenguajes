using System;
using System.Text.RegularExpressions;

namespace proyecto
{
	public class checkLETRA
	{

		public static void checkLetra(string line, int b)
		{
			if (Regex.IsMatch(line, "(( )*['][A-Z]|[a-z]|[_][']([..]|[+]))+"))
			{
				int lineNumber = b + 1;
				Console.WriteLine("SET valido linea " + lineNumber);
			}
			else
			{
				Console.WriteLine("No es correcto, error en linea: " + (b+1).ToString());
			}

            //'A'..'Z'+'a'..'z'+'_'
            

        }
	}
}

