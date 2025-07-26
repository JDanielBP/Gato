namespace Gato.src.app
{
    internal interface IJugador
    {
        public int Id { get; }
        public char Simbolo { get; }

        void Jugar();
    }
}
