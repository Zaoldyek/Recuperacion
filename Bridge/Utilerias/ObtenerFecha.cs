using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    class ObtenerFecha : lObtenerFecha
    {
        public DateTime dtHoy { get; set; }

        public ObtenerFecha(string cFecha) {
            dtHoy = Convert.ToDateTime(cFecha);

        }

        public DateTime ObtenerFechaActual()
        {
            return dtHoy;
        }
    }
}
