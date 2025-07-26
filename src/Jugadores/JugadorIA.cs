using Gato.src.Juego;
using System;

namespace Gato.src.Jugadores
{
    internal class JugadorIA : IJugador
    {
        Tablero tablero;
        public int Id { get; }
        public char Simbolo { get; }
        public JugadorIA(int id, char simbolo, Tablero tablero)
        {
            Id = id;
            Simbolo = simbolo;
            this.tablero = tablero;
        }

        public void Jugar()
        {

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
