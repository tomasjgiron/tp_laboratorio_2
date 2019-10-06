using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region propiedades
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor de Snacks que setea atributos de clase base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(marca,codigo,color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        #endregion

        #region métodos
        /// <summary>
        /// Publica todos los datos de Snacks y Producto
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder cadenaSnack = new StringBuilder();

            cadenaSnack.AppendLine("SNACKS");
            cadenaSnack.AppendLine(base.Mostrar());
            cadenaSnack.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            cadenaSnack.AppendLine("");
            cadenaSnack.AppendLine("---------------------");

            return cadenaSnack.ToString();
        }
        #endregion
    }
}
