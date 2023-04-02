namespace expression_tree
{
    public static class CompareTokenPriority
    {
        private static readonly Dictionary<string, int> PriorityMap = new Dictionary<string, int>
        {
            ["*"] = 2,
            ["+"] = 2,
            ["?"] = 2,
            ["."] = 3,
            ["|"] = 4,
            ["("] = 1
        };

        public static int CompararPrioridad(string token, string comp)
        {
            var priority1 = PriorityMap[token];
            var priority2 = PriorityMap[comp];

            return priority1.CompareTo(priority2);
        }
    }
}
