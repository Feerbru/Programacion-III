using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parametros___Moda
{
    /**
     * Implementar una función Moda, que reciba como valores una cantidad indeterminada de enteros
     * y devuelva la moda (estadística), el valor mínimo y el valor máximo.
     * Invocar este método y mostrar los resultados por consola.
     * Elija los modificadores mas adecuados
    */
    class Program
    {
        static void Main(string[] args)
        {
            int min, max, moda;

            moda = CalcularModa(out min, out max, 5,6,5,2,2,1,2,2,2,5,6);
            Console.WriteLine($"La moda es {moda}");
            Console.WriteLine($"La minima es {min}");
            Console.WriteLine($"La maxima es {max}");
            Console.ReadKey();
        }

        public static int CalcularModa(out int minimo, out int maximo, params int[] arreglo)
        {
            int moda = 0, cantidad = 0 , modaAux = 0;
            int aux = arreglo.Length - 1;
            Array.Sort(arreglo);

            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] == arreglo[aux])
                {
                    cantidad++;
                    if (cantidad > modaAux)
                    {
                        modaAux++;
                        moda = arreglo[i];
                    }
                }
                else
                {
                    cantidad = 0;
                }
                aux--;
            }
            minimo = arreglo[0];
            maximo = arreglo[arreglo.Length-1];

            return moda;
        }
    }
}
