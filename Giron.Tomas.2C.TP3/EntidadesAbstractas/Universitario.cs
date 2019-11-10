using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
#pragma warning disable CS0659, CS0661
    public abstract class Universitario : Persona
    {
        #region atributos
        private int legajo;
        #endregion

        #region constructores
        /// <summary>
        /// constructor por defecto de universitario que usa a la base
        /// </summary>
        public Universitario() : base()
        {
        }

        /// <summary>
        /// constructor de universitario que usa a la base e inicializa el legajo
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Sobreescribe el Equals por defecto
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (!(obj is null))
            {
                if (this.GetType() == obj.GetType())//obj is Universitario
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que muestra los datos de universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder cadenaUniversitario = new StringBuilder();
            cadenaUniversitario.AppendFormat($"{base.ToString()}LEGAJO NÚMERO: {this.legajo}\r\n");

            return cadenaUniversitario.ToString();
        }

        /// <summary>
        /// metodo abstracto de universitario
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region operadores
        /// <summary>
        /// igualador entre dos universitarios
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (!(pg1 is null && pg2 is null))
            {
                if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// distincion entre dos universitarios
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)// => !(pg1 == pg2);
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
