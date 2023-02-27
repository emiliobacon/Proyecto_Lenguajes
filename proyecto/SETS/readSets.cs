using System;
using System.Text.RegularExpressions;


namespace proyecto
{
	public class readSets
	{
		public static void checkSETS(string id, string rule, int b)
		{
			switch (id)
			{
				case "\tLETRA":
					checkLETRA.checkLetra(rule, b);
					break;
				case "\tDIGITO":
					checkDIGITO.checkDigito(rule, b);
					break;
				case "\tCHARSET":
					checkCHARSET.checkCharset(rule, b);
					break;
				default:
					Console.WriteLine("Error en linea: " + (b + 1));
					break;

			}

        }

		 

	}
}

