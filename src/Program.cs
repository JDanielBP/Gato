using System;
using Gato.src.app;

namespace Gato.src
{
    class Program
    {
        // FALTA PROGRAMAR LA IA, fuera de eso todo el código es funcional
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            while (true)
            {
                // Configuración inicial
                byte numJugadores = NumeroDeJugadores();
                var (j1Opc, j2Opc) = EligeSimbolo();

                // Simulación de carga
                Cargando(j2Opc);

                // Escenario
                Escenario escenario = new Escenario();
                escenario.Titulo();
                escenario.Silueta();
                Tablero tablero = new Tablero();
                tablero.Dibujar();

                // Juego
                JuegoGato JG = Configuracion(tablero, numJugadores, j1Opc, j2Opc);
                var (estado, ganador) = JG.Iniciar();
                if (estado == JuegoGato.Estado.Victoria)
                {
                    escenario.Cohete();
                    PosicionamientoCursor.WriteAt($"Felicidades Jugador {ganador.Id}! Has ganado!", 0, 20);
                }

                bool seguirJugando = JG.VolverAJugar();
                if (!seguirJugando) break;
            };
            Salida();
        }
        static byte NumeroDeJugadores()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingresa el número de jugadores: (1 ó 2)");
                string input = Console.ReadLine();
                if (byte.TryParse(input, out byte result) && (result == 1 || result == 2))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("\nValor no válido...\nPresiona ENTER para continuar...");
                    Console.ReadKey();
                }
            }
        }
        static (char, char) EligeSimbolo()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Elige Jugador 1: X ó O?");
                string input = Console.ReadLine().Trim().ToUpper();
                if (char.TryParse(input, out char simbolo) && (simbolo == 'X' || simbolo == 'O'))
                {
                    char simbolo2 = simbolo == 'O' ? 'X' : 'O'; // Si jugador 1 elige 'O', jugador 2 tendrá 'X'
                    return (simbolo, simbolo2);
                }
                Console.WriteLine("\nDebe seleccionar 'X' o 'O'\nPresiona ENTER para continuar...");
                Console.ReadKey();
            }
        }
        static void Cargando(char j2Opc)
        {
            Random rand = new Random();
            Console.ResetColor();
            string[] frases = new string[3] {
                "Solo hay un ganador, buena suerte!",
                "Mucha suerte, jugadores",
                "Esperemos que el oponente no juegue bien!",
            };

            Console.WriteLine("\nTu oponente jugará con " + j2Opc);
            Console.WriteLine(frases[rand.Next(3)]);
            System.Threading.Thread.Sleep(100);

            char[] spinner = { '/', '-', '\\', '|' };
            for (int i = 0; i < spinner.Length * 5; i++)
            {
                Console.Write("\rCargando... " + spinner[i % spinner.Length]);
                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
        }
        static JuegoGato Configuracion(Tablero tablero, byte noJugadores, char j1Opc, char j2Opc)
        {
            IJugador j1 = new Jugador(1, j1Opc, tablero);
            IJugador j2 = noJugadores == 1
                ? new OponenteIA(2, j2Opc, tablero) // OponenteIA aún no funciona
                : new Jugador(2, j2Opc, tablero);

            return new JuegoGato(tablero, j1, j2);
        }
        static void Salida()
        {
            PosicionamientoCursor.WriteAt("¡Gracias por jugar!", 0, 25);
            PosicionamientoCursor.WriteAt("Presiona cualquier tecla para salir...", 0, 26);
            Console.ReadKey();
            Console.SetCursorPosition(0, 29);
        }
    }
}
