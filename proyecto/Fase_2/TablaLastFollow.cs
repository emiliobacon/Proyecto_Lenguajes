using expression_tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Fase_2
{
    internal class TablaLastFollow
    {
        private int contador = 1;
        // string[] follo = new string[contador];//Un arreglo con la cantidad de nodos hoja
        //Creo una lista para los follows
        List<string> FTransicion = new List<string>();//Follow
        List<string> Slist = new List<string>();//Simbolos
        
        List<List<string>> Tabla = new List<List<string>>();
       
        string[] follo;
        string[] simbolos;
        string[,] estados;
        string[] transiciones;
        int cantidadFilas=0;
       
        string CadenaLibre;
        public static void GenerateTable(Node arbol)
        {
           

            //Recorrer el arbol en post fix para encontrar los hijos.
            TablaLastFollow tabla = new TablaLastFollow();
            tabla.PostOrder(arbol);
            tabla.PO_FandL(arbol);

            tabla.GenerateFollow(arbol);
            tabla.ImprimirFollow();
            tabla.EncontrarTerminales(arbol);
            tabla.Once();
            tabla.ImprimirTransiciones(arbol);
            tabla.ImprimirTabla();
            
        }
        public void Once()
        {
            HashSet<string> list = new HashSet<string>(Slist);
            simbolos=list.ToArray();

           
        }
        public void GetNumHoja(Node? arbol, string refTermino, string refEstado)
        {
            if (arbol != null)
            {


                GetNumHoja(arbol.left, refTermino, refEstado);
                GetNumHoja(arbol.right, refTermino, refEstado);
                //Nodo actual, Es una hoja
                if (arbol.left == null && arbol.right == null)
                {
                    if(arbol.data==refTermino)
                    {
                        if(refEstado==arbol.numHoja) 
                        {
                            CadenaLibre += follo[Convert.ToInt32(refEstado)]+",";
                           
                        }
                    }
                   
                }
            }
            
        }
        public void ImprimirTabla()
        {
           
           
           Console.Write("\n\n\nTabla de Transiciones");
            for(int i=0; i<simbolos.Length; i++)
            {
                Console.Write("\t\t" + "|"+simbolos[i]+"|");
            }
            Console.WriteLine();
            for (int j = 0; j < FTransicion.Count(); j++)
            {
                Console.Write("S" + j + ": {" + FTransicion.ElementAt(j) + "} | ");//d
                for (int i = 0; i < Tabla.Count(); i++)
                {
                    Console.Write("\t| {" + Tabla.ElementAt(j).ElementAt(i) + "} | ");//d
                }
                Console.WriteLine();
            }
        }
        public void ImprimirTransiciones(Node? arbol)
        {
            //Mi primer estado es el c1 de arbol.
            FTransicion.Add(arbol.c1);
           // transiciones = arbol.c1.Split(',');
            int a = 0;
            int b = 0;//b va a ser mi condicion de salida
           
            while (b==0)
            {
                List<string> fila = new List<string>();
                transiciones = FTransicion.ElementAt(a).Split(',');
                for (int i = 0; i < simbolos.Length; i++)
                {
                   
                   
                    for (int j = 0; j < transiciones.Length; j++)
                    {
                        GetNumHoja(arbol, simbolos[i], transiciones[j]);
                        
                    }
                    //***********************************************************
                    //Quitar la duplicidad
                    string cadena ="";
                    string[] arreglo;
                    string[] NoDuplicado;

                    cadena = CadenaLibre;
                    arreglo = cadena.Split(',');
                    Array.Sort(arreglo);
                    NoDuplicado = arreglo.Distinct().ToArray();
                    CadenaLibre = string.Join(",", NoDuplicado);
                    CadenaLibre = CadenaLibre.Trim(',');
                   //***********************************************************
                   //Corroborar si ya existe
                   if(FTransicion.Contains(CadenaLibre))
                    {

                    }
                   else
                    {
                        FTransicion.Add(CadenaLibre);
                        a++;
                    }
                    fila.Add(CadenaLibre);
                    CadenaLibre = "";

                    
                }
                Tabla.Add(fila);
                cantidadFilas++;
                
                //Realiza el primer recorrido

                //Revisar que ya no hayan estados nuevos

                if(cantidadFilas == FTransicion.Count())
                {
                    b++;
                }

              

            }
           
        }
        public void EncontrarTerminales(Node? arbol)
        {
            //1.Recorre los hijos y guardalos. Estos van a ser tus terminales. No guardés los que ya están contenidos. 
            //2. Matriz
            //3.


            if (arbol != null)
            {


                EncontrarTerminales(arbol.left);
                EncontrarTerminales(arbol.right);
                //Nodo actual, Es una hoja
                if (arbol.left == null && arbol.right == null)
                {
                    if (arbol.data == "#")
                    {

                    }
                    else
                    {
                        Slist.Add(arbol.data);
                    }
                }
            }
            }

        public void ImprimirFollow()
        {
            string cadena;
            string[] arreglo;
            string[] NoDuplicado;

            Console.WriteLine("Tabla follow\n");

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
                    Console.WriteLine((i)+" | "+follo[i]);
                }
                else
                {
                    Console.WriteLine((i) + " | " );
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
           // simbolos= new string[contador];
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
