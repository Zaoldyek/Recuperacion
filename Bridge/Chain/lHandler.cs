using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Chain
{
    public interface lHandler
    {
        void setNext(lHandler h);
        string handle(string cCadena);
    }
}
