using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bridge.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Bridge.Interfaces;

namespace Bridge.Utilerias.Tests
{
    [TestClass()]
    public class InicializarEmpresasUTests
    {
        [TestMethod()]
        public void inicializarDatos_EnviarParametrosValidos_ListaTransporteConTresRegistros()
        {
            //Arrange
            lInicializarTrasporteEmpresas InicializarDatos = new InicializarDatos();
            List<lEnvios> lstMediosTransporte = new List<lEnvios>();
            List<lEmpresas> lstEmpresas = new List<lEmpresas>();
            //Act
            InicializarDatos.inicializarDatos(ref lstMediosTransporte, ref lstEmpresas);
            //Assert
            Assert.AreEqual(3, lstMediosTransporte.Count);
        }

        [TestMethod()]
        public void inicializarDatos_EnviarParametrosValidos_ListaEmpresasConTresRegistros()
        {
            //Arrange
            lInicializarTrasporteEmpresas InicializarDatos = new InicializarDatos();
            List<lEnvios> lstMediosTransporte = new List<lEnvios>();
            List<lEmpresas> lstEmpresas = new List<lEmpresas>();
            //Act
            InicializarDatos.inicializarDatos(ref lstMediosTransporte, ref lstEmpresas);
            //Assert
            Assert.AreEqual(3, lstEmpresas.Count);
        }

        [TestMethod()]
        public void inicializarDatos_EnviarParametrosNulos_GeneraExcepcion()
        {
            //Arrange
            lInicializarTrasporteEmpresas InicializarDatos = new InicializarDatos();
            List<lEnvios> lstMediosTransporte = null;
            List<lEmpresas> lstEmpresas = null;
            //Assert
            Assert.ThrowsException<NullReferenceException>(() => InicializarDatos.inicializarDatos(ref lstMediosTransporte, ref lstEmpresas));
        }
    }
}