using System;
using System.IO;


namespace proyecto
{
	public class readFile
	{
        
        public static void Read()
        {
            int contador = 1;
            List<string> txt = new List<string>();
            string filePath = "/Users/emilio/Desktop/proyecto/proyecto/docs/GRAMATICA.txt";

            // Abre el archivo utilizando StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Lee el archivo línea por línea
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Guardar cada línea en una lista para su uso posterior
                    txt.Add(line);
                    contador++;
                }
            }


            if (txt[0] == "SETS")
            {
                while (contador != 0)
                { 
                    if (txt[0] != "TOKENS")
                    {
                        txt.RemoveAt(0);
                        string line = txt[0];

                        identificador.getIdentificador(line);
                    }
                }


            }
            
            
     
        }

        
    }
}

