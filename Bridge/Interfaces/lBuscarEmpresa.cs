using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Interfaces
{
    public interface lBuscarEmpresa
    {
        lEmpresas buscarEmpresa(JToken _Empresa, List<lEnvios> lstTransportes);
    }
}
