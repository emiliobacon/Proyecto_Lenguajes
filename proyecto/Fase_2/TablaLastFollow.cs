using expression_tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Fase_2
{
    internal class TablaLastFollow
    {

        public static void GenerateTable(Node arbol)
        {
            //Recorrer el arbol en post fix para encontrar los hijos.

            PostOrder(arbol.father);
            Console.WriteLine("Ya");


        }


        public static void PostOrder(Node arbol) 
        {
            int contador = 1;
            if(arbol!=null) 
            {
                PostOrder(arbol.left);
                PostOrder(arbol.right);
                //Nodo actual, Es una hoja
                if(arbol.left==null && arbol.right ==null)
                {
                    arbol.numHoja = Convert.ToString(contador);
                    contador++;
                }
            
            }
        }

    }


}
