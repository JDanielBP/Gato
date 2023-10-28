using System;

namespace Gato.src.app
{
    class Escenario : PosicionamientoCursor
    {
        static string[] dibujo = new string[25]{
            @"MMMMMX:.oNMMMMWMMMMMMMMMMMMMMMMMMMMMMMMM",
            @"MMWMMk. .oNMMMMMMMMMMMMMMMMMMMMMMMMMMMMM",
            @"MMWKd'   .lKWMMMMMMMMMMMMMMMMMMMMMMMMMMM",
            @"WO:.       .c0WMMMMMMMMMMMMMMMMMMMMMMMMM",
            @"k.           .xWMMMMMMMMMMMMMMMMMMMMMMMM",
            @"l             .OMMMMMMMMMMMMMMMMMMMWWMMM",
            @".              lNMMMMMMMMMMMMMMMMNXKNWMM",
            @",              .dNMMMMMMMMMMMMMNk;..':xN",
            @"Xkoc.           .:0WMMMMMMMMMMWx.      ;",
            @"MWMWo             .oOXWMMMMMMMNc       .",
            @"MMWO'               .'dXWMMMMMWl    ;dkK",
            @"MMK,                   'dXMMMMMO'  .xMMM",
            @"MMd.                     'dXWMMWx.  cNMM",
            @"MMx.                       .oXMWNo. .xWM",
            @"MMK,                         'kNMNl  ;KM",
            @"MMWd.                         .oNMX: .xW",
            @"MMMNc       .                  .xWMk. cN",
            @"MMMM0,    ...                   :XMK, ,K",
            @"MMMMWd.   ..                    ,0MX; ,K",
            @"MMMMM0'   ,.                    '0MO. cN",
            @"MMMMMK,   oo.                   ;XNl .kW",
            @"MMMMMO.  ;KNx'                  lNx..oNM",
            @"MMMWNl  '0NXKOc.               .cc..dNWM",
            @"WW0:'. .cl,.....                 .;OWMMM",
            @"MMx.   :l.                     ..oXMMMMM",
        };
        public static string[] Dibujo { get => dibujo; set => dibujo = value; }
        public static void PreparandoEscenario()
        {
            Console.WindowWidth = 85; // Tamaño de la consola (Ancho)
            Console.WindowHeight = 41; // Tamaño de la consola (Alto)
            Console.BufferWidth = Console.WindowWidth; // Tamaño total de la consola (Ancho)
            Console.BufferHeight = Console.WindowHeight; // Tamaño total de la consola (Alto)

            Console.Title = "Benítez Peña José Daniel - Juego de Gato";

            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("******************************", 26, 0);
            WriteAt("         JUEGO DE GATO        ", 26, 1);
            WriteAt("******************************", 26, 2);
            Console.ResetColor();
        }
        public static void Tablero()
        {
            WriteAt("+-----------+", xTab, ++yTab);
            WriteAt("|   |   |   |", xTab, ++yTab);
            WriteAt("+-----------+", xTab, ++yTab);
            WriteAt("|   |   |   |", xTab, ++yTab);
            WriteAt("+-----------+", xTab, ++yTab);
            WriteAt("|   |   |   |", xTab, ++yTab);
            WriteAt("+-----------+", xTab, ++yTab);
            yTab -= 7; // 7 es el número de veces que se llama a la función WriteAt
        }
        public static void DibujarSilueta()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < dibujo.Length; i++)
            {
                WriteAt(Dibujo[i], 42, i + 4);
            }
            Console.ResetColor();
        }
    }
}
