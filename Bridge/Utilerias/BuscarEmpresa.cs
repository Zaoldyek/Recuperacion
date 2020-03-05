
using Bridge.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    public class InicializarEmpresas : lBuscarEmpresa
    {
        public lEmpresas buscarEmpresa(JToken _Empresa, List<lEnvios> _lstTransportes)
        {
            lEmpresas Empresa = null;
            string cNombre = (string)_Empresa["Paqueteria"];
            decimal dMargen = (decimal)_Empresa["MargenUtilidad"];
            List<JToken> Transportes = _Empresa["Medios"].ToList();
            List<lEnvios> lstTransporte = new List<lEnvios>();

            foreach (var tra in Transportes)
            {
                string cMedio = RemoveDiacritics((string)tra["Medio"]);
                lstTransporte.Add(_lstTransportes.Where(s=>s.cNombre == cMedio).FirstOrDefault());
            }

            if (cNombre == "DHL")
            {
                Empresa = new DHL( lstTransporte, dMargen, cNombre = "DHL" );
            }
            else if (cNombre == "Fedex")
            {
                Empresa = new FEDEXService(lstTransporte, dMargen, cNombre = "Fedex" );
            }
            else
            {
                Empresa = new Estafeta(lstTransporte, dMargen, cNombre = "Estafeta" );
            }

            return Empresa;
        }

        private static String RemoveDiacritics(string s)
        {
            string normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
}
