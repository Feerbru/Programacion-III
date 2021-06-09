using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraAplicacion
{
    /*Cree una aplicación de consola 
     * Solicite el ingreso de dos valores por pantalla 
     * Al final muestre en forma descriptiva los resultados de aplicar las cuatro operaciones básicas
     */
    class Program
    {
        static void Main(string[] args)
        {
            int valor1, valor2;
 
            valor1 = CargarNro();
            valor2 = CargarNro();
            Console.Clear();
            Console.WriteLine($"La suma de {valor1} + {valor2} = {valor1 + valor2}");
            Console.WriteLine($"La resta de {valor1} - {valor2} = {valor1 - valor2}");
            Console.WriteLine($"La multiplicacion de {valor1} - {valor2} = {valor1 * valor2}");
            Console.WriteLine($"La division de {valor1} / {valor2} = {valor1 / valor2}");
            Console.ReadKey();
        }

        public static int CargarNro()
        {
            int nro;
            do
            {
                Console.Clear();
                Console.WriteLine("<-- Bienvenido -->");
                Console.WriteLine("Ingrese un numero:");
                int.TryParse(Console.ReadLine(), out nro);
            } while (nro == 0);

            return nro;
        }
    }
}
