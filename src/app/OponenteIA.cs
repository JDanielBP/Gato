using System;

namespace Gato.src.app
{
    class OponenteIA : JuegoGato
    {

        public OponenteIA(char opc) : base()
        {
            XO = opc;
        }
        public override void ComienzaTurnoDeJugador()
        {
            Console.SetCursorPosition(origCol, origFila);
            //ConsoleColor colorJugador = ConsoleColor.Red;
            XOaux = XO; // Pasa el valor de 'X' ó 'O' a la variable de la clase padre, para que evalúe al ganador

            if (XO == 'X')
                Console.ForegroundColor = ConsoleColor.Green; // Color del jugador con X
            else
                Console.ForegroundColor = ConsoleColor.Red; // Color del jugador con O

            JuegaJugadorIA();
            Console.ResetColor();

        }
        public static void JuegaJugadorIA()
        {
            int auxOrigCol = xTab + 2, auxOrigFila = yTab + 2;
        }
    }
}

















/* TODO ESTO VA DENTRO DE "class"*/

/*public void JuegaJugadorIA(int niv) //Este se encarga de tirar de acuerdo al minimax puro
{
    int auxOrigCol = xTab + 2, auxOrigFila = yTab + 2;
    if (!turnoJugador1) //Si le toca tirar a la IA
    {
        int mejorFila = 0, mejorColumna = 0; //Contendrá la coordenada de la mejor tirada
        int valor = int.MaxValue; //Tratamos de minimizar el resultado, entonces empezamos con un nivel muy alto.
        int aux;
        for (int i = 0; i < 3; i++) //Recorre todas las casillas
        {
            for (int j = 0; j < 3; j++)
            {
                if (tableroMatriz[j, i] == ' ') //Si la casilla analizada esta vacia.
                {
                    tableroMatriz[j, i] = XO; //Tira ahí

                    aux = AplicarMaximo(niv); //Sacamos el maximo  

                    if (aux < valor) // Si el resultado anterior (aux) es menor que valor (Minimo de maximos)
                    {
                        valor = aux; //Guardamos el nuevo nimimo
                        mejorFila = i; //Guardamos las coordenadas
                        mejorColumna = j;
                    }
                    tableroMatriz[j, i] = ' '; //Se borra la jugada hecha
                }
                auxOrigCol += 4;
            }
            auxOrigCol = 0;
            auxOrigFila += 2;
        }
        tableroMatriz[mejorColumna, mejorFila] = XO; //La IA tira la "mejor" opcion
        WriteAt(XO, auxOrigCol, auxOrigFila);
    }
    else //Si NO le toca tirar a la IA, similiar al if (aquí solo se comentarán las diferencias)
    {
        int mejorFila = 0, mejorColumna = 0;
        int valor = int.MinValue; //Aquí se trata de maximizar el resultado, entonces se empieza con un nivel muy bajo
        int aux;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tableroMatriz[j, i] == ' ')
                {
                    tableroMatriz[j, i] = XOauxMinimax; //El oponente (nosotros) tiramos ahí

                    aux = AplicarMinimo(niv); //Sacamos el mínimo

                    if (aux > valor) // Maximo de minimos
                    {
                        valor = aux;
                        mejorFila = i;
                        mejorColumna = j;
                    }
                    tableroMatriz[j, i] = ' '; //Se borra la jugada hecha
                }
                auxOrigCol += 4;
            }
            auxOrigCol = 0;
            auxOrigFila += 2;
        }
        tableroMatriz[mejorColumna, mejorFila] = XOauxMinimax; //Tiramos la "mejor" opcion
        WriteAt(XOaux, auxOrigCol, auxOrigFila);
    }
}

private int AplicarMinimo(int niv) //Este es el metodo minimo de MINIMAX Puro, similar al de arriba
{
    int valor = int.MaxValue; // Hay que minimizar, entonces empezaremos con un nivel alto.
    int aux;
    if (!Ganador())
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tableroMatriz[j, i] == ' ')
                {
                    tableroMatriz[j, i] = XO;

                    aux = AplicarMaximo(niv - 1); //Se disminulle el nivel. para poder asi limitar la profundidad de exploracion.

                    if (aux < valor) valor = aux; //Aqui no es necesario guardar las posiciones... puesto q no es el metodo que tira.
                        tableroMatriz[j, i] = ' '; //Se borra el movimiento echo... por q pues no queremos q se vea el movimiento.
                }
            }
        }
    }
    return valor; //Se retorna el valor minimo (Minimo de maximos)
}

private int AplicarMaximo(int niv) //Similar al de arriba
{
    int valor = int.MinValue; //Como se va ha maximizar se comienza con un minimo muy bajo
    int aux;
    if (!Ganador())
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tableroMatriz[j, i] == ' ')
                {
                    tableroMatriz[j, i] = XOauxMinimax; //El tiro es inverso al del aplicarMinimo

                    aux = AplicarMinimo(niv - 1); //Se saca un minimo

                    if (aux > valor) valor = aux; //Maximo de minimos
                        tableroMatriz[j, i] = ' ';
                }
            }
        }
    }
    return valor;
}
*/

/*public void JuegaJugadorIA()
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
}*/
