using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain
{
    public abstract class BaseHandler : lHandler
    {
        public lHandler next { get; set; }

        public abstract string handle(string cCadena);

        public void setNext(lHandler h)
        {
            next = h;
        }
    }
}
