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
				Console.WriteLine("Correcto");
			}
			else
			{
				Console.WriteLine("No es correcto, error en linea: " + b.ToString());
			}

            //'A'..'Z'+'a'..'z'+'_'
            

        }
	}
}

