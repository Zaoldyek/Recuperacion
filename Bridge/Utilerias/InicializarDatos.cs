using Bridge.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    public class InicializarDatos : lInicializarTrasporteEmpresas
    {
        public void inicializarDatos(ref List<lEnvios> _lstMediosTransporte, ref List<lEmpresas> _lstEmpresas)
        {
            lBuscarTransporte buscarTransport = new BuscarTransporte();
            lBuscarEmpresa buscarEmpresa = new InicializarEmpresas();
            string fileName = "config.json";
            string path = Environment.CurrentDirectory + "\\" + fileName;
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var obj = JArray.Parse(json);
                List<JToken> Transportes = obj[0]["MediosTransporte"].ToList();
                foreach (var line in Transportes)
                {
                    _lstMediosTransporte.Add(buscarTransport.buscarTransporte(line));
                }

                List<JToken> Empresas = obj[1]["Paqueterias"].ToList();
                foreach (var line in Empresas)
                {
                    _lstEmpresas.Add(buscarEmpresa.buscarEmpresa(line, _lstMediosTransporte));
                }

            }
        }
    }
}
