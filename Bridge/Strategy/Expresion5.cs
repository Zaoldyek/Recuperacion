using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Expresion5 : lStrategy
    {
        public string Ejecutar(DateTime _dtFechaEntrega, DateTime _dtHoy,State.State _entPedido)
        {
            TimeSpan dtDiferencia = _dtFechaEntrega.Subtract(_dtHoy);
            int iTotalHoras = Math.Abs(Convert.ToInt32(dtDiferencia.TotalHours));
            int iCantidad = 0;
            string cDiferenciaTiempo = "";
            if (iTotalHoras < 1)
            {
                iCantidad = Math.Abs(dtDiferencia.Minutes);
                cDiferenciaTiempo = $"{iCantidad} Minutos";
            }
            if (iTotalHoras >= 1 && iTotalHoras <= 23)
            {
                iCantidad = iTotalHoras;
                cDiferenciaTiempo = $"{iCantidad} Horas";
            }
            if (iTotalHoras > 23)
            {
                iCantidad=(iTotalHoras / 23);
                cDiferenciaTiempo = $"{iCantidad} Días";
            }
            if (iTotalHoras > 138 && iTotalHoras < 690)
            {
                iCantidad = (iTotalHoras / 23)/6;
                cDiferenciaTiempo = $"{iCantidad} Semanas";
            }
            if (iTotalHoras >= 690)
            {
                iCantidad = (iCantidad / 30);
                cDiferenciaTiempo = $"{iCantidad} Meses";
            }
            if (iTotalHoras >= 1380)
            {
                iCantidad = (iTotalHoras / 1380);
                cDiferenciaTiempo = $"{iCantidad} Bimestre";
            }
            if (iTotalHoras >= 8760)
            {
                iCantidad = (iTotalHoras / 8760);
                cDiferenciaTiempo = $"{iCantidad} Años";
            }

            return cDiferenciaTiempo;
        }
    }
}
