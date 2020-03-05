using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bridge.Chain;

namespace BridgeUTests2.Chain
{
    [TestClass]
    public class MinutosUTest
    {
        [TestMethod]
        public void handle_EnviarCadenaConPalabraMinutos_RecibeNombreDelArchivoMinutos()
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
            cArchivo = Minutos.handle("Minutos");

            //Assert
            Assert.AreEqual("Minutos.txt", cArchivo);
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
            Assert.ThrowsException<NullReferenceException>(() => Minutos.handle(null));
        }
    }
}
