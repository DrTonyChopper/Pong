using System;
using Aiv.Draw.OpenGL;

namespace Pong
{
	public class Ring
	{
		// ring's dimensions
		private const int ringWight = 900;
		private const int ringHeight = 700;
		private ResultNumber numb1;
		private ResultNumber numb2;
		private ResultNumber numb3;
		private ResultNumber numb4;
		//private ResultNumber numb3;

		public Ring (Window window)
		{
			numb1 = new ResultNumber (window.width/2 - 170, 30, true );
			numb2 = new ResultNumber (window.width/2 - 100, 30, true );
			numb3 = new ResultNumber (window.width/2+5, 28, true );
			numb4 = new ResultNumber (window.width / 2+5, 28, false );
		}

		public void Clear(Window window, byte r, byte g, byte b)
		{
			for(int y = 0; y < window.height; y++)
			{
				for (int x = 0; x < window.width; x++) 
				{
					PutPixel (window, x, y, r, g, b);
				}
			}
		}

		//Stampa rettangoli pieni, parametri: finestra, x, y, RGB, larghezza, altezza
		public void DrawRectFilled(Window window, int x, int y, byte r, byte g, byte b, int z, int h)
		{
			for(int i = 0; i < z; i++)
				DrawVertLine(window, x+i, y, r, g, b, h);
		}

		public void DrawVertLine(Window window, int x, int y, byte r, byte g, byte b, int h)
		{
			for (int posY = y; posY < h + y; posY++) 

			{
				PutPixel (window, x, posY, r, g, b);
			}
		}

		public static void PutPixel (Window window, int x, int y, byte r, byte g, byte b)
		{
			if (x < 0 || x > window.width - 1 || y < 0 || y > window.height - 1)
				return;
			int pos = (y * 3 * window.width) + x*3;
			window.bitmap[pos] = r;
			window.bitmap[pos+1] = g;
			window.bitmap[pos+2] = b;
		}

		public void Update(Window window, Bar bar1, Bar bar2, Ball ball)
		{
			//Disegno parte superiore del Ring
			this.DrawRectFilled (window, 10, 10, 255, 255, 255, window.width-20, 10);
			//Disegno parte inferiore del Ring
			this.DrawRectFilled (window, 10, window.height-20, 255, 255, 255, window.width-20, 10);
			//Disegno righe tratteggiate che separano il ring
			int k = 20;
			while(k < window.height-20)
			{
				this.DrawRectFilled(window, window.width/2, k, 255, 255, 255, 7, 30);
				k += 40;
			}
			//Disegno la Palla
			//this.DrawRectFilled (window, ball.GetX(), ball.GetY(), ball.GetR(), ball.GetG(), ball.GetB(), ball.GetWidht(), ball.GetHeight());
			this.DrawCircle(window, ball.GetX(), ball.GetY(), ball.GetRaggio(), 255, 255, 255);
			//Disegno la barra del Player 1
			this.DrawRectFilled (window, bar1.GetX(), bar1.GetY(), 255, 0, 0, bar1.GetWidht(), bar1.GetHeight());
			//Disegno la Barra del Player 2
			this.DrawRectFilled (window, bar2.GetX(), bar2.GetY(), 0, 255, 0, bar2.GetWidht(), bar2.GetHeight());
			//Movimeto barra del Player 1
			bar1.Move (window, ball);
			//Movimeto barra del Player 2
			bar2.Move2 (window, ball, window.height);
			//Movimeto della Palla
			ball.Update (window.height, window.width);

			numb1.CurrentResultDec (window, bar1.GetPoints());

			numb2.CurrentResult (window, bar1.GetPoints());

			numb3.CurrentResultDec (window, bar2.GetPoints());

			numb4.CurrentResult (window, bar2.GetPoints());
		}

		public void DrawCircle(Window window, int j, int k, int radius, byte r, byte g, byte b)
		{
			for (int x = - radius; x < radius; x++)
			{
				int height = (int)Math.Sqrt(radius * radius - x * x);

				for (int y = -height; y < height; y++)
				{
					//if (y == -height || y == height - 1 || x == -radius || x == radius - 1)
					PutPixel(window, x + j, y + k, r, g, b);
				}
			}
		}

		public static void DrawSprite(Window window, Sprite sprite, int xpos, int ypos, int xoffset, int yoffset, int width, int height)
		{
			for (int y = yoffset; y < yoffset + height; y++)
			{
				for (int x = xoffset; x < xoffset + width; x++)
				{
					int position = (y * sprite.width * 4) + (x * 4);
					byte r = sprite.bitmap[position];
					byte g = sprite.bitmap[position + 1];
					byte b = sprite.bitmap[position + 2];
					byte a = sprite.bitmap[position + 3];

					if (a == 255)
						PutPixel(window, xpos + x - xoffset, ypos + y - yoffset, r, g, b);
				}
			}
		}
	}
}

