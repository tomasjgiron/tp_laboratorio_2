using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region atributos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto de persona
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// constructor de persona que inicializa nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// constructor de persona que usa al segundo e inicializa el dni como dato int
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// constructor de persona que usa al segundo e inicializa el dni como dato string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region enumerado
        /// <summary>
        /// enumerado de la clase persona
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region propiedades
        /// <summary>
        /// propiedad que devuelve el dni como int
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                if(ValidarDni(this.nacionalidad, value) > 0)
                {
                    dni = value;
                }
            }
        }

        /// <summary>
        /// propiedad que devuelve el apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// propiedad que devuelve el nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// propiedad que devuelve el dni como string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// propiedad que devuelve la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Sobreescribe el ToString por defecto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder cadenaPersona = new StringBuilder();
            cadenaPersona.AppendFormat($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}\r\nNACIONALIDAD: {this.nacionalidad}\r\n\r\n");

            return cadenaPersona.ToString();
        }

        /// <summary>
        /// metodo de validacion para nombre y apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            string charValid = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz ";
            if (!(dato is null))
            {
                foreach (char chara in charValid)
                {
                    if (dato.Contains(chara))
                    {
                        retorno = dato;
                    }
                    else
                    {
                        retorno = "";
                        break;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// metodo que valida el dni como dato int
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            if(nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                retorno = dato;
            }
            else if(nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                retorno = dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }

            return retorno;
        }

        /// <summary>
        /// metodo que valida el dni como dato string
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            int retorno = 0;
            if (!(dato is null) && dato.Length <= 8 && int.TryParse(dato, out aux))
            {
                retorno = ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new DniInvalidoException();
            }
            return retorno;
        }
        #endregion
    }
}
