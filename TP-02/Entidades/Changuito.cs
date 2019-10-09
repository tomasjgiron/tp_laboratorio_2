using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region atributos
        List<Producto> productos;
        int espacioDisponible;
        #endregion

        #region enumeración
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor de Changuito que inicializa la lista de productos
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Constructor de Changuito que setea espacioDisponible
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Changuito(int espacioDisponible) 
            : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region sobrecargas
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        { 
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region métodos
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder cadenaChanguito = new StringBuilder();

            cadenaChanguito.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            cadenaChanguito.AppendLine("");
            foreach (Producto prod in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        {
                            if (prod is Snacks)
                            {
                                cadenaChanguito.AppendLine(prod.Mostrar());
                            }
                            break;
                        }
                    case ETipo.Dulce:
                        {
                            if (prod is Dulce)
                            {
                                cadenaChanguito.AppendLine(prod.Mostrar());
                            }
                            break;
                        }
                    case ETipo.Leche:
                        {
                            if (prod is Leche)
                            {
                                cadenaChanguito.AppendLine(prod.Mostrar());
                            }
                            break;
                        }
                    default:
                        {
                            cadenaChanguito.AppendLine(prod.Mostrar());
                            break;
                        }
                }
            }

            return cadenaChanguito.ToString();
        }
        #endregion

        #region operadores
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (!(c is null) && !(p is null))
            {
                if (c.espacioDisponible > c.productos.Count)
                {
                    foreach(Producto prod in c.productos)
                    {
                        if(prod == p)
                        {
                            return c;
                        }
                    }
                    c.productos.Add(p);
                }
            }
            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            if (!(c is null) && !(p is null))
            {
                foreach(Producto prod in c.productos)
                {
                    if(prod == p)
                    {
                        c.productos.Remove(p);
                        break;
                    }
                }
            }
            return c;
        }
        #endregion
    }
}
