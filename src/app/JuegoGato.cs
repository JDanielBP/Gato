using System;

namespace Gato.src.app
{
    class JuegoGato : PosicionamientoCursor
    {
        protected char XO;
        protected static char XOaux;
        protected static int nivel = 10; //La dificultad del juego (La profundidad de busqueda) únicamente usado por el OponenteIA, no por el jugador
        protected static char XOauxMinimax;
        private byte contadorTiros;
        private static char jugarDeNuevo;
        protected static char[,] tableroMatriz;
        protected static bool turnoJugador1;
        private static int x1, y1, topey1;
        public static char JugarDeNuevo { get => jugarDeNuevo; set => jugarDeNuevo = value; }
        public static int X1 { get => x1; set => x1 = value; }
        public static int Y1 { get => y1; set => y1 = value; }
        public JuegoGato()
        {
            tableroMatriz = new char[,] {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
            contadorTiros = 0;
            x1 = 14;
            y1 = 40;
            jugarDeNuevo = ' ';
            topey1 = 28;
        }
        public static void InicializarPosicionCursor()
        {
            OrigCol = xTab + 2;
            OrigFila = yTab + 2;
        }
        public void Partida(JuegoGato player1, JuegoGato player2)
        {
            Random quienEmpieza = new Random(); // Para que sea aleatorio el jugador que va a iniciar el juego
            turnoJugador1 = Convert.ToBoolean(quienEmpieza.Next(2));
            do
            {
                if (turnoJugador1)
                {
                    player1.ComienzaTurnoDeJugador();
                    if (nivel != 0)
                    {
                        XOauxMinimax = XO; //Usado únicamente cuando se juega contra la IA, es declarado aquí porque aquí se encuentra la instancia de la variable 'XO'
                    }
                    if (Ganador())
                    {
                        WriteAt("Felicidades Jugador 1! Has ganado!", 0, 20);
                        break;
                    }
                }
                else
                {
                    player2.ComienzaTurnoDeJugador();
                    if (Ganador())
                    {
                        WriteAt("Felicidades Jugador 2! Has ganado!", 0, 20);
                        break;
                    }
                }
                //Cambio de turno
                if (turnoJugador1) turnoJugador1 = false;
                else turnoJugador1 = true;

                ++contadorTiros;
                if (jugarDeNuevo == 'S' || jugarDeNuevo == 'N')
                {
                    break;
                }
            } while (!Ganador());
            if (jugarDeNuevo != 'S' && jugarDeNuevo != 'N')
            {
                CoheteDibujo();
                VolverAJugar();
            }
        }
        public bool Ganador()
        {
            //XOaux porque puede contener a 'X' ó 'O'
            for (int i = 0; i < 3; i++)
            {
                // Comprobar Filas
                if (tableroMatriz[0, i] == XOaux && tableroMatriz[1, i] == XOaux && tableroMatriz[2, i] == XOaux)
                {
                    return true;
                }
                // Comprobar Columnas
                if (tableroMatriz[i, 0] == XOaux && tableroMatriz[i, 1] == XOaux && tableroMatriz[i, 2] == XOaux)
                {
                    return true;
                }
            }
            //Compobar Diagonales
            if (tableroMatriz[0, 0] == XOaux && tableroMatriz[1, 1] == XOaux && tableroMatriz[2, 2] == XOaux)
            {
                return true;
            }
            if (tableroMatriz[0, 2] == XOaux && tableroMatriz[1, 1] == XOaux && tableroMatriz[2, 0] == XOaux)
            {
                return true;
            }
            // Qué pasa si nadie gana?
            if (contadorTiros > 2)
            {
                if (tableroMatriz[0, 0] != ' ' && tableroMatriz[0, 1] != ' ' && tableroMatriz[0, 2] != ' '
                 && tableroMatriz[1, 0] != ' ' && tableroMatriz[1, 1] != ' ' && tableroMatriz[1, 2] != ' '
                 && tableroMatriz[2, 0] != ' ' && tableroMatriz[2, 1] != ' ' && tableroMatriz[2, 2] != ' ')
                {
                    VolverAJugar(); // Si nadie gana pregunta si vuelven a jugar
                    return false;
                }
            }
            return false;
        }
        public virtual void CoheteDibujo()
        {
            int auxy1 = y1;
            byte tiempo = 150;
            for (int yi = y1; yi > topey1; yi--)
            {
                WriteAt("*", x1, yi);
                System.Threading.Thread.Sleep(tiempo);

            }
            for (int yi = y1; yi > topey1 + 1; yi--)
            {
                WriteAt(" ", x1, yi);
                --auxy1;
            }
            int right = x1, left = x1, up = auxy1, down = auxy1;

            for (int i = 0; i < 4; i++)
            {
                left -= 2;
                right += 2;
                up -= 1;
                down += 1;
                WriteAt("*", left, up);
                WriteAt("*", right, up);
                WriteAt("*", left, down);
                WriteAt("*", right, down);
                System.Threading.Thread.Sleep(tiempo);
            }
        }
        public void VolverAJugar()
        {
            do
            {
                WriteAt("¿Volver a jugar? S/N", 0, 22);
                Console.SetCursorPosition(0, 23);
                try
                {
                    jugarDeNuevo = Convert.ToChar(Console.ReadLine());
                    char auxjugarDeNuevo = char.ToUpper(jugarDeNuevo);
                    jugarDeNuevo = auxjugarDeNuevo;
                }
                catch (FormatException)
                {
                    WriteAt("Ingresa un valor válido...", 0, 25);
                    Console.ReadKey();
                    WriteAt("                          ", 0, 23);
                    WriteAt("                          ", 0, 25);
                }
            } while (!(jugarDeNuevo == 'S' || jugarDeNuevo == 'N'));
        }
    }
}
