using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<V> : IArchivo<V>
    {
        /// <summary>
        /// Metodo guardad de la clase XML que usa a la interface
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, V datos)
        {
            bool retorno = false;
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(V));
                serializer.Serialize(writer, datos);
                retorno = true;
            }
            catch (ArchivosException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                {
                    writer.Close();
                }
            }
            return retorno;
        }
        /// <summary>
        /// Metodo leer de la clase XML que usa a la interface
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out V datos)
        {
            bool retorno = false;
            XmlTextReader writer = null;
            try
            {
                writer = new XmlTextReader(archivo);
                XmlSerializer serializer = new XmlSerializer(typeof(V));
                datos = (V)serializer.Deserialize(writer);
                retorno = true;
            }
            catch (ArchivosException ex)
            {
                datos = default(V);//preguntar
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }
            return retorno;
        }
    }
}