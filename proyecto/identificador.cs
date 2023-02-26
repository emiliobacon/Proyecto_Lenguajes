using System;
namespace proyecto
{
	public class identificador
	{
        public static void getIdentificador(string line)
        {
            char limitante = '=';
            char blankSpace = ' ';

            string identificador = "";
            string identificadorReal = "";
            string reglaEvaluar = "";

            int index = line.IndexOf(limitante);
            identificador = line.Substring(0, index);

            int index2 = identificador.IndexOf(blankSpace);
            identificadorReal = identificador.Substring(0, index2);

            reglaEvaluar = line.Substring( index + 1);

            readSets.checkSETS(identificadorReal, reglaEvaluar);


            }		
	}
}

