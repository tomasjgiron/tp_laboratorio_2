using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Entidades.Universidad;


namespace Entidades
{
#pragma warning disable CS0660, CS0661
    public sealed class Alumno : Universitario
    {
        #region atributos
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region enumerado
        /// <summary>
        /// Enumerado de la clase alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto de alumno
        /// </summary>
        public Alumno() : base()
        {
        }

        /// <summary>
        /// constructor de alumno que usa a la base e inicializa la claseQueToma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// constructor de alumno que usa al anterior e inicializa el estadoCuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Metodo que muestra datos de alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadenaAlumno = new StringBuilder();
            cadenaAlumno.AppendFormat(base.MostrarDatos());
            cadenaAlumno.AppendFormat($"\r\nESTADO DE CUENTA: {this.estadoCuenta}\r\n{this.ParticiparEnClase()}");

            return cadenaAlumno.ToString();
        }

        /// <summary>
        /// Metodo que sobreescribe al de Universitario
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format($"TOMA CLASE DE {this.claseQueToma.ToString()}");
        }

        /// <summary>
        /// Sobreescribe el ToString por defecto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region operadores
        /// <summary>
        /// Igualador alumno clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool retorno = false;
            if(!(a is null) && a.claseQueToma.Equals(clase) && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Distincion alumno clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }
        #endregion
    }
}
