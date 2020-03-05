using Bridge.Empresas;
using Bridge.Envios;
using Bridge.Interfaces;
using Bridge.Utilerias;
using State;
using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            lPresentadorTexto presentadorTexto = new PresentadorTexto();
            ILimpiarArchivos limpiarArchivos = new LimpiarArchivos();
            limpiarArchivos.vaciarArchivos();
            lPresentador presentador = new PresentadorDatos();
            lLeerArchivoTexto Lector = new LeerArchivoTexto();
            lLeerArchivoTexto LectorJSON = new LeerArchivoJSON();
            List<string> lines = new List<string>();

            if (args[0] == "-f")
            {
                if (args[1] == "CSV")
                    lines = Lector.LeerArchivo("Pedidos.txt");
                else
                    lines = LectorJSON.LeerArchivo("Pedidos.json");
            }

            foreach (string line in lines)
            {
                presentador.PresentadorInformacion(line);
                Console.WriteLine();
            }
            Console.ReadLine();
            presentadorTexto.CambiarEstiloTexto(ConsoleColor.White);

        }
    }

}

//Agregar nueva empresa de paqueteria
//1.- Agregar clase en la carpeta empresa con el nombre de la empresa y que implemente la interfaz lEmpresas 
//2.- Agregar la lógica parecida a las empresas ya existentes y cambiar los datos necesarios
//Archivo Main
//1.- Declarar la variable de la nueva paqueteria lEmpresas [paqueteria] = new [paqueteriaService](new List<lEnvios>() { [ARREGLO DE TIPOS DE ENVIO] }, [MARGEN DE GANANCIA EN %], "[NOMBRE DE LA PAQUETERIA]");
//2.- Agregar la nueva paqueteria a la lista de empresas lstEmpresas


//Agregar nueva medio de transporte
//1.- Agregar clase en la carpeta envios con el nombre del transporte y que implemente la interfaz lEnvios 
//2.- Agregar la lógica parecida a las empresas ya existentes
//Archivo Main
//1.- Declarar la variable del nuevo medio de transporte lEnvios [NOMBRE_VARIABLE] = new Avion() { dVelocidadEntrega = [VALOR_VELOCIDAD], dCostoEnvio = [COSTO],cNombre="[NOMBRE_TRANSPORTE]" };
//2.- Agregar el nuevo medio de transporte a la lista de transportes lstTransportes
