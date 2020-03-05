using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Interfaces
{
    interface lPresentadorTexto
    {
        bool lStatus { get; set; }

        ConsoleColor consoleColor { get; set; }

        void CambiarEstiloTexto(ConsoleColor _ConsoleColor);
    }
}
