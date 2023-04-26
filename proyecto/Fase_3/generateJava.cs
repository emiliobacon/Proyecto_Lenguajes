namespace proyecto.Fase_3
{
    class GenerateJava
    {
        private static string _filePath = "/Users/emilio/Desktop/Proyecto LFYA/proyecto/docs/Java.txt";

        public static void printIdentifySet(List<char> charList)
        {
            string codigo = " static String identify_SET(char lexeme) {" + "\n int lexeme_value = (int) lexeme; ";

            bool foundA = false;
            bool foundZ = false;
            bool foundLowerA = false;
            bool foundLowerZ = false;
            int contador = 0;

            for (int i = 0; i < charList.Count;)
            {
                if (charList[i] == 'A')
                {
                    foundA = true;
                    charList.RemoveAt(i);
                }
                else if (charList[i] == 'Z')
                {
                    foundZ = true;
                    charList.RemoveAt(i);
                }
                else if (charList[i] == 'a')
                {
                    foundLowerA = true;
                    charList.RemoveAt(i);
                }
                else if (charList[i] == 'z')
                {
                    foundLowerZ = true;
                    charList.RemoveAt(i);
                }
                else
                {
                    codigo += "int LETRA" + contador.ToString() + "_ONLY = (int) '" + charList[i] + "';" +
                    "\n if (lexeme_value == LETRA" + contador.ToString() + "_ONLY)  return \"LETRA\"; ";
                    charList.RemoveAt(i);
                }

                if (foundA && foundZ)
                {

                    foundA = foundZ = false;
                }

                if (foundLowerA && foundLowerZ)
                {
                    Console.WriteLine("lowercase");
                    foundLowerA = foundLowerZ = false;
                }

                if (!foundA && !foundZ && !foundLowerA && !foundLowerZ)
                {
                    i++; // Update the index only if we haven't found A, Z, a or z
                }

                contador++;
            }



            // default:
            //     codigo += "int LETRA" + i.ToString() + "_ONLY = (int) '" + letra[i] + "';" +
            //     "\n if (lexeme_value == LETRA" + i.ToString() + "_ONLY)  return \"LETRA\"; ";
            //     break;





            File.WriteAllText(_filePath, String.Empty);

            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(codigo);
            }

        }



    }
}