using System;
using System.Collections.Generic;
using Bridge.Interfaces;
using Bridge.Utilerias;
using State;

namespace Bridge
{
    public class Estafeta : lEmpresas
    {
        public List<lEnvios> lstEnvios { get; set; }

        public decimal MargenUtilidad { get; set; }

        public string cNombre { get; set; }

        public Estafeta(List<lEnvios> _lstEnvio, Decimal _dMargenUtilidad, string _cNombre)
        {
            lstEnvios = new List<lEnvios>();
            lstEnvios.AddRange(_lstEnvio);
            MargenUtilidad = _dMargenUtilidad;
            cNombre = _cNombre;
        }

        public decimal TiempoTraslado(State.State _entPedido)
        {
            lPresentadorTexto presentadorTexto = new PresentadorTexto();
            decimal TiempoTraslado = 0;
            if (lstEnvios.Contains(_entPedido.cMedioTransporte))
            {
                TiempoTraslado = _entPedido.dDistancia / _entPedido.cMedioTransporte.dVelocidadEntrega;

            }
            return TiempoTraslado;
        }

        public DateTime FechaEntrega(double _TiempoTraslado, State.State _entPedido)
        {
            DateTime FechaEntrega = _entPedido.dtFechaHora.AddHours(_TiempoTraslado);
            return FechaEntrega;
        }

        public decimal CostoEnvio(State.State _entPedido)
        {
            decimal dCosto = (_entPedido.cMedioTransporte.dCostoEnvio * _entPedido.dDistancia) * (1 + _entPedido.cPaqueteria.MargenUtilidad / 100);

            return dCosto;
        }

    }
}
