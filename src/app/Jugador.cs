using System;

namespace Gato.src.app
{
    class Jugador : JuegoGato
    {

        public Jugador(char opc) : base()
        {
            XO = opc;
        }
        public override void ComienzaTurnoDeJugador()
        {
            Console.SetCursorPosition(origCol, origFila);
            //ConsoleColor colorJugador = ConsoleColor.Red;
            XOaux = XO; // Pasa el valor de 'X' ó 'O' a la variable de la clase padre, para que evalúe al ganador
            if (turnoJugador1)
                WriteAt("Jugador 1 ", 12, 4);
            else
                WriteAt("Jugador 2 ", 12, 4);
            if (XO == 'X')
                Console.ForegroundColor = ConsoleColor.Green; // Color del jugador con X
            else
                Console.ForegroundColor = ConsoleColor.Red; // Color del jugador con O
            WriteAt("Te toca: " + XO, 12, 5);
            JuegaJugador();
            Console.ResetColor();
        }
        public void JuegaJugador()
        {
            ConsoleKeyInfo action;
            bool sigaEsteTurno = true;
            do
            {
                PosicionActual();
                if (XO == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Color del jugador con X
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Color del jugador con O
                }
                action = Console.ReadKey(false); //Captura la acción del jugador y no lo imprima en patalla
                WriteAt("                         ", 1, 20);
                switch (action.Key) //Evalúa la acción del jugador
                {
                    case ConsoleKey.RightArrow:
                        AsegurarColorXO();
                        if (origCol < limitRightArrow)
                        {
                            Console.SetCursorPosition(origCol += 4, origFila);
                            x++;
                        }
                        else Console.SetCursorPosition(origCol, origFila);
                        break;
                    case ConsoleKey.LeftArrow:
                        AsegurarColorXO();
                        if (origCol > limitLeftArrow)
                        {
                            Console.SetCursorPosition(origCol -= 4, origFila);
                            x--;
                        }
                        else Console.SetCursorPosition(origCol, origFila);
                        break;
                    case ConsoleKey.UpArrow:
                        AsegurarColorXO();
                        if (origFila > limitUpArrow)
                        {
                            Console.SetCursorPosition(origCol, origFila -= 2);
                            y--;
                        }
                        else Console.SetCursorPosition(origCol, origFila);
                        break;
                    case ConsoleKey.DownArrow:
                        AsegurarColorXO();
                        if (origFila < limitDownArrow)
                        {
                            Console.SetCursorPosition(origCol, origFila += 2);
                            y++;
                        }
                        else Console.SetCursorPosition(origCol, origFila);
                        break;
                    case ConsoleKey.X:
                        Tirar(ref sigaEsteTurno, ConsoleKey.X);
                        break;
                    case ConsoleKey.O:
                        Tirar(ref sigaEsteTurno, ConsoleKey.O);
                        break;
                    default:
                        WriteAt(tableroMatriz[x, y], origCol, origFila);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        WriteAt("                     ", 1, 20);
                        WriteAt("Caracter no válido...", 1, 20);
                        Console.ResetColor();
                        Console.SetCursorPosition(origCol, origFila);
                        break;
                }
            } while (sigaEsteTurno); //Mientras siga este turno
        }
        public void AsegurarColorXO()
        {
            if (tableroMatriz[x, y] == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Green; // Asegura color del Jugador
                WriteAt(tableroMatriz[x, y], origCol, origFila);
            }
            if (tableroMatriz[x, y] == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Red; // Asegura color del otro Jugador
                WriteAt(tableroMatriz[x, y], origCol, origFila);
            }
        }
        public void Tirar(ref bool sigaEsteTurno, ConsoleKey tiro)
        {
            if (tableroMatriz[x, y] != ' ')
            {
                WriteAt(tableroMatriz[x, y], origCol, origFila);
                AsegurarColorXO();
                Console.SetCursorPosition(origCol, origFila);
                Console.ForegroundColor = ConsoleColor.Red;
                WriteAt("Posición Ocupada!", 1, 20);
                Console.ResetColor();
            }
            else
            {
                if (XO != Convert.ToChar(tiro)) //Si no te toca jugar con X o con O, entonces...
                {
                    WriteAt(tableroMatriz[x, y], origCol, origFila);
                    Console.SetCursorPosition(origCol, origFila);
                    if (XO == 'X')
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    WriteAt("Tú juegas con " + XO + "!", 1, 20);
                    Console.ResetColor();
                }
                else
                {
                    WriteAt(XO, origCol, origFila);
                    tableroMatriz[x, y] = XO;
                    sigaEsteTurno = false; // Ya no prosigue este turno, por lo tanto debe salir, mandando un 'false'
                }
            }
        }
    }
}
