using System;
using System.Collections.Generic;
using System.Text;

namespace Serpiente
{
    class ComidaRica:Comida
    {
        public ComidaRica(Vector posicion):base(posicion)
        {
            base.posicion = posicion;
            base.color = ConsoleColor.Red;
            base.forma = '°';
            base.puntos = 500;
        }
    }
}
