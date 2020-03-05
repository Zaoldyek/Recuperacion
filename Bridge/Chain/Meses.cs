using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain
{
    public class Meses : BaseHandler
    {
        public Meses() { }

        public override string handle(string cCadena)
        {
            string cArchivo = "";
            if (cCadena.Contains("Meses"))
            {
                cArchivo = "Meses.txt";
            }
            else
            {
                cArchivo = base.next.handle(cCadena);
            }
            return cArchivo;
        }
    }
}
