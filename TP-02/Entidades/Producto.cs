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
    public abstract class Producto
    {
        #region atributos
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #endregion

        #region enumeración
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        #endregion

        #region propiedades
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor que setea atributos de Producto
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Producto(EMarca marca, string codigo, ConsoleColor color)
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
            cadena.AppendFormat("MARCA: {0}\r\n", p.marca.ToString());
            cadena.AppendFormat("COLOR EMPAQUE: {0}\r\n", p.colorPrimarioEmpaque.ToString());
            cadena.AppendLine("-----------------------------");

            return cadena.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;
            if (!(v1 is null) && !(v2 is null) && v1.codigoDeBarras == v2.codigoDeBarras)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
