using System;
using System.IO;
using System.Text.RegularExpressions;
using proyecto.REGULAR_EXPRESION;
using proyecto.Fase_3;
using proyecto.Fase_2;
using System.Windows.Input;

namespace proyecto
{
    public abstract class ReadFile
    {
        public static void Main()
        {

            string codigo = "";
            //string _filePath = "C:\\Users\\Roberto Moya\\Desktop\\Java2.txt";
            string _filePath = "C:\\Users\\Roberto Moya\\Documents\\NetBeansProjects\\JavaApplication5\\src\\javaapplication5\\JavaApplication5.java";

            codigo += "package javaapplication5;\n";
            codigo += "import java.util.Scanner;\n";
            codigo += "import java.util.ArrayList;\n";
            codigo += "public class JavaApplication5 {\n";
            codigo += "public static void main(String[] args)\n";
            codigo += "{";
            codigo += "ArrayList<String> atributos = new ArrayList<String>();\n";
            codigo += "ArrayList<String> valores = new ArrayList<String>();\n";
            codigo += "boolean verificacion = true;\n";
            codigo += "String elementoEnPosicion = \"\";\n";
            codigo += "int contador = 0;\n";
           
            codigo += "String simbolo=\"\";";

            codigo += "\nSystem.out.println(\"Ingrese la cadena: \");\n";
            codigo += "Scanner scanner = new Scanner(System.in);\n";
            codigo += "String palabraVerificar = scanner.nextLine();\n";
            codigo += "palabraVerificar = palabraVerificar.toLowerCase();\n";
            codigo += "String[] pal=palabraVerificar.split(\"\\\\s+\");\r\npalabraVerificar=pal[0];\r\nsimbolo=pal[1];\n";

            File.WriteAllText(_filePath, codigo);
           // File.AppendAllText(_filePath, codigo);
            List<string> ListaActions = new List<string>();


            // string cadena = Console.ReadLine();
            ListaActions = read();
            /*
            
           // var resultado = validarReservadas.validar(ListaActions, cadena);
            bool res = resultado.Item1;
            string res1 = resultado.Item2;
            */

            //******************




        }
        public static List<string> read()
        {



            int contadorLineas = 0;
            List<string> ListaActions = new List<string>();
            List<string> txt = new List<string>();

            //string filePath = "C:\\Users\\megan\\OneDrive\\Escritorio\\Megan\\proyectos_oficial\\C#\\Proyecto_Lenguajes\\proyecto\\docs\\GRAMATICA.txt";
            //string filePath = "/Users/emilio/Desktop/proyecto/proyecto/docs/GRAMATICA.txt";


           // string filePath = "C:\\Users\\Roberto Moya\\Desktop\\ProyectoAutomatas\\proyecto\\docs\\GRAMATICA.txt";
           // string filePath = "C:\\Users\\Roberto Moya\\Desktop\\ProyectoAutomatas\\proyecto\\docs\\prueba_2-1 (2).txt";
            string filePath = "C:\\Users\\Roberto Moya\\Desktop\\ProyectoAutomatas\\proyecto\\docs\\prueba_3-1 (2).txt";



            //  string filePath = "/Users/emilio/Desktop/Proyecto LFYA/proyecto/docs/GRAMATICA.txt";

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
                        if (Convert.ToString(txt[b].Trim()) == "TOKENS")//Validar "TOKEN"
                        {
                            break;
                        }
                        else if (Convert.ToString(txt[b].Trim()) == "TOKEN")
                        {
                            Console.WriteLine("ERROR");
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
                        if (Convert.ToString(txt[b].Trim()) == "")
                        {

                            continue;
                        }

                        //Expresión regular
                        string expresionRgular = "^((TOKEN( |\\t)*[0-9]([0-9])*( |\\t)*=( |\\t)*)( |\\t)*(('[ -~\\x80-\\xFF]')*|([A-Z])*|( |\\t)*|(\\+|\\*|\\{|\\}|\\(([A-Z]|( |\\t)|(\\+|\\*|\\{|\\}|\\|)*)*\\)|\\|)*)*)$";
                        string cadenaVacia = @"^$";
                        string input = Convert.ToString(txt[b].Trim());
                        Match match = Regex.Match(input, expresionRgular);


                        if (match.Success || Regex.IsMatch(input, cadenaVacia))
                        {
                            int lineNumber = b + 1;

                            //manda cada token (el contador lineas solo me sirve para encontrar la primera linea)
                            trimToken.extractToken(input, contadorLineas, true);

                            //EXTRAE EL TOKEN

                            Console.WriteLine("TOKEN valido linea " + lineNumber);
                            contadorLineas++;
                        }
                        else
                        {
                            int lineNumber = b + 1;

                            //Console.WriteLine("token invalido linea " + i);
                            Console.WriteLine("Error en la línea " + lineNumber);

                        }
                    }
                    //uso el remove para quitar el ultimo | de la lista
                    trimToken.RemoveText();
                    //aca es false para que no me agregue el ultimo | ya habiendo agregado el ).#
                    trimToken.extractToken(") #", contadorLineas, false);
                    GenerateString.sendToTree();
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
                                            
                                            ListaActions.Add(txt[b].Trim());

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

            if (e == 0)
            {
                int lineNumber = b + 1;
                Console.WriteLine("Eror en la línea: " + lineNumber);
            }
            Console.WriteLine("El proceso de lectura terminó.");
            pasarJava(ListaActions);
            return ListaActions;
        }

        public static void pasarJava(List<string> lista)
        {
            string codigo = "";
            var resultado = validarReservadas.ObtenerValores(lista);
            List<string> atributos = resultado.atributos;
            List<string> valores = resultado.valores;

            

            
           


            foreach (var item in atributos)
            {
                codigo += "atributos.add(" + "\"" + item + "\"" + ");\n";
            }
            foreach (var item in valores)
            {
                codigo += "valores.add(" + "\"" + item + "\"" + ");\n";
            }
          

            // for
            codigo += "for (String item : valores) {\r\n        if (item.equals(palabraVerificar)) {\r\n   " +
                " verificacion = true;\r\n            elementoEnPosicion = atributos.get(contador);\r\n\t\tSystem.out.println(item + \" = \" + elementoEnPosicion);\r\n  System.out.println(\"Cadena valida.\");  " +
                "        break;\r\n        } else {\r\n            verificacion = false;\r\n   }\r\n        contador++;\r\n    }";
            codigo += "if(verificacion == false)\r\n        {\r\n             System.out.println(\"Cadena no valida.\");\r\n        }";
            codigo += "\n}";
            codigo += "}";

            Console.WriteLine(codigo);
        
            string _filePath = "C:\\Users\\Roberto Moya\\Documents\\NetBeansProjects\\JavaApplication5\\src\\javaapplication5\\JavaApplication5.java";
   
            File.AppendAllText(_filePath, codigo);
            


        }
    }
}



