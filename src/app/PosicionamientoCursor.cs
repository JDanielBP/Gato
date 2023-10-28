using System;

namespace Gato.src.app
{
    class PosicionamientoCursor
    {
        protected static int x, y;
        protected static int xTab = 10, yTab = 6;
        protected static int origFila;
        protected static int origCol;
        protected static readonly int limitRightArrow = xTab + 10;
        protected static readonly int limitLeftArrow = xTab + 2;
        protected static readonly int limitUpArrow = yTab + 2;
        protected static readonly int limitDownArrow = yTab + 5;
        public static int OrigFila { get => origFila; set => origFila = value; }
        public static int OrigCol { get => origCol; set => origCol = value; }

        public PosicionamientoCursor()
        {
            x = 0;
            y = 0;
        }

        public static void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public static void WriteAt(char s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public static void PosicionActual()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteAt("Fila: " + Convert.ToString(y + 1) + "    ", xTab + 3, 16);
            WriteAt("Col:  " + Convert.ToString(x + 1) + "    ", xTab + 3, 17);
            Console.SetCursorPosition(origCol, origFila);
            Console.ResetColor();
        }
        public virtual void ComienzaTurnoDeJugador() { }
    }
}
