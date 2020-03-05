using Bridge.Interfaces;
using System.Collections.Generic;

namespace Bridge
{
    public class BuscarMejorOpcion : lBuscarMejorOpcion
    {
        public string ObtenerMejorOpcion(List<lEmpresas> lstEmpresas, lEmpresas empresa, State.State entPedido,decimal dCostoEnvio)
        {
            string cMejorOpcion = "";
            for (int i = 0; i <= lstEmpresas.Count - 1; i++)
            {
                if (lstEmpresas[i] != empresa)
                {
                    if (lstEmpresas[i].lstEnvios.Contains(entPedido.cMedioTransporte))
                    {
                        State.State entPedidoAux = entPedido;
                        entPedidoAux.cPaqueteria = lstEmpresas[i];
                        decimal costo = lstEmpresas[i].CostoEnvio(entPedidoAux);
                        if(costo < dCostoEnvio)
                            cMejorOpcion= $"Si hubieras pedido en {entPedidoAux.cPaqueteria.cNombre} te hubiera costado { (dCostoEnvio - costo)} mas barato";
                    }
                }
            }
            return cMejorOpcion;
        }
    }
}
