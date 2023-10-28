using System;
using Gato.src.app;

namespace Gato.src
{
    class Program
    {
        // FALTA PROGRAMAR LA IA, fuera de eso todo el código es funcional
        static void Main(string[] args)
        {
            MainGato();
        }
        public static void MainGato()
        {
            bool seguirJugando;
            do
            {
                byte noJugadores = NumeroDeJugadores();

                char j1Opc = EligeXO();
                char j2Opc = 'O'; // Inicializa al jugador 2 con 'O'
                if (j1Opc == 'O') j2Opc = 'X'; // Si jugador 1 elije 'O' Entonces jugador 2 tendrá 'X'

                Cargando(j1Opc);

                seguirJugando = IniciaJuegoGato(noJugadores, j1Opc, j2Opc);

            } while (seguirJugando); //Mientras se quiera seguir jugando
            Console.ResetColor();
            Console.SetCursorPosition(10, 30);
        }
        public static byte NumeroDeJugadores()
        {
            byte noJugadores = 0;
            do
            {
                Console.WriteLine("Ingresa el número de jugadores: (1 ó 2)");
                try
                {
                    noJugadores = Convert.ToByte(Console.ReadLine());
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nNúmero no permitido...\nPresiona ENTER para continuar...");
                    Console.ReadKey();
                    noJugadores = 0;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nValor no válido...\nPresiona ENTER para continuar...");
                    Console.ReadKey();
                }
                finally
                {
                    if (noJugadores > 2)
                    {
                        Console.WriteLine("\nNúmero no permitido...\nPresiona ENTER para continuar...");
                        Console.ReadKey();
                        noJugadores = 0;
                    }
                    Console.Clear();
                }
            } while (noJugadores == 0);
            return noJugadores;
        }
        public static char EligeXO()
        {
            char opc = ' ';
            char opcAux;
            do
            {
                Console.WriteLine("Elige Jugador 1: X ó O?");
                try
                {
                    opc = Convert.ToChar(Console.ReadLine());
                    opcAux = char.ToUpper(opc); // Hacer mayúscula al valor ingresado
                    opc = opcAux;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nValor no válido...\n");
                }
                finally
                {
                    if (!(opc == 'X' || opc == 'O')) // Si no es X ni O entonces entra a la sentencia if
                    {
                        Console.WriteLine("Debe ser una 'X' o una 'O'\nPresiona ENTER para continuar...");
                        Console.ReadKey();
                        opc = ' ';
                        //Checar salida...
                    }
                    Console.Clear();
                }
            } while (!(opc == 'X' || opc == 'O')); // Mientras no sea X ni O
            return opc;
        }
        public static void Cargando(char j1Opc)
        {
            Random rand = new Random();
            Console.ResetColor();
            string[] frasesX = new string[3] {
                "Solo hay un ganador, buena suerte!",
                "Mucha suerte, jugadores",
                "Esperemos que el oponente no juegue bien!",
            };
            if (j1Opc == 'X')
                Console.WriteLine("Tu oponente jugará con Círculos (O)...");
            else
                Console.WriteLine("Tu oponente jugará con X...");

            Console.WriteLine(frasesX[rand.Next(0, 2 + 1)]);
            System.Threading.Thread.Sleep(100);

            for (int i = 0; i < 10; i++)
            {
                Console.Write("\rCargando... /");
                System.Threading.Thread.Sleep(100);

                Console.Write("\rCargando... -");
                System.Threading.Thread.Sleep(100);

                Console.Write("\rCargando... " + @"\");
                System.Threading.Thread.Sleep(100);

                Console.Write("\rCargando... |");
                System.Threading.Thread.Sleep(100);
            }

            Console.Clear();

            //Escenario
            Escenario.PreparandoEscenario();
            Escenario.Tablero();
            Escenario.DibujarSilueta();
        }
        public static bool IniciaJuegoGato(byte noJugadores, char j1Opc, char j2Opc)
        {
            char JugarDeNuevo;
            if (noJugadores == 1) //Esta opción aún no funciona
            {
                JuegoGato j1 = new Jugador(j1Opc);
                JuegoGato j2 = new OponenteIA(j2Opc);

                // Inicializa el juego
                JuegoGato JG = new JuegoGato();
                JuegoGato.InicializarPosicionCursor();

                JG.Partida(j1, j2);
            }
            else
            {
                JuegoGato j1 = new Jugador(j1Opc);
                JuegoGato j2 = new Jugador(j2Opc);

                // Inicializa el juego
                JuegoGato JG = new JuegoGato();
                JuegoGato.InicializarPosicionCursor();

                JG.Partida(j1, j2);
            }
            JugarDeNuevo = JuegoGato.JugarDeNuevo;
            if (JugarDeNuevo == 'S')
            {
                Console.Clear();
                return true;
            }
            else
            {
                for (int i = 24; i < JuegoGato.Y1; i++) //Borra la animación del festejo tipo cohete
                {
                    PosicionamientoCursor.WriteAt("                             ", 0, i);
                }
                PosicionamientoCursor.WriteAt("¡Gracias por jugar!", 0, 26);
                PosicionamientoCursor.WriteAt("Presiona cualquier tecla para salir...", 0, 27);
                Console.ReadKey();
                return false;
            }
        }
    }
}
