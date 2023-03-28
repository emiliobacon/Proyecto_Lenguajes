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
<<<<<<< HEAD
        public static void RemoveLastAtList()
        {
			regularExpression.RemoveAt(regularExpression.Count-1);
        }

        public static void printList()
=======
		//Acá debo llamar a llenar el arbol
		public static void printList()
>>>>>>> 757188d2db0276e9b44f86c8118874b42c07c5b4
		{
			

			for (int i = 0; i < regularExpression.Count; i++)
			{
                Console.WriteLine("\n" + regularExpression[i]);
            }
			
			
		}

	}
}

