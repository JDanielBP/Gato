using Gato.src.Helpers;
using System;

namespace Gato.src.Juego
{
    internal class Escenario
    {
        string[] silueta =
        {
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
            @"MMx.   :l.                     ..oXMMMMM"
        };

        public void Titulo()
        {
            Console.Title = "Benítez Peña José Daniel - Juego de Gato";
            Console.ForegroundColor = ConsoleColor.Green;
            CursorHelper.WriteAt("******************************", 26, 0);
            CursorHelper.WriteAt("         JUEGO DE GATO        ", 26, 1);
            CursorHelper.WriteAt("******************************", 26, 2);
            Console.ResetColor();
        }
        public void Silueta()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < silueta.Length; i++)
            {
                CursorHelper.WriteAt(silueta[i], 42, i + 4);
            }
            Console.ResetColor();
        }
        public void Cohete()
        {
            Console.CursorVisible = false;

            int x1 = 102;
            int y1 = 28;
            int tiempo = 150;

            int topey1 = 7;
            int auxy1 = y1;

            // Subida
            for (int yi = y1; yi > topey1; yi--)
            {
                CursorHelper.WriteAt("*", x1, yi);
                System.Threading.Thread.Sleep(tiempo / 4);
            }

            // Se borra la subida
            for (int yi = y1; yi > topey1 + 1; yi--)
            {
                CursorHelper.WriteAt(" ", x1, yi);
                --auxy1;
            }

            // Explosión
            int right = x1;
            int left = x1;
            int up = auxy1;
            int down = auxy1;
            for (int i = 0; i < 4; i++)
            {
                left -= 2;
                right += 2;
                up -= 1;
                down += 1;
                CursorHelper.WriteAt("*", left, up);
                CursorHelper.WriteAt("*", right, up);
                CursorHelper.WriteAt("*", left, down);
                CursorHelper.WriteAt("*", right, down);
                System.Threading.Thread.Sleep(tiempo);
            }

            Console.CursorVisible = true;
        }
    }
}
