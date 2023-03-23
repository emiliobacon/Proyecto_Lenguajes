using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace expression_tree
{
    public class Node
    {
        public string data;

        public Node father;
        public Node left;
        public Node right;

        public string last;
        public string follow;
        public string numHoja;

        public string nullable;

        public Node(string data)
        {
            this.data = data;
        }

    }
}