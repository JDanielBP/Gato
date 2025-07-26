using Gato.src.Helpers;
using Gato.src.Juego;
using System;
using System.Drawing;
using System.Linq;

namespace Gato.src.Jugadores
{
    internal class Jugador : IJugador
    {
        Tablero tablero;
        public int Id { get; }
        public char Simbolo { get; }
        enum Error
        {
            CaracterInvalido,
            SimboloInvalido,
            PosicionOcupada
        }
        public Jugador(int id, char simbolo, Tablero tablero)
        {
            Id = id;
            Simbolo = simbolo;
            this.tablero = tablero;
        }

        public void Jugar()
        {
            while (true)
            {
                Point posicion = tablero.PosicionConsola;
                CursorHelper.PosicionActual(tablero.PosicionMatriz, posicion, tablero.limiteInferior);
                Console.SetCursorPosition(posicion.X, posicion.Y);

                ConsoleKeyInfo input = Console.ReadKey(true); //Captura la acción del jugador y no lo imprima en pantalla
                MostrarError(null); // Borrar el mensaje de error anterior (si lo hay)

                ConsoleKey[] movimientoValido = { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow };
                ConsoleKey[] tiroValido = { ConsoleKey.X, ConsoleKey.O };
                if (movimientoValido.Contains(input.Key))
                {
                    Mover(posicion, input.Key);
                }
                else if (tiroValido.Contains(input.Key))
                {
                    bool terminarTurno = Tirar(posicion, input.Key);
                    if (terminarTurno) break;
                }
                else
                {
                    MostrarError(Error.CaracterInvalido);
                }
            };
            Console.ResetColor();
        }
        private void Mover(Point posicion, ConsoleKey movimiento)
        {
            if (movimiento == ConsoleKey.UpArrow && posicion.Y > tablero.limiteSuperior)
            {
                tablero.MoverPosicion(0, -1);
            }
            else if (movimiento == ConsoleKey.DownArrow && posicion.Y < tablero.limiteInferior)
            {
                tablero.MoverPosicion(0, 1);
            }
            else if (movimiento == ConsoleKey.LeftArrow && posicion.X > tablero.limiteIzquierdo)
            {
                tablero.MoverPosicion(-1, 0);
            }
            else if (movimiento == ConsoleKey.RightArrow && posicion.X < tablero.limiteDerecho)
            {
                tablero.MoverPosicion(1, 0);
            }
        }
        private bool Tirar(Point posicion, ConsoleKey tiro)
        {
            char simboloActual = tablero.GetCaracter(tablero.PosicionMatriz);
            bool terminarTurno = false;

            if (simboloActual != ' ')
            {
                MostrarError(Error.PosicionOcupada);
            }
            else if (Simbolo.ToString() != tiro.ToString())
            {
                MostrarError(Error.SimboloInvalido);
            }
            else
            {
                Console.ForegroundColor = Simbolo == 'X' ? ConsoleColor.Green : ConsoleColor.Red;
                CursorHelper.WriteAt(Simbolo.ToString(), posicion.X, posicion.Y);
                tablero.SetCaracter(tablero.PosicionMatriz, Simbolo);
                terminarTurno = true;
            }
            Console.SetCursorPosition(posicion.X, posicion.Y);
            return terminarTurno;
        }
        private void MostrarError(Error? error)
        {
            ConsoleColor? color = null;
            string texto;

            if (error is null)
            {
                Console.ResetColor();
                texto = "                     ";
            }
            else if (error == Error.CaracterInvalido)
            {
                color = ConsoleColor.Cyan;
                texto = "Caracter no válido...";
            }
            else if (error == Error.PosicionOcupada)
            {
                color = ConsoleColor.Red;
                texto = "Posición Ocupada!";
            }
            else // Error.SimboloInvalido
            {
                color = Simbolo == 'X' ? ConsoleColor.Green : ConsoleColor.Red;
                texto = "Tú juegas con " + Simbolo + "!";
            }

            if (color is not null) Console.ForegroundColor = (ConsoleColor)color;
            CursorHelper.WriteAt(texto, 1, 20);
            Console.ResetColor();
        }
    }
}
