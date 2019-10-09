using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region atributos
        private ETipo tipo = ETipo.Entera;
        #endregion

        #region enumeración
        public enum ETipo
        {
            Entera, Descremada
        }
        #endregion enumeración

        #region constructores
        /// <summary>
        /// Constructor de Leche setea atributos de clase base y el tipo (por defecto entera)
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(marca, codigo, color)
        {
        }

        /// <summary>
        /// Constructor de Leche que setea atributos de clase base y tipo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) 
            : this(marca,codigo,color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region métodos
        /// <summary>
        /// Publica todos los datos de Leche y Producto
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder cadenaLeche = new StringBuilder();

            cadenaLeche.AppendLine("LECHE");
            cadenaLeche.AppendLine(base.Mostrar());
            cadenaLeche.AppendFormat("CALORIAS: {0}\r\n", this.CantidadCalorias);
            cadenaLeche.AppendFormat("TIPO: {0}\r\n", this.tipo);
            cadenaLeche.AppendLine("");
            cadenaLeche.AppendLine("---------------------");

            return cadenaLeche.ToString();
        }
        #endregion
    }
}
