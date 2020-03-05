using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain
{
    public class Años : BaseHandler
    {
        public Años() { }

        public override string handle(string cCadena)
        {
            string cArchivo = "";
            if (cCadena.Contains("Años"))
            {
                cArchivo = "Años.txt";
            }
            else
            {
                cArchivo = base.next.handle(cCadena);
            }
            return cArchivo;
        }
    }
}
