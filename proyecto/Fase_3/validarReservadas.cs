using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Fase_3
{
    internal class validarReservadas
    {
        public static (bool, string) validar(List<string> lista, string palabraVerificar)
        {
            bool verificacion = true;
            palabraVerificar = palabraVerificar.ToLower();
            var resultado = ObtenerValores(lista);
            string elementoEnPosicion = "";

            List<string> atributos = resultado.atributos;
            lista = resultado.valores;
            lista = lista.Select(p => p.ToLower()).ToList();
            int contador = 0;

            foreach (var item in lista)
            {
                if (item == palabraVerificar)
                {
                    verificacion = true;
                    elementoEnPosicion = atributos[contador];
                    break;
                }
                else
                {
                    verificacion = false;
                }
                contador++;
            }
            return (verificacion, elementoEnPosicion);
        }

        



        public static (List<string> atributos, List<string> valores) ObtenerValores(List<string> lista)
        {
            List<string> atributos = new List<string>();
            List<string> valores = new List<string>();

            foreach (string elemento in lista)
            {
                string atributo = "";
                string valor = "";

                for (int i = 0; i < elemento.Length; i++)
                {
                    if (elemento[i] == '=')
                    {
                        atributo = elemento.Substring(0, i);
                        atributo = atributo.Trim();

                        valor = elemento.Substring(i + 1);
                        valor = valor.Trim('\'', ' ');
                        break;
                    }
                }

                atributos.Add(atributo);
                valores.Add(valor);
            }

            return (atributos, valores);
        }



    }


}

