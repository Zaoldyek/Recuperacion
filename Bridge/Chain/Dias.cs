using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain
{
    public class Dias : BaseHandler
    {
        public Dias() { }

        public override string handle(string cCadena)
        {
            string cArchivo = "";
            if (cCadena.Contains("Días"))
            {
                cArchivo = "Dias.txt";
            }
            else
            {
                cArchivo = base.next.handle(cCadena);
            }
            return cArchivo;
        }
    }
}
