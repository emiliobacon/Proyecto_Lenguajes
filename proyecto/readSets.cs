﻿using System;
using System.Text.RegularExpressions;


namespace proyecto
{
	public class readSets
	{
		public static void checkSETS(string id, string rule)
		{
			switch (id)
			{
				case "\tLETRA":
					checkLETRA.checkLetra(rule);
					break;
			}
        }

		 

	}
}

