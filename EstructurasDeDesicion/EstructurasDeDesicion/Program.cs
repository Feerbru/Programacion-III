using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDesicion
{
    /**Cree una aplicación de consola.
     * Solicite el ingreso de un texto y controle que no esté vacío.
     * Despliegue un menú que muestre 3 opciones (Texto en mayúscula, Texto en minúscula y Texto Original).
     * Capture la entrada con Console.Readkey y realice la opción solicitada.
     * */
    class Program
    {
        static void Main(string[] args)
        {
            String texto;

            Console.WriteLine("<-- Bienvenidos-->");
            texto = IngresarCadena();

            Console.Clear();
            Console.WriteLine("<------MENU------>\n" +
                                "Presiona A -> Para transformar el texto a Mayuscula.\n" +
                                "Presiona B -> Para transformar el texto a Minuscula.\n" +
                                "Presiona C -> Para dejar el texto original.\n" +
                                "Preciona D -> Para salir del programa.");

            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.A) Console.WriteLine(texto.ToLower());
            if (tecla.Key == ConsoleKey.B) Console.WriteLine(texto.ToUpper());
            if (tecla.Key == ConsoleKey.C) Console.WriteLine(texto);
            if (tecla.Key == ConsoleKey.D) Environment.Exit(0);
            Console.ReadKey();
        }

        public static String IngresarCadena()
        {
            String cadena;
            do
            {
                Console.WriteLine("Ingrese una cadena de texto");
                cadena = Console.ReadLine();
                if (cadena.Length == 0)
                {
                    Console.WriteLine("no ingreso ninguna cadena..");
                }
            } while (cadena.Length == 0);

            return cadena;
        }

        
    }
}
