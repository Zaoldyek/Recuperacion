using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Interfaces
{
    public interface lInicializarTrasporteEmpresas
    {
        void inicializarDatos(ref List<lEnvios> _lstMediosTransporte,ref List<lEmpresas> _lstEmpresas);
    }
}
