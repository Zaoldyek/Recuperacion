using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain
{
    public class Bimestre : BaseHandler
    {
        public Bimestre() { }

        public override string handle(string cCadena)
        {
            string cArchivo = "";
            if (cCadena.Contains("Bimestre"))
            {
                cArchivo = "Bimestre.txt";
            }
            else
            {
                cArchivo = base.next.handle(cCadena);
            }
            return cArchivo;
        }
    }
}
