using Bridge.Chain;
using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    public class GuardarRegistro : lGuardarRegistro
    {
        public void guardarRegistro(string[] _lstExpresiones, string _cOracion,string _cEmpresa)
        {
            string cEmpresa = _cEmpresa;
            string cCarpeta = "";
            string cArchivo = "";

            if (_lstExpresiones[1] == "llegó")
                cCarpeta = "Entregados";
            else
                cCarpeta = "Pendientes";

            Minutos Minutos = new Minutos();
            Horas Horas = new Horas();
            Dias Dias = new Dias();
            Semanas Semanas = new Semanas();
            Meses Meses = new Meses();
            Bimestre Bimestre = new Bimestre();
            Años Años = new Años();
            Minutos.setNext(Horas);
            Horas.setNext(Dias);
            Dias.setNext(Semanas);
            Semanas.setNext(Meses);
            Meses.setNext(Bimestre);
            Bimestre.setNext(Años);
            cArchivo = Minutos.handle(_lstExpresiones[4]);

            string path = Environment.CurrentDirectory + "\\" + _cEmpresa+"\\"+ cCarpeta+"\\"+ cArchivo;
            File.AppendAllLines(path, new String[] { _cOracion });
        }
    }
}
