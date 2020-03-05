using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bridge.Chain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain.Tests
{
    [TestClass()]
    public class AñosUTests
    {
        [TestMethod]
        public void handle_EnviarCadenaConPalabraAños_RecibeNombreDelArchivoAños()
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
            cArchivo = Años.handle("Años");

            //Assert
            Assert.AreEqual("Años.txt", cArchivo);
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
            Assert.ThrowsException<NullReferenceException>(() => Años.handle(null));
        }
    }
}