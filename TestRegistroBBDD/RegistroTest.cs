using ConcurrenteBaseDatos.BaseDeDatos.Registro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;
using System.Collections.Generic;

namespace TestRegistroBBDD
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para RegistroTest y se pretende que
    ///contenga todas las pruebas unitarias RegistroTest.
    ///</summary>
    [TestClass()]
    public class RegistroTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de Constructor Registro
        ///</summary>
        [TestMethod()]
        public void RegistroConstructorTest()
        {
            Registro target = new Registro();
            Assert.Inconclusive("TODO: Implementar código para comprobar el destino");
        }

        /// <summary>
        ///Una prueba de agregarCheckpoint
        ///</summary>
        [TestMethod()]
        public void agregarCheckpointTest()
        {
            Registro target = new Registro(); // TODO: Inicializar en un valor adecuado
            target.agregarCheckpoint();
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de alcanzoCheckpoint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ConcurrenteBaseDatos.exe")]
        public void alcanzoCheckpointTest()
        {
            Registro_Accessor target = new Registro_Accessor(); // TODO: Inicializar en un valor adecuado
            target.alcanzoCheckpoint();
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de bajarAdisco
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ConcurrenteBaseDatos.exe")]
        public void bajarAdiscoTest()
        {
            Registro_Accessor target = new Registro_Accessor(); // TODO: Inicializar en un valor adecuado
            target.bajarAdisco();
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de commit
        ///</summary>
        [TestMethod()]
        public void commitTest()
        {
            Registro target = new Registro(); // TODO: Inicializar en un valor adecuado
            Transaccion transaccion = null; // TODO: Inicializar en un valor adecuado
            target.commit(transaccion);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de escribirEnRegistro
        ///</summary>
        [TestMethod()]
        public void escribirEnRegistroTest()
        {
            Registro target = new Registro(); // TODO: Inicializar en un valor adecuado
            Transaccion transaccion = null; // TODO: Inicializar en un valor adecuado
            Tabla tabla = null; // TODO: Inicializar en un valor adecuado
            Tupla dato = null; // TODO: Inicializar en un valor adecuado
            target.escribirEnRegistro(transaccion, tabla, dato);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de getNombreArchivoAlevantar
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ConcurrenteBaseDatos.exe")]
        public void getNombreArchivoAlevantarTest()
        {
            Registro_Accessor target = new Registro_Accessor(); // TODO: Inicializar en un valor adecuado
            string expected = string.Empty; // TODO: Inicializar en un valor adecuado
            string actual;
            actual = target.getNombreArchivoAlevantar();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de guardarTransaccion
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ConcurrenteBaseDatos.exe")]
        public void guardarTransaccionTest()
        {
            Registro_Accessor target = new Registro_Accessor(); // TODO: Inicializar en un valor adecuado
            Transaccion transaccion = null; // TODO: Inicializar en un valor adecuado
            target.guardarTransaccion(transaccion);
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de levantarDesdeDisco
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ConcurrenteBaseDatos.exe")]
        public void levantarDesdeDiscoTest()
        {
            Registro_Accessor target = new Registro_Accessor(); // TODO: Inicializar en un valor adecuado
            target.levantarDesdeDisco();
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de limpiarRegistro
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ConcurrenteBaseDatos.exe")]
        public void limpiarRegistroTest()
        {
            Registro_Accessor target = new Registro_Accessor(); // TODO: Inicializar en un valor adecuado
            target.limpiarRegistro();
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de restaurarDesdeRegistro
        ///</summary>
        [TestMethod()]
        public void restaurarDesdeRegistroTest()
        {
            Registro target = new Registro(); // TODO: Inicializar en un valor adecuado
            target.restaurarDesdeRegistro();
            Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        }

        /// <summary>
        ///Una prueba de TransaccionesCommiteadas
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ConcurrenteBaseDatos.exe")]
        public void TransaccionesCommiteadasTest()
        {
            Registro_Accessor target = new Registro_Accessor(); // TODO: Inicializar en un valor adecuado
            List<long> actual;
            actual = target.TransaccionesCommiteadas;
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }
    }
}
