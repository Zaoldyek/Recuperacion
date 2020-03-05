using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using Strategy;
using Bridge.Envios;
using Bridge.Empresas;
using State;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Bridge.Utilerias
{
    class PresentadorDatos : lPresentador
    {
        public void PresentadorInformacion(string _cLine)
        {
            
            lGuardarRegistro Save = new GuardarRegistro();
            lInicializarTrasporteEmpresas srvInitDatos = new InicializarDatos();
            lObtenerFecha lobtenerFecha = new ObtenerFecha("27/01/2020");
            string[] _lstInformacion = _cLine.Split(',');
            lPresentadorTexto presentadorTexto = new PresentadorTexto();
            lBuscarMejorOpcion buscarMejorOpcion = new BuscarMejorOpcion();
            lAsignarDatosEnvio lasignarDatosEnvio = new AsignarDatosEnvio();
            Context context = new Context();
            lConvertirTipoDato convertirTipoDato = new CovertirTipoDatoService();
            double dTiempoTraslado = 0;
            decimal TiempoTraslado = 0;
            decimal dCostoEnvio = 0;
            string cExpresion1 = "";
            string cExpresion2 = "";
            string cExpresion3 = "";
            string cExpresion4 = "";
            string cExpresion5 = "";
            DateTime dtFechaEntrega = new DateTime();
            DateTime dtHoy = lobtenerFecha.ObtenerFechaActual();
            lEmpresas empresa = null;
            lEnvios transporte = null;

            EjecutarEstrategia ejecutarEstrategia = new EjecutarEstrategia();
            List<lEmpresas> lstEmpresas = new List<lEmpresas>();
            List<lEnvios> lstTransportes = new List<lEnvios>();
            
            srvInitDatos.inicializarDatos(ref lstTransportes,ref lstEmpresas);

            lasignarDatosEnvio.AsignarEmpresa(_lstInformacion[3], ref empresa, lstEmpresas);

            lasignarDatosEnvio.AsignarTransporte(_lstInformacion[4], ref transporte, lstTransportes);

            if (empresa != null)
            {
                Pedido initialState = new DesactivarState();
                State.State entPedido = new State.State(initialState, _lstInformacion[0], _lstInformacion[1], convertirTipoDato.ConvertirStringADecimal(_lstInformacion[2]), empresa, transporte, Convert.ToDateTime(_lstInformacion[5]));
                initialState.setContext(entPedido);

                TiempoTraslado = empresa.TiempoTraslado(entPedido);

                if (TiempoTraslado > 0)
                {
                    dTiempoTraslado = convertirTipoDato.ConvertirDecimalADouble(TiempoTraslado);
                    dtFechaEntrega = empresa.FechaEntrega(dTiempoTraslado, entPedido);
                    dCostoEnvio = empresa.CostoEnvio(entPedido);

                    string[] lstExpresiones = { cExpresion1, cExpresion2, cExpresion3, cExpresion4, cExpresion5 };
                    ejecutarEstrategia.Ejecutar(ref lstExpresiones, context, dtFechaEntrega, dtHoy, entPedido);


                    if (entPedido.state.ToString() == "State.ActivarState")
                    {
                        presentadorTexto.CambiarEstiloTexto(ConsoleColor.Green);
                    }
                    else
                    {
                        presentadorTexto.CambiarEstiloTexto(ConsoleColor.Yellow);
                    }

                    string cResultado = $"Tu paquete {lstExpresiones[0]} de {entPedido.cOrigen} y {lstExpresiones[1]} a {entPedido.cDestino} {lstExpresiones[2]} {lstExpresiones[4]} y {lstExpresiones[3]} un costo de {dCostoEnvio} (Cualquier reclamación con {_lstInformacion[3]}).";
                    Console.WriteLine(cResultado);
                    Save.guardarRegistro(lstExpresiones, cResultado,empresa.cNombre);

                    presentadorTexto.CambiarEstiloTexto(ConsoleColor.Blue);
                    Console.WriteLine(buscarMejorOpcion.ObtenerMejorOpcion(lstEmpresas, empresa, entPedido, dCostoEnvio));
                }
                else
                {
                    presentadorTexto.CambiarEstiloTexto(ConsoleColor.Red);
                    Console.WriteLine($"{_lstInformacion[3]} no ofrece el servicio de transporte {entPedido.cMedioTransporte.cNombre}, te recomendamos cotizaren otra empresa.");
                }
            }
            else
            {
                presentadorTexto.CambiarEstiloTexto(ConsoleColor.Red);
                Console.WriteLine($"La Paquetería: {_lstInformacion[3]} no se encuentra registrada en nuestra red de distribución.");
            }
        }
    }
}
