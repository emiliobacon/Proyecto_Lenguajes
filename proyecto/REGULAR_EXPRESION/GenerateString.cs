using System;
using System.Collections.Generic;

namespace proyecto.REGULAR_EXPRESION
{
	public class GenerateString
	{
		public static List<string> regularExpression = new List<string>();

		public static void fillList()
		{

		}

		public static string printList()
		{
			string concatenadedRegularExpression = "";
			int a = 0;

			while (regularExpression.Count == a)
			{
				concatenadedRegularExpression += regularExpression[a];
				a++;
			}
			return concatenadedRegularExpression;

		}

	}
}

