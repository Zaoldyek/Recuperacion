using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bridge.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Bridge.Interfaces;
using System.IO;

namespace Bridge.Utilerias.Tests
{
    [TestClass()]
    public class BuscarTransporteUTests
    {
        [TestMethod()]
        public void buscarTransporte_EnviarParametroValido_ListaTransporteConDatos()
        {
            //Arrange
            List<lEnvios> lstTransporte = new List<lEnvios>();
            lBuscarTransporte buscarTransport = new BuscarTransporte();
            lBuscarEmpresa buscarEmpresa = new InicializarEmpresas();
            string fileName = "config.json";
            string path = Environment.CurrentDirectory + "\\" + fileName;

            //Act
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var obj = JArray.Parse(json);
                List<JToken> Transportes = obj[0]["MediosTransporte"].ToList();
                foreach (var line in Transportes)
                {
                    lstTransporte.Add(buscarTransport.buscarTransporte(line));
                }
            }
            //Assert
            Assert.IsTrue(lstTransporte.Any());
        }

        [TestMethod()]
        public void buscarTransporte_EnviarParametroValido_ListaTransporteConTresDatos()
        {
            //Arrange
            List<lEnvios> lstTransporte = new List<lEnvios>();
            lBuscarTransporte buscarTransport = new BuscarTransporte();
            lBuscarEmpresa buscarEmpresa = new InicializarEmpresas();
            string fileName = "config.json";
            string path = Environment.CurrentDirectory + "\\" + fileName;

            //Act
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var obj = JArray.Parse(json);
                List<JToken> Transportes = obj[0]["MediosTransporte"].ToList();
                foreach (var line in Transportes)
                {
                    lstTransporte.Add(buscarTransport.buscarTransporte(line));
                }
            }
            //Assert
            Assert.AreEqual(3,lstTransporte.Count);
        }

        [TestMethod()]
        public void buscarTransporte_EnviarParametroInvalido_GeneraExcepcion()
        {
            //Arrange
            List<lEnvios> lstTransporte = new List<lEnvios>();
            lBuscarTransporte buscarTransport = new BuscarTransporte();
            lBuscarEmpresa buscarEmpresa = new InicializarEmpresas();
            string fileName = "config.json";
            string path = Environment.CurrentDirectory + "\\" + fileName;

            //Assert
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var obj = JArray.Parse(json);
                List<JToken> Transportes = obj[0]["MediosTransporte"].ToList();
                foreach (var line in Transportes)
                {
                    Assert.ThrowsException<NullReferenceException>(() => buscarTransport.buscarTransporte(null));
                }
            }
        }
    }
}