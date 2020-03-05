using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain
{
    public class Semanas : BaseHandler
    {
        public Semanas() { }

        public override string handle(string cCadena)
        {
            string cArchivo = "";
            if (cCadena.Contains("Semanas"))
            {
                cArchivo = "Semanas.txt";
            }
            else
            {
                cArchivo = base.next.handle(cCadena);
            }
            return cArchivo;
        }
    }
}
