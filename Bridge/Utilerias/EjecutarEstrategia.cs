using Bridge.Interfaces;
using Strategy;
using System;
using Pedido = State.State;

namespace Bridge.Utilerias
{
    class EjecutarEstrategia : lEjecutarEstrategia
    {
        public void Ejecutar(ref string[] _lstExpresion, Context _Context,DateTime _dtFechaEntrega, DateTime _dtHoy, Pedido _entPedido)
        {
            Expresion1 expresion1 = new Expresion1();
            _Context.setStrategy(expresion1);
            _lstExpresion[0] = _Context.ValidarFechaEntrega(_dtFechaEntrega, _dtHoy, _entPedido);

            Expresion2 expresion2 = new Expresion2();
            _Context.setStrategy(expresion2);
            _lstExpresion[1] = _Context.ValidarFechaEntrega(_dtFechaEntrega, _dtHoy, _entPedido);

            Expresion3 expresion3 = new Expresion3();
            _Context.setStrategy(expresion3);
            _lstExpresion[2] = _Context.ValidarFechaEntrega(_dtFechaEntrega, _dtHoy, _entPedido);

            Expresion4 expresion4 = new Expresion4();
            _Context.setStrategy(expresion4);
            _lstExpresion[3] = _Context.ValidarFechaEntrega(_dtFechaEntrega, _dtHoy, _entPedido);

            Expresion5 expresion5 = new Expresion5();
            _Context.setStrategy(expresion5);
            _lstExpresion[4] = _Context.ValidarFechaEntrega(_dtFechaEntrega, _dtHoy, _entPedido);
        }
    }
}
