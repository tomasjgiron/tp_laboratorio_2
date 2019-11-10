using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test que valida que la nacionalidad sea correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidarNacionalidadException()
        {
            Universidad uni = new Universidad();
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
               EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
               Alumno.EEstadoCuenta.Deudor);
            uni += a2;
        }

        /// <summary>
        /// Test que valida que no haya alumnos repetidos, en este caso por el dni
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ValidarAlumnoRepetidoExcepcion()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
            uni += a1;
            Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
            uni += a3;
        }

        /// <summary>
        /// Test que valida algun dato de tipo numerico
        /// </summary>
        [TestMethod]
        public void ValidarDni()
        {
            int dni = 38998038;
            Alumno a3 = new Alumno(3, "José", "Gutierrez", "38998038",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);

            Assert.AreEqual(dni, a3.DNI);
        }

        /// <summary>
        /// Test que valida que no puede haber datos null cargados en las clases
        /// </summary>
        [TestMethod]
        public void SinNulosEnClase()
        {
            Alumno a3 = new Alumno(3, null, "Gutierrez", "38998038",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
            Assert.IsNull(a3.Nombre);
        }
    }
}
