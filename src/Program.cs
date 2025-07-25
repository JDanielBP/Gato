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
        public static void Menu()
        {
            while (true)
            {
                // Configuración inicial
                byte numJugadores = NumeroDeJugadores();
                var (j1Opc, j2Opc) = EligeSimbolo();

                // Simulación de carga
                Cargando(j2Opc);

                // Escenario
                Escenario.PreparandoEscenario();
                Escenario.Tablero();
                Escenario.DibujarSilueta();

                // Juego
                Juego(numJugadores, j1Opc, j2Opc);

                bool seguirJugando = JugarDeNuevo();
                if (!seguirJugando) break;
            };

            Console.ResetColor();
            Console.SetCursorPosition(10, 30);
        }
        public static byte NumeroDeJugadores()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingresa el número de jugadores: (1 ó 2)");
                Console.Write("> ");
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
        public static (char, char) EligeSimbolo()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Elige Jugador 1: X ó O?");
                Console.Write("> ");
                string input = Console.ReadLine();
                if (char.TryParse(input, out char simbolo))
                {
                    simbolo = char.ToUpper(simbolo);
                    if (simbolo == 'X' || simbolo == 'O') {
                        char simbolo2 = simbolo == 'O' ? 'X' : 'O'; // Si jugador 1 elige 'O', jugador 2 tendrá 'X'
                        return (simbolo, simbolo2);
                    }
                }
                Console.WriteLine("\nDebe seleccionar 'X' o 'O'\nPresiona ENTER para continuar...");
                Console.ReadKey();
            }
        }
        public static void Cargando(char j2Opc)
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
        public static void Juego(byte noJugadores, char j1Opc, char j2Opc)
        {
            JuegoGato j1 = new Jugador(j1Opc);
            JuegoGato j2 = noJugadores == 1
                ? new OponenteIA(j2Opc) // OponenteIA aún no funciona
                : new Jugador(j2Opc);

            // Inicializa el juego
            JuegoGato JG = new JuegoGato();
            JuegoGato.InicializarPosicionCursor();

            JG.Partida(j1, j2);
        }
        public static bool JugarDeNuevo()
        {
            char JugarDeNuevo = JuegoGato.JugarDeNuevo;
            if (JugarDeNuevo == 'S') return true;
            else
            {
                for (int i = 24; i < JuegoGato.Y1; i++) //Borra la animación del festejo tipo cohete
                    PosicionamientoCursor.WriteAt("                             ", 0, i);

                PosicionamientoCursor.WriteAt("¡Gracias por jugar!", 0, 26);
                PosicionamientoCursor.WriteAt("Presiona cualquier tecla para salir...", 0, 27);
                Console.ReadKey();
                return false;
            }
        }
    }
}
