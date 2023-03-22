using System;
namespace expression_tree
{
    public class compareTokenPriority
    {
        public static Dictionary<string, int> priorityMap;

        public static int compararPrioridad(string token, string comp)
        {
            // Inicializa el diccionario con los símbolos y sus prioridades
            priorityMap = new Dictionary<string, int>();
            priorityMap["*"] = 2;
            priorityMap["+"] = 2;
            priorityMap["?"] = 2;
            priorityMap["."] = 3;
            priorityMap["|"] = 4;
            priorityMap["("] = 1;

            int priority1 = priorityMap[token];
            int priority2 = priorityMap[comp];

            if (priority1 > priority2)
            {
                return 1;
            }
            else if (priority1 < priority2)
            {
                return 0;
            }
            else
            {
                // Si los dos símbolos tienen la misma prioridad, devuelve 0
                return 0;
            }
        }
    }
}

