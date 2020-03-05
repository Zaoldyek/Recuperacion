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
    public class Expresion5Tests
    {
        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaIgualAFechaHoy_MinutosRestantes()
        {
            //Arrange
            string cResultado = "";
            Expresion5 expresion5 = new Expresion5();
            lEnvios barco = new Maritimo() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new Estafeta(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("27-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2000, fedex, barco, dtHoy);
            //Act
            cResultado = expresion5.Ejecutar(dtEntrega, dtHoy, entPedido);

            //Assert
            Assert.AreEqual("0 Minutos", cResultado);
        }

        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMayorHoraAFechaHoy_HorasRestantes()
        {
            //Arrange
            string cResultado = "";
            Expresion5 expresion5 = new Expresion5();
            lEnvios barco = new Maritimo() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new Estafeta(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("27-01-2020 13:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2000, fedex, barco, dtHoy);
            //Act
            cResultado = expresion5.Ejecutar(dtEntrega, dtHoy, entPedido);

            //Assert
            Assert.AreEqual("1 Horas", cResultado);
        }

        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMayorDiaAFechaHoy_DiasRestantes()
        {
            //Arrange
            string cResultado = "";
            Expresion5 expresion5 = new Expresion5();
            lEnvios barco = new Maritimo() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new Estafeta(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 5000, fedex, barco, dtHoy);
            //Act
            cResultado = expresion5.Ejecutar(dtEntrega, dtHoy, entPedido);

            //Assert
            Assert.AreEqual("1 Días", cResultado);
        }

        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMayorMesAFechaHoy_MesRestantes()
        {
            //Arrange
            string cResultado = "";
            Expresion5 expresion5 = new Expresion5();
            lEnvios barco = new Maritimo() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new Estafeta(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("27-02-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 150000, fedex, barco, dtHoy);
            //Act
            cResultado = expresion5.Ejecutar(dtEntrega, dtHoy, entPedido);

            //Assert
            Assert.AreEqual("1 Meses", cResultado);
        }

        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMayorSemanasAFechaHoy_SemanasFaltantes()
        {
            //Arrange
            string cResultado = "";
            Expresion5 expresion5 = new Expresion5();
            lEnvios Aereo = new Aereo() { dVelocidadEntrega = 800, dCostoEnvio = 1 };
            lEmpresas dhl = new DHL(new List<lEnvios>() { Aereo }, 10, "DHL");
            DateTime dtHoy = Convert.ToDateTime("15-02-2020 08:00:00");
            DateTime dtEntrega = Convert.ToDateTime("06-03-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "China", "Cancún", 446400, dhl, Aereo, dtHoy);
            //Act
            cResultado = expresion5.Ejecutar(dtEntrega, dtHoy, entPedido);

            //Assert
            Assert.AreEqual("3 Semanas", cResultado);
        }
    }
}