using System;

namespace expression_tree
{
    public class convert_to_RET
    {
        //Pila de tokens T
        public static Stack<string> pila_T = new Stack<string>();
        //Pila de árboles S
        public static Stack<Node> pila_S = new Stack<Node>();

        public static void generateRegularExpressionTree(List<string> tokens)
        {
            //PASO 1
            for (int i = 0; i < tokens.Count(); i++)
            {
                //PASO 2
                string token = tokens[i];


                switch (token)
                {
                    //PASO 4
                    case "(":
                        pila_T.Push(token);
                        break;
                    //PASO 5    
                    case ")":
                        parentesis_cierre(token);
                        break;

                    case ".":
                        noUnario(token);
                        break;

                    case "|":
                        noUnario(token);
                        break;

                    case "+":
                        operadorUnario(token);
                        break;

                    case "*":
                        operadorUnario(token);
                        break;

                    case "?":
                        operadorUnario(token);
                        break;

                    //PASO 3 - TOKEN ES SIMBOLO TERMINAL
                    default:
                        Node newNode = new Node(token);
                        pila_S.Push(newNode);
                        break;
                }

            }

            //PASO 9 
            while (pila_T.Count() > 0)
            {
                //a.Hacer “pop” de T y crear un nuevo árbol llamado temp
                Node newNode = new Node(pila_T.Pop());
                if (newNode.data != "(")
                {
                    if (pila_S.Count() > 1)
                    {
                        //d.	Hacer “pop” a la pila S y asignarlo como hijo derecho de temp
                        newNode.right = pila_S.Pop();
                        //e.	Hacer “pop” a la pila S y asignarlo como hijo izquierdo de temp
                        newNode.left = pila_S.Pop();
                        //f.	Hacer “push” a la pila S con el árbol temp
                        pila_S.Push(newNode);
                    }
                }

            }

            //pila_S.Pop();
        }

        //PASO 6
        private static void operadorUnario(string token)
        {
            //Convertir op en árbol
            Node newNode = new Node(token);
            //Si la longitud de S no es menor que 0
            if (pila_S.Count() > 0)
            {
                //Hacer “pop” de S y asignarlo como hijo izquierdo
                newNode.left = pila_S.Pop();

                //Hacer “push” a la pila S con el nuevo árbol generado de op
                pila_S.Push(newNode);
            }
        }

        //PASO 6 - B
        private static void noUnario(string token)
        {
            if (pila_T.Count() != 0)
            {
                if (pila_T.Peek() != "(")
                {
                    if (CompareTokenPriority.CompararPrioridad(token, pila_T.Peek()) == 0)
                    {
                        Node newNode = new Node(pila_T.Pop());

                        if (pila_S.Count > 1)
                        {
                            newNode.right = pila_S.Pop();
                            newNode.left = pila_S.Pop();

                            pila_S.Push(newNode);
                        }
                    }
                }
            }

            //PASO 6 - C
            pila_T.Push(token);
        }

        //PASO 5
        private static void parentesis_cierre(string token)
        {
            while (pila_T.Count() > 0 & pila_T.Peek() != "(")
            {
                if (pila_T.Count != 0)
                {
                    if (pila_S.Count > 1)
                    {
                        Node newNode = new Node(pila_T.Pop());

                        newNode.right = pila_S.Pop();
                        newNode.left = pila_S.Pop();

                        pila_S.Push(newNode);
                    }
                }
            }
            pila_T.Pop();
        }
    }
}

