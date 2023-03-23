namespace expression_tree
{
    public abstract class CompareTokenPriority
    {
        private static Dictionary<string, int>? _priorityMap;

        public static int CompararPrioridad(string token, string comp)
        {
            // Inicializa el diccionario con los símbolos y sus prioridades
            _priorityMap = new Dictionary<string, int>();
            
            _priorityMap["*"] = 2;
            _priorityMap["+"] = 2;
            _priorityMap["?"] = 2;
            _priorityMap["."] = 3;
            _priorityMap["|"] = 4;
            _priorityMap["("] = 1;

            var priority1 = _priorityMap[token];
            var priority2 = _priorityMap[comp];
            
            
            if (priority1 < priority2)
            {
                return 1;
            }
            else if (priority1 > priority2)
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
