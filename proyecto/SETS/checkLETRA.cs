using System;
using System.Text.RegularExpressions;

namespace proyecto
{
	public class checkLETRA
	{

		public static void checkLetra(string line, int b)
		{
			//ARREGLAR
			if (Regex.IsMatch(line.Trim(), @"('[a-zA-Z]'\s)*(\+|\.\.)\s*)*"))
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

