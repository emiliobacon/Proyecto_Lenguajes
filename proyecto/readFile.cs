using System;
using System.IO;
using System.Text.RegularExpressions;


namespace proyecto
{
    public class readFile
    {

        public static void Read()
        {


            List<string> txt = new List<string>();
            string filePath = @"C:\Users\Roberto Moya\Desktop\ProyectoAutomatas\proyecto\docs\GRAMATICA.txt";

            int a = 0;
            // Abre el archivo utilizando StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Lee el archivo línea por línea
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Guardar cada línea en una lista para su uso posterior
                    txt.Add(line);
                    a++;
                }
            }

           
           
            int c = 0;
            int b = 0;
            int d = 0;
            while (b <= a)
            {


                if (Convert.ToString(txt[b].Trim()) == "SETS")
                {
                    while (b != a)
                    {
                        b++;
                        if (Convert.ToString(txt[b].Trim()) == "TOKENS")
                        {
                            break;
                        }
                        if (Convert.ToString(txt[b].Trim()) != "")
                        {
                            identificador.getIdentificador(txt[b], b);
                        }
                        
                    }
                }

                if (Convert.ToString(txt[b].Trim()) == "TOKENS")
                {
                    while (b != a)
                    {
                        b++;
                        if (Convert.ToString(txt[b].Trim()) == "ACTIONS")
                        {
                            break;
                        }

                        //Expresión regular
                        string expresionRgular = "^((TOKEN( |\\t)*[0-9]([0-9])*( |\\t)*=( |\\t)*)( |\\t)*(('[ -~\\x80-\\xFF]')*|([A-Z])*|( |\\t)*|(\\+|\\*|\\{|\\}|\\(([A-Z]|( |\\t)|(\\+|\\*|\\{|\\}|\\|)*)*\\)|\\|)*)*)$";
                        string cadenaVacia = @"^$";
                        string input = Convert.ToString(txt[b].Trim());
                        Match match = Regex.Match(input, expresionRgular);


                        if (match.Success || Regex.IsMatch(input, cadenaVacia))
                        {
                            Console.WriteLine("token valido linea " + b);
                        }
                        else
                        {
                            int lineNumber = b + 1;

                            //Console.WriteLine("token invalido linea " + i);
                            Console.WriteLine("Error en la línea " + lineNumber);

                        }
                    }

                }
                else
                {
                    Console.WriteLine("Error en la línea " + (b + 1));
                }


                //Verifica que la palabra "ACTIONS" esté 
                if (Convert.ToString(txt[b].Trim()) == "ACTIONS")
                {
                    while (b != a)
                    {
                        //txt[b] = Convert.ToString(txt[b].Trim());

                        if (Convert.ToString(txt[b].Trim()) == "RESERVADAS()")//Verifica que le siga la función "RESERVADAS()"
                        {
                            //Comienzo a validar lo que esté dentro
                            while (b != a)
                            {
                                b++;
                                if (Convert.ToString(txt[b].Trim()) == "{")//Acá hay un error. Esto se sale sin la necesidad de salirse.
                                {
                                    while (b != a)
                                    {
                                        b++;
                                        txt[b] = Convert.ToString(txt[b].Trim());


                                        if (Regex.IsMatch(txt[b], "([\t]|[ ])*([0-9][0-9])([\t]|[ ])*=([\t]|[ ])*'([a-z]|[A-Z])*([\t]|[ ])*'([\t]|[ ])*$"))
                                        {
                                            Console.WriteLine("ACTION Correcto");
                                        }
                                        else if (Convert.ToString(txt[b].Trim()) == "}")
                                        {
                                            //Console.WriteLine("Ha ocurrido un error en la línea " + b);
                                            //c = 1;
                                            d = 1;
                                            break;

                                        }
                                        else if (Convert.ToString(txt[b].Trim()) == "{")
                                        {
                                            Console.WriteLine("Ha ocurrido un error en la línea " + (b + 1));
                                            c = 1;
                                            break;

                                        }
                                        else if (Convert.ToString(txt[b].Trim()) == "" || Convert.ToString(txt[b].Trim()) == " " || Convert.ToString(txt[b].Trim()) == "\n" || Convert.ToString(txt[b].Trim()) == "ACTIONS")
                                        {

                                        }
                                        else
                                        {
                                            Console.WriteLine("Se esperaba otro valor en la línea " + (b + 1));

                                        }

                                    }

                                }
                                if (d == 1)
                                {
                                    d = 0;
                                    break;
                                }
                                if (c == 1)
                                {
                                    break;
                                }


                            }
                        }
                        else if (Regex.IsMatch(txt[b], "(([\t]|[ ])*[A-Z]*([\t]|[ ])*[()])([\t]|[ ])*$"))
                        {
                            Console.WriteLine("SI entró al segundo");
                            while (b != a)
                            {
                                b++;
                                if (Convert.ToString(txt[b].Trim()) == "{")//Acá hay un error. Esto se sale sin la necesidad de salirse.
                                {
                                    while (b != a)
                                    {
                                        b++;
                                        txt[b] = Convert.ToString(txt[b].Trim());


                                        if (Regex.IsMatch(txt[b], "(([\t]|[ ])*[0-9][0-9])([\t]|[ ])*=([\t]|[ ])*'([\t]|[ ])*([a-z]|[A-Z])*([\t]|[ ])*'([\t]|[ ])*$")) 
                                        {
                                            Console.WriteLine("ACTION Correcto");
                                        }
                                        else if (Convert.ToString(txt[b].Trim()) == "}")
                                        {
                                            //Console.WriteLine("Ha ocurrido un error en la línea " + b);
                                            //c = 1;
                                            d = 1;
                                            break;

                                        }
                                        else if (Convert.ToString(txt[b].Trim()) == "{")
                                        {
                                            Console.WriteLine("Ha ocurrido un error en la línea " + (b + 1));
                                            c = 1;
                                            break;

                                        }
                                        else if (Convert.ToString(txt[b].Trim()) == "" || Convert.ToString(txt[b].Trim()) == " " || Convert.ToString(txt[b].Trim()) == "\n" || Convert.ToString(txt[b].Trim()) == "ACTIONS")
                                        {

                                        }
                                        else
                                        {
                                            Console.WriteLine("Se esperaba otro valor en la línea " + (b + 1));
                                           
                                        }

                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Se esperaba otro valor en la línea " + (b + 1));
                                }
                                if (d == 1)
                                {
                                    break;
                                }
                                if (c == 1)
                                {
                                    break;
                                }


                            }
                        }
                        else if (Convert.ToString(txt[b].Trim()) == "" || Convert.ToString(txt[b].Trim()) == " " || Convert.ToString(txt[b].Trim()) == "\n" || Convert.ToString(txt[b].Trim()) == "ACTIONS")
                        {
                            //no pasa nada
                        }
                        //************************ PARTE DE LOS ERRORES

                        else if (Regex.IsMatch(txt[b], "([\t]|[ ])*ERROR([\t]|[ ])*=([\t]|[ ])*[0-9][0-9]([\t]|[ ])*"))
                        {
                            //No pasa nada, es un error
                        }

                        //**************************
                        else
                        {
                            Console.WriteLine("Se esperaba otro valor en la línea " + (b + 1));
                        }
                        b++;

                        if (c == 1)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Se esperaba otro valor en la línea " + (b + 1));

                    break;
                }

                if (c == 1)
                {
                    break;
                }

                b++;
            }

            Console.WriteLine("El proceso terminó correctamente");
            //  b++;
        }


    }
}

