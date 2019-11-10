using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Universidad;
using Archivos;

namespace Entidades
{
#pragma warning disable CS0660, CS0661
    public class Jornada
    {
        #region atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto de jornada
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de jornada que inicializa la clase y el instructor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Propiedad que devuelve la lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve la clase
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                clase = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve el instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                instructor = value;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Guardar de jornada usa texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto txt = new Texto();
            if(txt.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Guardando jornada", jornada.ToString()))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Leer de jornada usa texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string retorno = "";
            Texto txt = new Texto();
            string aux = "";
            if (txt.Leer(AppDomain.CurrentDomain.BaseDirectory + "Guardando jornada", out aux)) ;
            {
                retorno = aux;
            }
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder cadenaJornada = new StringBuilder();
            cadenaJornada.AppendFormat($"CLASE DE {this.clase.ToString()} POR {this.Instructor.ToString()}");
            cadenaJornada.AppendFormat("\r\n\r\nALUMNOS:\r\n");
            foreach (Alumno student in this.alumnos)
            {
                cadenaJornada.AppendFormat($"{student.ToString()}\r\n");
            }
            cadenaJornada.AppendFormat("<------------------------------------------------>\r\n\r\n");
            return cadenaJornada.ToString();
        }
        #endregion

        #region operadores
        /// <summary>
        /// igualador jornada alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            if(!(j is null && a is null))
            foreach (Alumno student in j.Alumnos)
            {
                if(a == j.Clase)
                    {
                        retorno = true;
                    }
            }
            return retorno;
        }

        /// <summary>
        /// distincion jornada alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// suma alumnos a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            Jornada retorno = null;
            if (!(j is null && a is null))
            {
                if (j != a)
                {
                    j.alumnos.Add(a);
                    retorno = j;
                }
            }
            return retorno;
        }
        #endregion   
    }
}
