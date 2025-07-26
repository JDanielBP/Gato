using System;
using System.Drawing;

namespace Gato.src.Helpers
{
    internal static class CursorHelper
    {
        public static void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public static void PosicionActual(Point info, Point position, int lowerLimit)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteAt("Fila: " + Convert.ToString(info.Y + 1) + "    ", lowerLimit + 3, 16);
            WriteAt("Col:  " + Convert.ToString(info.X + 1) + "    ", lowerLimit + 3, 17);
            Console.SetCursorPosition(position.X, position.Y);
            Console.ResetColor();
        }
    }
}
