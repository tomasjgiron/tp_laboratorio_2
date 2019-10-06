using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
#pragma warning disable CS0660, CS0661
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto//decía sealed
    {
        #region atributos
        private EMarca marca;//agregue private
        private string codigoDeBarras;//agregue private
        private ConsoleColor colorPrimarioEmpaque;//agregue private
        #endregion

        #region enumeración
        public enum EMarca//agregue public
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        #endregion

        #region propiedades
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias { get; }//agregue protected
        #endregion

        #region constructores
        /// <summary>
        /// Constructor que setea atributos de Producto
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Producto(EMarca marca, string codigo, ConsoleColor color) //constructor creado
        {
            this.marca = marca;
            this.codigoDeBarras = codigo;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region métodos
        /// <summary>
        /// Publica todos los datos del Producto
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
            /*
                return this;
            */
        }
        #endregion

        #region operadores
        /// <summary>
        /// Sobrecarga el casteo explicito de string
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Producto p)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            cadena.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            cadena.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            cadena.AppendLine("-----------------------------");

            return cadena.ToString();
            /*
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendLine("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb;*/

        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);//no estaba reutilizado el codigo de arriba
        }
        #endregion
    }
}
