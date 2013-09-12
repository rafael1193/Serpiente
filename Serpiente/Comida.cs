using System;
using System.Collections.Generic;
using System.Text;

namespace Serpiente
{
    class Comida
    {
        protected ConsoleColor color = ConsoleColor.Cyan;
        protected char forma = '·';
        protected Vector posicion;
        protected int puntos = 100;

        public Comida(Vector posicion)
        {
            this.posicion = posicion;
        }

        public Vector Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }

        public void Dibujar()
        {
            int ConsX = Console.CursorLeft;
            int ConsY = Console.CursorTop;
            ConsoleColor colorAnterior = Console.ForegroundColor;

            Console.SetCursorPosition(posicion.X, posicion.Y);
            Console.ForegroundColor = color;
            Console.Write(forma);

            Console.SetCursorPosition(ConsX, ConsY);
            Console.ForegroundColor = colorAnterior;
        }
    }
}
