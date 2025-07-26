using Gato.src.Helpers;
using Gato.src.Jugadores;
using System;

namespace Gato.src.Juego
{
    internal class JuegoApp
    {
        Tablero tablero;
        IJugador p1;
        IJugador p2;
        public enum Estado
        {
            EnProgreso,
            Victoria,
            Empate
        }
        public JuegoApp(Tablero tablero, IJugador p1, IJugador p2)
        {
            this.tablero = tablero;
            this.p1 = p1;
            this.p2 = p2;
        }

        public (Estado, IJugador) Iniciar()
        {
            int turno = new Random().Next(2);
            IJugador jugador = null;
            tablero.PosicionInicial();
            Estado estado = Estado.EnProgreso;

            while (true)
            {
                if (turno == 0) jugador = p1;
                else jugador = p2;

                MostrarTurno(jugador);
                jugador.Jugar();

                estado = EvaluarEstado(jugador);
                if (estado != Estado.EnProgreso) break;
                turno = 1 - turno;
            };

            if (estado == Estado.Empate) jugador = null;
            return (estado, jugador);
        }
        public bool VolverAJugar()
        {
            while (true)
            {
                CursorHelper.WriteAt("¿Volver a jugar? S/N", 0, 22);
                Console.SetCursorPosition(0, 23);
                string input = Console.ReadLine().Trim().ToUpper();

                if (char.TryParse(input, out char result) && (result == 'S' || result == 'N'))
                    return result == 'S';

                CursorHelper.WriteAt("Ingresa un valor válido...", 0, 25);
                Console.ReadKey(true);
                CursorHelper.WriteAt("                          ", 0, 23);
                CursorHelper.WriteAt("                          ", 0, 25);
            }
        }

        private void MostrarTurno(IJugador p)
        {
            Console.ResetColor();
            CursorHelper.WriteAt($"Jugador {p.Id} ", 12, 4);
            Console.ForegroundColor = p.Simbolo == 'X' ? ConsoleColor.Green : ConsoleColor.Red;
            CursorHelper.WriteAt("Te toca: " + p.Simbolo, 12, 5);
        }
        private Estado EvaluarEstado(IJugador jugador)
        {
            char[,] tablero = this.tablero.TableroMatriz;
            for (int i = 0; i < 3; i++)
            {
                // Comprobar Filas
                if (tablero[0, i] == jugador.Simbolo && tablero[1, i] == jugador.Simbolo && tablero[2, i] == jugador.Simbolo)
                {
                    return Estado.Victoria;
                }
                // Comprobar Columnas
                if (tablero[i, 0] == jugador.Simbolo && tablero[i, 1] == jugador.Simbolo && tablero[i, 2] == jugador.Simbolo)
                {
                    return Estado.Victoria;
                }
            }
            // Compobar Diagonales
            if (tablero[0, 0] == jugador.Simbolo && tablero[1, 1] == jugador.Simbolo && tablero[2, 2] == jugador.Simbolo)
            {
                return Estado.Victoria;
            }
            if (tablero[0, 2] == jugador.Simbolo && tablero[1, 1] == jugador.Simbolo && tablero[2, 0] == jugador.Simbolo)
            {
                return Estado.Victoria;
            }
            // Qué pasa si nadie gana?
            if (tablero[0, 0] != ' ' && tablero[0, 1] != ' ' && tablero[0, 2] != ' '
                && tablero[1, 0] != ' ' && tablero[1, 1] != ' ' && tablero[1, 2] != ' '
                && tablero[2, 0] != ' ' && tablero[2, 1] != ' ' && tablero[2, 2] != ' ')
            {
                return Estado.Empate;
            }
            // Si nada se cumple
            return Estado.EnProgreso;
        }
    }
}
