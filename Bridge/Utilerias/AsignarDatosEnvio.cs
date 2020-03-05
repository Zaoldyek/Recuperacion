using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    public class AsignarDatosEnvio : lAsignarDatosEnvio
    {
        public void AsignarEmpresa(string _cEmpresaSolicitada, ref lEmpresas _Empresa, List<lEmpresas> _lstEmpresas)
        {
            lEmpresas Empresa= _lstEmpresas.Where(s => s.cNombre == _cEmpresaSolicitada).FirstOrDefault();
            if (Empresa != null)
                _Empresa = Empresa;
            else
            {
                _Empresa = null;
            }
        }

        public void AsignarTransporte(string _cTransporteSolicitada, ref lEnvios _Transporte, List<lEnvios> _lstTransportes)
        {
            _cTransporteSolicitada = RemoveDiacritics(_cTransporteSolicitada);
            _Transporte = _lstTransportes.Where(s => s.cNombre == _cTransporteSolicitada).FirstOrDefault();
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
