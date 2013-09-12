using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Serpiente
{
	class Program
	{
		public static int tamañoEscenarioX = 80;
		public static int tamañoEscenarioY = 30;
		public static int puntos = 0;
		public static int intervaloJuego = 240;

		static void Main (string[] args)
		{
			Console.CursorVisible = false;
			Console.SetWindowSize (tamañoEscenarioX, tamañoEscenarioY);
			if (System.Environment.OSVersion.Platform == PlatformID.Win32NT) {
				Console.SetBufferSize (tamañoEscenarioX, tamañoEscenarioY);
			}

			Random aleator = new Random ();
			Comida com = new ComidaRica (new Vector (aleator.Next (tamañoEscenarioX), aleator.Next (tamañoEscenarioY)));

			Gusano gus = new Gusano (new Vector (5, 5), 1, Direccion.Arriba, 2, ConsoleColor.Green);

			Console.Beep (294, 100); //Re
			Console.Beep (294, 100); //Re
			Console.Beep (294, 100); //Re
			Console.Beep (233, 100); //Sib bajo
			Console.Beep (294, 100); //Re
			Console.Beep (349, 100); //Fa
			Console.Beep (174, 100); //Fa bajo

			while (true) {
				//Comprobar teclas
				if (Console.KeyAvailable) {
					ConsoleKeyInfo tecla = Console.ReadKey (true);
					if (tecla.Key == ConsoleKey.UpArrow) {
						gus.Direccion = Direccion.Arriba;
					}

					if (tecla.Key == ConsoleKey.DownArrow) {
						gus.Direccion = Direccion.Abajo;
					}

					if (tecla.Key == ConsoleKey.LeftArrow) {
						gus.Direccion = Direccion.Izquierda;
					}

					if (tecla.Key == ConsoleKey.RightArrow) {
						gus.Direccion = Direccion.Derecha;
					}
				}

				//Mover el gusano y comprobar que no se ha salido
				gus.Mover ();
				if (gus.Posicion.X < 0 || gus.Posicion.Y < 0 || gus.Posicion.X > Console.WindowWidth || gus.Posicion.Y > Console.WindowHeight) {
					FinDeJuego ("¡¡¡Has muerto!!!");
				}

				//Comprobar si se come la comida
				if (gus.Posicion == com.Posicion) {
					Console.Beep (988, 10); //Si4
					Console.Beep (1175, 70); //Re4
					puntos += com.Puntos; //Aumenta los puntos
					gus.Longitud += 4; //Aumenta el tamaño si ha comido
					if (intervaloJuego >= 10) {
						intervaloJuego -= 10; //Aumenta la velocidad del juego
					}

					Random numeroAl = new Random ();

					Vector nuevaPosicion = new Vector (numeroAl.Next (tamañoEscenarioX), numeroAl.Next (tamañoEscenarioY));
					while (nuevaPosicion == gus.Posicion) {
						nuevaPosicion = new Vector (numeroAl.Next (tamañoEscenarioX), numeroAl.Next (tamañoEscenarioY)); //Se genera aleatoriamente la nueva posicion de la comida
					}

					switch (numeroAl.Next (0, 2)) {
					case 0:
						com = new Comida (nuevaPosicion);
						break;
					case 1:
						com = new ComidaRica (nuevaPosicion);
						break;
					default:
						break;
					}
				}
				Console.Clear ();

				//Dibujar comida
				com.Dibujar ();

				//Dibujar el gusano
				gus.Dibujar ();

				System.Threading.Thread.Sleep (intervaloJuego);
			}
		}

		public static void FinDeJuego (string mensaje)
		{
			Console.Clear ();
			Console.SetCursorPosition (25, 14);
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write (mensaje);
			Console.SetCursorPosition (25, 15);
			Console.Write ("Has conseguido: " + puntos + " puntos");
			System.Threading.Thread.Sleep (2000);
			Console.ReadKey (true);
			Environment.Exit (0);
		}
	}
}
