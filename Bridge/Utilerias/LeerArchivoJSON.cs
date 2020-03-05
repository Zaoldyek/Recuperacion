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
    public class LeerArchivoJSON : lLeerArchivoTexto
    {
        public Func<string, string[]> lectorArchivo { get; set; }

        public LeerArchivoJSON()
        {
            lectorArchivo = e => File.ReadAllLines(e);
        }

        public List<string> LeerArchivo(string _cUrl)
        {
            List<string> lstResultado = new List<string>();
            string fileName = "Pedidos.json";
            string path = Environment.CurrentDirectory + "\\" + fileName;
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                JArray jsonPreservar = JArray.Parse(json);
                foreach (JObject jsonOperaciones in jsonPreservar.Children<JObject>())
                {

                    lstResultado.Add((string)jsonOperaciones["Procedencia"]+","+ (string)jsonOperaciones["Destino"] + "," + (string)jsonOperaciones["Dist_KM"] + "," + (string)jsonOperaciones["Empresa"] + "," + (string)jsonOperaciones["MedioTrans"] + "," + (string)jsonOperaciones["FechaPedido"]);

                }
            }
            return lstResultado;
        }
    }
}
