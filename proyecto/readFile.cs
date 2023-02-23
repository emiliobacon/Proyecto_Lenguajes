using System;
using System.IO;

namespace proyecto
{
	public class readFile
	{
        public static void Read()
        {
            string filePath = "/Users/emilio/Desktop/proyecto/proyecto/docs/GRAMATICA.txt";

            // Abre el archivo utilizando StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Lee el archivo línea por línea
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Procesa la línea leída del archivo
                    Console.WriteLine(line);
                }
            } 

            // Cierra el archivo
            Console.ReadLine();
        }
    }
}

