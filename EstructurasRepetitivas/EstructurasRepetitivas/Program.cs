using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasRepetitivas
{
    /**
     * Calcular la media y la desviación estándar de un conjunto de 10 personas.
     * Tome por teclado la altura en cm de cada persona y cárguela en un arreglo.
     * Presente los resultados obtenidos.
     * Muestre qué alturas se encuentran por encima de la media y por debajo de ella.
     * Muestre qué alturas se encuentran dentro del rango definido por la desviación estándar.
     * */
    class Program
    {
        static void Main(string[] args)
        {
            int[] personas = new int[3];
            int media = 0, varianza, desviacionEstandar;

            CargarArreglo(personas);
            Console.Clear();
            ImprimirArreglo(personas);
            media = CalcularMedia(personas);
            Console.WriteLine($"La media es {media}");
            ImprimirMedia(personas, media);
            varianza = CalcularVarianza(personas, media);
            Console.WriteLine($"La varianza es {varianza}");
            desviacionEstandar = (int)Math.Sqrt(varianza);
            Console.WriteLine($"La desviacion estandar es {desviacionEstandar}");
            ImprimirEstandar(personas, desviacionEstandar, media);
            Console.ReadKey();
        }

        public static void CargarArreglo(int [] arreglo)
        {
  
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.WriteLine($"Ingrese la altura en cm de la persona nro {i+1}");
                Int32.TryParse(Console.ReadLine(), out arreglo[i]);
                if (arreglo[i] == 0) i--;

            }
        }
        public static void ImprimirArreglo(int [] arregloPersonas)
        {
            for (int i = 0; i < arregloPersonas.Length; i++)
            {
                Console.WriteLine($"La Persona nro {i + 1} mide: {arregloPersonas[i]}cm.");
            }
        }
        public static int CalcularMedia(int[] arreglo)
        {
            int med = 0;

            for (int i = 0; i < arreglo.Length; i++)
            {
                med += arreglo[i];
            }
            return med /= arreglo.Length;
        }
        public static void ImprimirMedia(int [] arreglo, int med)
        {
            int menor = 0, mayor = 0;

            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] > med) mayor++;
                else menor++;
            }

            int[] arregloMenor = new int[menor];
            int[] arregloMayor = new int[mayor];
            menor = 0;
            mayor = 0;

            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] > med)
                {
                    arregloMayor[mayor] = arreglo[i];
                    mayor++;
                }
                else
                {
                    arregloMenor[menor] = arreglo[i];
                    menor++;
                }
            }

            Console.WriteLine("Personas por arriba de la media");
            ImprimirArreglo(arregloMayor);
            Console.WriteLine("Personas por abajo de la media");
            ImprimirArreglo(arregloMenor);
        }
        public static int CalcularVarianza(int [] arreglo, int media)
        {
            int varianza = 0;
            int[] arregloAux = new int[arreglo.Length];

            for (int i = 0; i < arreglo.Length; i++)
            {
                arregloAux[i] = arreglo[i] - media;
                arregloAux[i] = (int)Math.Pow(arreglo[i], 2);
            }
            varianza = CalcularMedia(arregloAux);

            return varianza;
        }
        public static void ImprimirEstandar(int [] arreglo , int desEstandar, int media)
        {
            Console.WriteLine("Personas que estan dentro del rando de la desviacion estandar");
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] > (media - desEstandar) && arreglo[i] < (media + desEstandar))
                {
                    Console.WriteLine($"Persona nro {i + 1}");
                }
            }
        }
    }
}
