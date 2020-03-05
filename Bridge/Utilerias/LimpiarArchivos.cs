using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    class LimpiarArchivos : ILimpiarArchivos
    {
        public void vaciarArchivos()
        {
            string[] lstEmpresas = { "DHL","Fedex","Estafeta"};
            string[] lstTipo = { "Entregados", "Pendientes" };
            string[] lstArchivos = { "Minutos", "Horas", "Dias", "Semanas", "Meses", "Bimestre", "Años" };
            string baseURL = Environment.CurrentDirectory;
            foreach (string a in lstEmpresas)
            {
                foreach (string tipo in lstTipo)
                {
                    foreach (string archivo in lstArchivos)
                    {
                        File.WriteAllLines(baseURL + "\\" + a + "\\" + tipo + "\\" + archivo+".txt", new string[]{ "" });
                    }
                }
            }
        }
    }
}
