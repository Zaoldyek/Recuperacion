using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bridge.Chain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Bridge.Chain.Tests
{
    [TestClass()]
    public class DiasUTests
    {
        [TestMethod]
        public void handle_EnviarCadenaConPalabraDias_RecibeNombreDelArchivoDias()
        {
            //Arrange
            string cArchivo = "";
            Minutos Minutos = new Minutos();
            Horas Horas = new Horas();
            Dias Dias = new Dias();
            Semanas Semanas = new Semanas();
            Meses Meses = new Meses();
            Bimestre Bimestre = new Bimestre();
            Años Años = new Años();
            Minutos.setNext(Horas);
            Horas.setNext(Dias);
            Dias.setNext(Semanas);
            Semanas.setNext(Meses);
            Meses.setNext(Bimestre);
            Bimestre.setNext(Años);
            //Act
            cArchivo = Dias.handle("Días");

            //Assert
            Assert.AreEqual("Dias.txt", cArchivo);
        }

        [TestMethod]
        public void handle_EnviarCadenaNula_GeneraExcepcion()
        {
            //Arrange
            Minutos Minutos = new Minutos();
            Horas Horas = new Horas();
            Dias Dias = new Dias();
            Semanas Semanas = new Semanas();
            Meses Meses = new Meses();
            Bimestre Bimestre = new Bimestre();
            Años Años = new Años();
            Minutos.setNext(Horas);
            Horas.setNext(Dias);
            Dias.setNext(Semanas);
            Semanas.setNext(Meses);
            Meses.setNext(Bimestre);
            Bimestre.setNext(Años);
            //Assert
            Assert.ThrowsException<NullReferenceException>(() => Dias.handle(null));
        }
    }
}