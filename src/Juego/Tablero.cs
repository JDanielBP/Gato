using Gato.src.Helpers;
using System;
using System.Drawing;

namespace Gato.src.Juego
{
    internal class Tablero
    {
        public Point PosicionConsola { get { return posicionConsola; } }
        public Point PosicionMatriz { get; set; }
        public readonly int limiteSuperior, limiteInferior, limiteIzquierdo, limiteDerecho;
        public char[,] TableroMatriz => tableroMatriz;

        Point posicionConsola = new Point(0, 0);
        readonly Point posicion = new Point(10, 6);
        string[] tableroDibujo =
        {
            "+---+---+---+",
            "|   |   |   |",
            "+---+---+---+",
            "|   |   |   |",
            "+---+---+---+",
            "|   |   |   |",
            "+---+---+---+"
        };
        char[,] tableroMatriz = {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
        };
        public Tablero()
        {
            limiteDerecho = posicion.X + 10;
            limiteIzquierdo = posicion.X + 2;
            limiteSuperior = posicion.Y + 2;
            limiteInferior = posicion.Y + 5;
            PosicionMatriz = new Point(0, 0);
        }

        public void Dibujar()
        {
            for (int i = 0; i < tableroDibujo.Length; i++)
            {
                CursorHelper.WriteAt(tableroDibujo[i], posicion.X, posicion.Y + i + 1);
            }
        }
        public void PosicionInicial() => posicionConsola = new Point(posicion.X + 2, posicion.Y + 2);
        public char GetCaracter(Point posicion) => tableroMatriz[posicion.X, posicion.Y];
        public void SetCaracter(Point posicion, char caracter) => tableroMatriz[posicion.X, posicion.Y] = caracter;
        public void MoverPosicion(int dx, int dy)
        {
            Point pos = PosicionMatriz;
            pos.X += dx;
            pos.Y += dy;
            PosicionMatriz = pos;

            posicionConsola.X += dx * 4;
            posicionConsola.Y += dy * 2;

            Console.SetCursorPosition(posicion.X, posicion.Y);
        }
    }
}
