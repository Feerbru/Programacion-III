using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseDado
{
    class Program
    {
        /**
         * Dos jugadores, Dos dados y Apuestas
         * Tres modos de apuesta {conservador -1/2, arriesgado -2/5, desesperado -4/15}
         * Cada jugador cuenta con $100 iniciales y un pozo de $10000.
         * El juego termina cuando el pozo o el saldo de algún jugador llega a cero. */
        static void Main(string[] args)
        {
            Juego();
        }
        //public static void Apostar(Dado dado)
        //{
        //    int apuesta, seguir = 0;
        //    String jugador;
        //    do
        //    {
        //        Console.WriteLine("<--BIENVENIDOS AL JUEGO DE APUESTA-->\n" +
        //                        "Por favor ingrese el valor");
        //        apuesta = Int32.Parse(Console.ReadLine());

        //        dado.lanzarDado();
        //        Console.WriteLine($"El resultado del dado es {dado.getCaras()}");

        //        jugador = (dado.getCaras() == apuesta) ? "Ganaste" : "Perdiste";
        //        Console.WriteLine(jugador);

        //        Console.WriteLine("Desea seguir apostando?\n" +
        //                            "1- seguir\n" +
        //                            "2- salir");
        //        seguir = Int32.Parse(Console.ReadLine());
        //        Console.Clear();
        //    } while (seguir == 1);
        //}
        public static void Menu()
        {
            Console.WriteLine("<--BIENVENIDOS-->");
            Console.WriteLine("AL JUEGO DE APUESTAS");
        }
        public static void CargarApuestas(Jugador jugador)
        {
            int valor;
            do
            {
                Menu();
                Console.WriteLine("Existen tres modos de apuesta:\n" +
                                    "1-Conservador: apuesta * 1 y gane -> apuesta * 2.\n" +
                                    "2-Arriesgado: apuesta * 2 y gane -> apuesta * 5.\n" +
                                    "3-Desesperado: apuesta * 4 y gane -> apuesta * 15.");

                Console.WriteLine($"{jugador.Nombre} ingrese el tipo de apuesta que desee:");
                valor = Int32.Parse(Console.ReadLine());
                if (valor > 0 && valor < 4)
                {
                    jugador.TipoApuesta = valor;
                }
                else
                {
                    Console.WriteLine("Modo de apuesta incorrecta!!!\n" +
                                        "Vuelva a intertar nuevamente\n" +
                                        "Presione Enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (valor > 3);
            
            Console.Clear();
            do
            {
                Menu();
                Console.WriteLine($"{jugador.Nombre} ingrese la cantidad de dinero a apostar:");
                valor = Int32.Parse(Console.ReadLine());
                if (valor > 0 && valor <= jugador.Cuenta)
                {
                    jugador.DineroApuesta = valor;
                }
                else
                {
                    Console.WriteLine("Saldo insufiente!!!\n" +
                                     "Vuelva a intertar con un monto menor\n" +
                                     "Presione Enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (jugador.Cuenta < valor);

            Console.Clear();
            do
            {
                Menu();
                Console.WriteLine($"{jugador.Nombre} ingrese la apuesta:");
                valor = Int32.Parse(Console.ReadLine());
                if (valor > 0 && valor < 13)
                {
                    jugador.Apuesta = valor;
                }
                else
                {
                    Console.WriteLine("Apuesta fuera del rango!!!\n" +
                     "Vuelva a intertar\n" +
                     "Presione Enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (valor > 12);

            Console.Clear();
        }
        public static int ComprobaGanador(Jugador jug, int valorD, int pozo)
        {
            if (jug.Apuesta == valorD)
            {
                switch (jug.TipoApuesta)
                {
                    case 1:
                        jug.Cuenta += jug.DineroApuesta * 2;
                        pozo -= jug.DineroApuesta * 2;
                        break;
                    case 2:
                        jug.Cuenta += jug.DineroApuesta * 5;
                        pozo -= jug.DineroApuesta * 5;
                        break;
                    case 3:
                        jug.Cuenta += jug.DineroApuesta * 15;
                        pozo -= jug.DineroApuesta * 5;
                        break;
                }
                Console.WriteLine($"{jug.Nombre} es el GANADOR!!!!");
            }
            else
            {
                switch (jug.TipoApuesta)
                {
                    case 1:
                        jug.Cuenta -= jug.DineroApuesta;
                        pozo += jug.DineroApuesta;
                        break;
                    case 2:
                        jug.Cuenta -= jug.DineroApuesta * 2;
                        pozo += jug.DineroApuesta * 2;
                        break;
                    case 3:
                        jug.Cuenta -= jug.DineroApuesta * 4;
                        pozo += jug.DineroApuesta * 4;
                        break;
                }
                Console.WriteLine($"{jug.Nombre} mala suerte, PERDISTE!!!!");
            }
            Console.WriteLine("Volver a intentar!!!\n" +
                              "Presione Enter para continuar...");
            Console.ReadKey();
            Console.Clear();
            return pozo;
        }
        public static void VerResultados(Jugador jug1, Jugador jug2, int pozo, int ronda) {

            Console.WriteLine($"Ronda n°{ronda}");
            Console.WriteLine("Resultados Parciales:");
            Console.WriteLine($"{jug1.Nombre} --> ${jug1.Cuenta}");
            Console.WriteLine($"{jug2.Nombre} --> ${jug2.Cuenta}");
            Console.WriteLine($"El pozo: ${pozo}");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Juego()
        {
            Dado dado1 = new Dado();
            Dado dado2 = new Dado();
            Jugador jug1 = new Jugador("Julian");
            Jugador jug2 = new Jugador("Matias");
            int Pozo = 10000;
            int valorDado, ronda = 1;

            CargarApuestas(jug1);
            CargarApuestas(jug2);

            do
            {
                dado1.lanzarDado();
                dado2.lanzarDado();
                valorDado = dado1.getCaras() + dado2.getCaras();

                Console.WriteLine($"Ronda n°{ronda}");
                Console.WriteLine($"Valor de los dados es {valorDado}");

                Pozo = ComprobaGanador(jug1, valorDado, Pozo);
                Pozo = ComprobaGanador(jug2, valorDado, Pozo);

                VerResultados(jug1, jug2, Pozo, ronda);
                CargarApuestas(jug1);
                CargarApuestas(jug2);
                ronda++;
            } while (Pozo > 0 || jug1.Cuenta > 0);

            Console.ReadKey();
            //Apostar(dado1);
        }
    }
}
