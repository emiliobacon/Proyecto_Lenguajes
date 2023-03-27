using System;
using System.IO;
using System.Text.RegularExpressions;
using proyecto.REGULAR_EXPRESION;

namespace proyecto
{
    public abstract class ReadFile
    {

        public static void read()
        {

            List<string> txt = new List<string>();
            string filePath = "/Users/emilio/Desktop/proyecto/proyecto/docs/GRAMATICA.txt";

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

            int c = 0; // Variable para salir de los whiles
            int b = 0;//  Variable que recorre la lista con el while
            int d = 0;//  Variable para salir de algunos whiles
            int e = 0;//  Variable que me indicará si se encontró al menos 1 error

            while (b <= a)
            {
                if (Convert.ToString(txt[b].Trim()) == "")
                {
                    b++;
                    
                }

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
                            int lineNumber = b + 1;
                            trimToken.extractToken(input);
                            Console.WriteLine("TOKEN valido linea " + lineNumber);
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
                                            int lineNumber = b + 1;
                                            Console.WriteLine("ACTION valido linea " + lineNumber);
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
                            //Console.WriteLine("SI entró al segundo");
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
                                            int lineNumber = b + 1;
                                            Console.WriteLine("ACTION valido linea " + lineNumber);
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
                            e++;
                            //No pasa nada, es un error
                            int lineNumber = b + 1;
                            Console.WriteLine("ERROR valido linea " + lineNumber);
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

            if(e==0)
            {
                int lineNumber = b + 1;
                Console.WriteLine("Eror en la línea: " + lineNumber );
            }
            Console.WriteLine("El proceso de lectura terminó.");
        }
    }
}

