using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EntidadesAbstractas;
using static Entidades.Universidad;

namespace Entidades
{
#pragma warning disable CS0660, CS0661
    public sealed class Profesor : Universitario
    {
        #region atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto de profesor
        /// </summary>
        public Profesor() : base()
        {
        }

        /// <summary>
        /// Constructor estatico de profesor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de profesor que usa al de la base, iniciliza la queue y le asigna dos clases random
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            _randomClases();
            _randomClases();
        }
        #endregion

        #region metodos
        /// <summary>
        /// Metodo random para asignar clases
        /// </summary>
        private void _randomClases()
        {     
            int aux = random.Next(0, 4);//el segundo parametro es exclusivo => va de 0 a 3
            Thread.Sleep(400);//te da la posibilidad que no siempre sea la misma clase
            this.clasesDelDia.Enqueue((EClases)aux);
        }

        /// <summary>
        /// Metodo que muestra los datos de profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadenaProfesor = new StringBuilder();
            cadenaProfesor.AppendFormat(base.MostrarDatos());
            cadenaProfesor.AppendFormat(this.ParticiparEnClase());

            return cadenaProfesor.ToString();
        }

        /// <summary>
        /// Metodo que sobreescribe el de la base
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder cadenaClase = new StringBuilder();
            cadenaClase.AppendFormat($"CLASES DEL DÍA: ");
            foreach (EClases clase in this.clasesDelDia)
            {
                cadenaClase.AppendFormat($"\r\n{clase}");
            }
            return cadenaClase.ToString();
        }

        /// <summary>
        /// Sobreescribe ToString por defecto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region operadores
        /// <summary>
        /// Igualador profesor enumerado
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;
            if(!(i is null) && i.clasesDelDia.Contains(clase))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Distincion profesor enumerado
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
