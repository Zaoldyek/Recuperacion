using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    class PresentadorTexto : lPresentadorTexto
    {
        public bool lStatus { get; set; }

        public ConsoleColor consoleColor { get; set; }

        public void CambiarEstiloTexto(ConsoleColor _ConsoleColor)
        {
            System.Console.ForegroundColor = _ConsoleColor;
        }
    }
}
