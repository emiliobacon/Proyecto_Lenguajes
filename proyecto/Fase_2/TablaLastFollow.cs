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
        private int contador = 1;
       // string[] follo = new string[contador];//Un arreglo con la cantidad de nodos hoja
        //Creo una lista para los follows
        List<string> Flist = new List<string>();//Follow
        List<string> Slist = new List<string>();//Simbolos

        //NO SE USAN LAS LISTAS, PERO NO ME ACUERDO SI LAS PUSE. ASÍ QUE MEJOR NO TOCO NADA 
        string[] follo;

        public static void GenerateTable(Node arbol)
        {
           

            //Recorrer el arbol en post fix para encontrar los hijos.
            TablaLastFollow tabla = new TablaLastFollow();
            tabla.PostOrder(arbol);
            tabla.PO_FandL(arbol);

            tabla.GenerateFollow(arbol);
            tabla.ImprimirFollow();
            
        }
        public void ImprimirFollow()
        {
            string cadena;
            string[] arreglo;
            string[] NoDuplicado;
 
            for (int i = 0; i < follo.Length; i++)
            {
                if (follo[i]!=null)
                {
                    cadena = follo[i];
                    arreglo = cadena.Split(',');
                    Array.Sort(arreglo);
                    NoDuplicado = arreglo.Distinct().ToArray();
                    follo[i] = string.Join(",", NoDuplicado);
                    follo[i] = follo[i].Trim(',');
                    Console.WriteLine(follo[i]);
                }
            
            }
        }
        public void GenerateFollow(Node? arbol)
        {
            
            
            if (arbol != null)
            {


                GenerateFollow(arbol.left);
                GenerateFollow(arbol.right);
                //Nodo actual, Es una hoja
                if (arbol.left == null && arbol.right == null)
                {

                   //Es una hoja, no hace nada
                }
                else if (arbol.data == "*")
                {

                        string[] simbolo = arbol.left?.c2.Split(',');
                        for (int i = 0; i < simbolo.Length; i++)
                        {
                         int indice = Convert.ToInt16(simbolo[i]);
                                follo[indice] = follo[indice] + arbol.left.c1 + ",";
                            

                        }
  
                }
                else if (arbol.data == "|" || arbol.data == "?")
                {
                    //No hace nada para el follow
                }
                else if (arbol.data == "." || arbol.data == "+")
                {
                    if (arbol.right == null)
                    {
                        string[] simbolo = arbol.left?.c2.Split(',');
                        for (int i = 0; i < simbolo.Length; i++)
                        {
                           
                            int indice = Convert.ToInt16(simbolo[i]);
                            follo[indice] = follo[indice] + arbol.left.c1 + ",";

                        }
                    }
                    else
                    {
                        string[] simbolo = arbol.left?.c2.Split(',');
                        for(int i = 0;i<simbolo.Length;i++)
                        {
                           
                            int indice = Convert.ToInt16(simbolo[i]);
                            follo[indice] = follo[indice] + arbol.right.c1 + ",";

                        }
                    }

                }

            }

           


        }
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        public void PostOrder(Node? arbol) 
        {
           
            if(arbol!=null) 
            {

               
                PostOrder(arbol.left);
                PostOrder(arbol.right);
                //Nodo actual, Es una hoja
                if(arbol.left==null && arbol.right ==null)
                {
                   
                    arbol.numHoja = Convert.ToString(contador);
                    arbol.c1 = Convert.ToString(contador);
                    arbol.c2 = Convert.ToString(contador);
                    arbol.nullable = false;
                    contador++;
                    
                  //  Console.WriteLine("Hoja: " +arbol.numHoja);
                }
                else if( arbol.data=="*")
                {
                    arbol.nullable = true;
                }
                else if (arbol.data == "|" || arbol.data == "?")
                {
                    if (arbol.right == null)
                    {
                        arbol.nullable = true;
                    }
                    else
                    {
                        if (arbol.left?.nullable == true || arbol.right?.nullable == true)
                        {
                            arbol.nullable = true;
                        }
                    }
                }
                else if (arbol.data == "." || arbol.data == "+")
                {
                    if(arbol.right==null)
                    {
                        arbol.nullable = true;
                    }
                    else
                    {
                        if (arbol.left?.nullable == true && arbol.right?.nullable == true)
                        {
                            arbol.nullable = true;
                        }
                    }
                  
                }

            }
            follo = new string[contador];//Un arreglo con la cantidad de nodos hoja

        }

        public void PO_FandL(Node arbol)//PostOrder para First y last
        {

            if (arbol != null)
            {
                PO_FandL(arbol.left);
                PO_FandL(arbol.right);
                //Nodo actual, Es una hoja
                if (arbol.left == null && arbol.right == null)
                {
                    //Es una hoja. Lo ignoro
                }
                else if (arbol.data == "|" || arbol.data == "?")
                {
                    if(arbol.right == null)
                    {
                        //Firts
                        arbol.c1 = Convert.ToString(arbol.left?.c1 );
                        arbol.c2 = Convert.ToString(arbol.left?.c2 );
                    }
                    else
                    {
                        //Firts
                        arbol.c1 = Convert.ToString(arbol.left?.c1 + "," + arbol.right?.c1);
                        //Last
                        arbol.c2 = Convert.ToString(arbol.left?.c2 + "," + arbol.right?.c2);
                    }
                  
                }
                else if (arbol.data == "*")
                {
                    //Fist
                    arbol.c1 = Convert.ToString(arbol.left?.c1);
                    //Last
                    arbol.c2 = Convert.ToString(arbol.left?.c2);
                }
                else if (arbol.data == "." || arbol.data == "+")
                {
                    
                    if(arbol.right==null)
                    {
                        //First
                        arbol.c1 = arbol.left?.c1;
                        arbol.c2= arbol.left?.c2;
                    }
                    else
                    {
                        //First
                        if (arbol.left?.nullable == true)
                        {
                            arbol.c1 = arbol.left.c1 + "," + arbol.right?.c1;
                        }
                        else
                        {
                            arbol.c1 = arbol.left?.c1;
                        }

                        //Last
                        if (arbol.right?.nullable == true)
                        {
                            arbol.c2 = arbol.left?.c2 + "," + arbol.right.c2;
                        }
                        else
                        {
                            arbol.c2 = arbol.right?.c2;
                        }
                    }
                   
                }
            }
        }

    }


}
