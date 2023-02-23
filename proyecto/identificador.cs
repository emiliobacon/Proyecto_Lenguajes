using System;
namespace proyecto
{
	public class identificador
	{
        public static string getIdentificador(string line)
        {
            char limitante = '=';
            char blankSpace = ' ';

            string identificador = "";
            string identificadorReal = "";

            int index = line.IndexOf(limitante);
            identificador = line.Substring(0, index);

            int index2 = identificador.IndexOf(blankSpace);
            identificadorReal = identificador.Substring(0, index2);

            readSets.checkSETS(identificadorReal, line);

            return (line);
        }		
	}
}

