using Bridge.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    public class BuscarTransporte : lBuscarTransporte
    {
        public lEnvios buscarTransporte(JToken _TransporteSolicitado)
        {
            lEnvios Transporte=null;
            string cMedio = (string)_TransporteSolicitado["Medio"];
            int cVelocidad = (int)_TransporteSolicitado["Velocidad"];
            int cCostoPorKilometro = (int)_TransporteSolicitado["CostoPorKilometro"];

            if (cMedio == "Marítimo")
            {
                Transporte = new Maritimo() { cNombre= "Maritimo" };
            }
            else if (cMedio == "Terrestre")
            {
                Transporte = new Terrestre() { cNombre = "Terrestre" };
            }
            else
            {
                Transporte = new Aereo() { cNombre = "Aereo" };
            }

            Transporte.dCostoEnvio = cCostoPorKilometro;
            Transporte.dVelocidadEntrega = cVelocidad;


            return Transporte;
        }
    }
}
