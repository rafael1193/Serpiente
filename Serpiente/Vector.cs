using System;
using System.Collections.Generic;
using System.Text;

namespace Serpiente
{
    struct Vector
    {
        int posX;
        int posY;

        public Vector(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public int X
        {
            get { return posX; }
            set { posX = value; }
        }

        public int Y
        {
            get { return posY; }
            set { posY = value; }
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.posX + b.posX, a.posY + b.posY);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.posX - b.posX, a.posY - b.posY);
        }

        public static Vector operator *(Vector a, int b)
        {
            return new Vector(a.posX * b, a.posY * b);
        }

        public static Vector operator *(int a, Vector b)
        {
            return new Vector(a * b.posX, a * b.posY);
        }

        public override string ToString()
        {
            return "(" + posX.ToString() + ", " + posY.ToString() + ")";
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return (a.X == b.X && a.Y == b.Y);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a.X == b.X && a.Y == b.Y);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
