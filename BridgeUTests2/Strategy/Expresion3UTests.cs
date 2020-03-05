﻿using Bridge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State;
using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Tests
{
    [TestClass()]
    public class Expresion3Tests
    {
        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMayorAHoy_TextoNoEntregado()
        {
            //Arrange
            string cResultado = "";
            Expresion3 expresion3 = new Expresion3();
            lEnvios barco = new Maritimo() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new Estafeta(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 5000, fedex, barco, dtHoy);
            //Act
            cResultado = expresion3.Ejecutar(dtEntrega, dtHoy, entPedido);
            //Assert
            Assert.AreEqual("dentro de", cResultado);
        }


        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMenorAHoy_TextoEntregado()
        {
            //Arrange
            string cResultado = "";
            Expresion3 expresion3 = new Expresion3();
            lEnvios barco = new Maritimo() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new Estafeta(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("29-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 5000, fedex, barco, Convert.ToDateTime("27-01-2020 12:00:00"));
            //Act
            cResultado = expresion3.Ejecutar(dtEntrega, dtHoy, entPedido);
            //Assert
            Assert.AreEqual("hace", cResultado);
        }
    }
}