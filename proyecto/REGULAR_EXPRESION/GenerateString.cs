using System;
using System.Collections.Generic;

namespace proyecto.REGULAR_EXPRESION
{
	public class GenerateString
	{
		public static List<string> regularExpression = new List<string>();


		public static void fillList(string token)
		{
			regularExpression.Add(token);
		}

		public static string printList()
		{
			string concatenadedRegularExpression = "";

			for (int i = 0; i < regularExpression.Count; i++)
			{
                concatenadedRegularExpression += regularExpression[i];
            }
			
			return concatenadedRegularExpression;

		}

	}
}

