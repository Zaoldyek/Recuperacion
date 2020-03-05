using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain
{
    public class Minutos : BaseHandler
    {
        public Minutos() { }

        public override string handle(string cCadena)
        {
            string cArchivo = "";
            if (cCadena.Contains("Minutos"))
            {
                cArchivo = "Minutos.txt";
            }
            else
            {
                cArchivo= base.next.handle(cCadena);
            }
            return cArchivo;
        }
    }
}
