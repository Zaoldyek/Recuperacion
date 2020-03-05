using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Interfaces
{
    public interface lBuscarTransporte
    {

        lEnvios buscarTransporte(JToken _TransporteSolicitado);
    }
}
