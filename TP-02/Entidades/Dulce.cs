using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region propiedades
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor de Dulce que setea atributos de clase base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color)
            : base(marca,codigo,color)
        {
        }
        #endregion

        #region métodos
        /// <summary>
        /// Publica todos los datos de Dulce y Producto
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder cadenaDulce = new StringBuilder();
            cadenaDulce.AppendLine("DULCE");
            cadenaDulce.AppendLine(base.Mostrar());
            cadenaDulce.AppendFormat("CALORIAS: {0}\r\n", this.CantidadCalorias);
            cadenaDulce.AppendLine("");
            cadenaDulce.AppendLine("---------------------");

            return cadenaDulce.ToString();
        }
        #endregion
    }
}
