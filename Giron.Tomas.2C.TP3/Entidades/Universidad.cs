using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Entidades
{
#pragma warning disable CS0660, CS0661
    public class Universidad
    {
        #region atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor por defecto de Universidad
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornadas = new List<Jornada>();
            profesores = new List<Profesor>();
        }
        #endregion

        #region enumerado
        /// <summary>
        /// Enumerado de la clase Universidad
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Propiedad que devuelve la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return jornadas;
            }
            set
            {
                jornadas = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve la lista de profesores
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve la jornada como indexador
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                jornadas[i] = value;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Metodo guardar de universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> fileXml = new Xml<Universidad>();
            if (fileXml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Guardando universidad", uni))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo leer de universidad
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Universidad retorno = null;
            Universidad aux = null;
            Xml<Universidad> fileXml = new Xml<Universidad>();
            if(fileXml.Leer(AppDomain.CurrentDomain.BaseDirectory + "Guardando universidad", out aux))
            {
                retorno = aux;
            }
            return retorno;
        }

        /// <summary>
        /// Metodos que devuelve los datos de universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder cadenaUniversidad = new StringBuilder();
            cadenaUniversidad.AppendFormat("JORNADA:\r\n");
            foreach (Jornada workday in uni.jornadas)
            {
                cadenaUniversidad.AppendFormat(workday.ToString());
            }
            return cadenaUniversidad.ToString();
        }

        /// <summary>
        /// Sobreescribe ToString por defecto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region operadores
        /// <summary>
        /// Igualador universidad alumno
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool retorno = false;
            if(!(u is null) && !(a is null))
            {
                foreach (Alumno student in u.alumnos)
                {
                    if(student == a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Distincion universidad alumno
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Igualador universidad profesor
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            bool retorno = false;
            if(!(u is null) && !(p is null))
            {
                foreach (Profesor teacher in u.profesores)
                {
                    if(teacher == p)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Distincion universidad profesor
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Igualador universidad enumerado
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            if(!(u is null))
            {
                foreach(Profesor teacher in u.profesores)
                {
                    if(teacher == clase)
                    {
                        retorno = teacher;
                        break;
                    }
                }
                if(retorno is null)
                {
                    throw new SinProfesorException();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Distincion universidad enumerado
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            if (!(u is null))
            {
                foreach (Profesor teacher in u.profesores)
                {
                    if (teacher != clase)
                    {
                        retorno = teacher;
                        break;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Agrega alumnos, profesores y clases a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Universidad retorno = null;
            if(!(u is null))
            {
                Profesor profe = (u == clase);
                Jornada workday = new Jornada(clase, profe);
                foreach(Alumno student in u.alumnos)
                {
                    if(student == clase)
                    {
                        workday.Alumnos.Add(student);
                    }
                }
                u.jornadas.Add(workday);
                retorno = u;
            }
            return retorno;
        }

        /// <summary>
        /// Agrega alumnos a la lista
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!(u is null) && !(a is null))
            {
                if(u != a)
                {
                    u.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return u;
        }

        /// <summary>
        /// Agrega profesores a la lista
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (!(u is null) && !(p is null))
            {
                if (u != p)
                {
                    u.profesores.Add(p);
                }
            }
            return u;
        }
        #endregion
    }
}
