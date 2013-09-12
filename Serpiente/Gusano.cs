using System;
using System.Collections.Generic;
using System.Text;

namespace Serpiente
{
    class Gusano
    {
        private Vector pos;
        private int vel;
        private Direccion dir;
        private int lon;
        private ConsoleColor color;

        private List<Vector> cola;

        public Gusano(Vector posicion, int velocidad, Direccion direccion, int longitud, ConsoleColor color)
        {
            pos = posicion;
            vel = velocidad;
            lon = longitud;
            this.color = color;

            cola = new List<Vector>(longitud);
            cola.Add(new Vector(pos.X, pos.Y));
        }

        public Vector Posicion
        {
            get { return pos; }
            set { pos = value; }
        }

        public int Velocidad
        {
            get { return vel; }
            set { vel = value; }
        }

        public Direccion Direccion
        {
            get { return dir; }
            set { dir = value; }
        }

        public int Longitud
        {
            get { return lon; }
            set { lon = value; }
        }

        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public void Mover()
        {
            Vector antiguaPos = new Vector(pos.X, pos.Y);

            switch (dir)
            {
                case Direccion.Arriba:
                    pos.Y -= vel;
                    break;
                case Direccion.Abajo:
                    pos.Y += vel;
                    break;
                case Direccion.Izquierda:
                    pos.X -= vel;
                    break;
                case Direccion.Derecha:
                    pos.X += vel;
                    break;
            }

            //Actualizar cola
            while (cola.Count < lon)
            {
                cola.Add(new Vector(cola[cola.Count - 1].X, cola[cola.Count - 1].Y + 1));
            }

            cola.Insert(0, antiguaPos);
            cola.RemoveAt(cola.Count - 1);

            //Comprobar si se ha comido
            for (int i = 0; i < cola.Count; i++)
            {
                if (cola.Contains(pos))
                    Program.FinDeJuego("¡No muerdas a ti mismo!");
            }

        }

        public void Dibujar()
        {
            int ConsX = Console.CursorLeft;
            int ConsY = Console.CursorTop;
            ConsoleColor colorAnterior = Console.BackgroundColor;

            Console.SetCursorPosition(pos.X, pos.Y);
            Console.BackgroundColor = color;
            Console.Write(' ');

            for(int i = 0;i<cola.Count;i++)
            {
                Console.SetCursorPosition(cola[i].X, cola[i].Y);
                Console.Write(' ');
            }
            Console.SetCursorPosition(ConsX, ConsY);
            Console.BackgroundColor = colorAnterior;

        }

    }
}
