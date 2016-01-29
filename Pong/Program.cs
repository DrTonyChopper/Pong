using System;
using Aiv.Draw.OpenGL;

namespace Pong
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Window window = new Window (1200, 700, "RingPong", PixelFormat.RGB);
			//Definizione : Ring, Finestra del programma, Palla, Barra Player 1, Barra Player 2
			Ring ring = new Ring (window);
			Ball ball = new Ball ();
			//Parametri Bar : Posizione X, Posizione Y, Comando per andare su, Comando per andare giù
			Bar bar1= new Bar (window.width-25, window.height/2, KeyCode.Up, KeyCode.Down);
			Bar bar2 = new Bar (10, window.height/2, KeyCode.W, KeyCode.S);

			//Inizio Gioco
			bool isGameRunning = true;
			while (isGameRunning) 
			{
				//Pulizia della Finestra
				ring.Clear(window, 0, 0, 0);

				ring.Update (window, bar1, bar2, ball);

				window.Blit();
				//Scrittura del punteggio 
				if (bar1.GetPoints () == 15)
				{
					Console.WriteLine ("Player 1 VINCE");
					isGameRunning = false;
				}
				else if (bar2.GetPoints () == 15)
				{
					Console.WriteLine ("Player 2 VINCE");
					isGameRunning = false;
				}

			}
		}
	}
}
