using System;
namespace proyecto
{
	public class identificador
	{
        public static void getIdentificador(string line, int b)
        {
            string limitante = "=";
            string blankSpace = " ";

            string identificador = "";
            string identificadorReal = "";
            string reglaEvaluar = "";

            try
            {
                int index = line.IndexOf(limitante);
                identificador = line.Substring(0, index);

                int index2 = identificador.IndexOf(blankSpace);
                identificadorReal = identificador.Trim();
                    //Substring(0, index2);

                reglaEvaluar = line.Substring(index + 1);

                readSets.checkSETS(identificadorReal, reglaEvaluar, b);
            }
            catch (Exception)
            {
                Console.WriteLine("Error en linea: " + (b + 1));
            }
            

           


            }		
	}
}

