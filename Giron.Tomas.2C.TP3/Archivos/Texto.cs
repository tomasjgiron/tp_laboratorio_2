using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Metodo guardar de la clase Texto que usa a la interface
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter file = new StreamWriter(archivo, true))
                {
                    file.WriteLine(datos);
                    retorno = true;
                }
            }
            catch (ArchivosException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retorno;
        }
        /// <summary>
        /// Metodo leer de la clase Texto que usa a la interface
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                    retorno = true;
                }
            }
            catch (ArchivosException ex)
            {
                datos = "";
                Console.WriteLine(ex.Message);
            }
            return retorno;
        }
    }
}
