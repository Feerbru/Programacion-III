using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseDado
{
    class Program
    {
        static void Main(string[] args)
        {
            Dado dado = new Dado();
            Apostar(dado);
        }
        public static void Apostar(Dado dado)
        {
            int apuesta, seguir = 0;
            String jugador;
            do
            {
                Console.WriteLine("<--BIENVENIDOS AL JUEGO DE APUESTA-->\n" +
                                "Por favor ingrese el valor");
                apuesta = Int32.Parse(Console.ReadLine());

                dado.lanzarDado();
                Console.WriteLine($"El resultado del dado es {dado.getCaras()}");

                jugador = (dado.getCaras() == apuesta) ? "Ganaste" : "Perdiste";
                Console.WriteLine(jugador);

                Console.WriteLine("Desea seguir apostando?\n" +
                                    "1- seguir\n"+
                                    "2- salir");
                seguir = Int32.Parse(Console.ReadLine());
                Console.Clear();
            } while (seguir == 1);
        }
    }
}
