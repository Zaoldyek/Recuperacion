using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Interfaces
{
    interface lObtenerFecha
    {
        DateTime dtHoy { get; set; }
        DateTime ObtenerFechaActual();
    }
}
