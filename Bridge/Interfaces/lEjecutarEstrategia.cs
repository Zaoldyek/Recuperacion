using Bridge.Interfaces;
using Strategy;
using System;
using Pedido = State.State;

namespace Bridge.Interfaces
{
    interface lEjecutarEstrategia
    {
        void Ejecutar(ref string[] _lstExpresion, Context _Context, DateTime _dtFechaEntrega, DateTime _dtHoy, Pedido _entPedido);
    }
}
