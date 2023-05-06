using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Fase_3
{
    internal class validarReservadas
    {
        public static bool validar(List<string> lista, string palabraVerificar)
        {
            bool verificacion = true;
            palabraVerificar = palabraVerificar.ToLower();
            lista = ObtenerValores(lista);
            lista = lista.Select(p => p.ToLower()).ToList();

            foreach (var item in lista)
            {
                if (lista.Contains(palabraVerificar))
                {
                    verificacion = true;
                    break;
                }
                else
                {
                    verificacion = false;
                }
            }
            return verificacion;
        }


        public static List<string> ObtenerValores(List<string> lista)
        {
            List<string> valores = new List<string>();
            foreach (string elemento in lista)
            {
                string valor = "";
                for (int i = 0; i < elemento.Length; i++)
                {
                    if (elemento[i] == '=')
                    {

                        valor = elemento.Substring(i + 1);
                        valor = valor.Trim('\'', ' ');
                        break;
                    }
                }
                valores.Add(valor);
            }
            return valores;
        }

    }


}

