using System;
using Aiv.Draw.OpenGL;
namespace Pong
{
	public class Bar
	{
		private int height;	
		private int widht;		
		private int speed;		
		private KeyCode up;
		private KeyCode down;
		private int x;
		private int y;
		private int points;

		public Bar (int x, int y, KeyCode newUp, KeyCode newDown)
		{
			this.height = 150;
			this.widht = 15;
			this.speed = 7;
			this.x = x;
			this.y = y;
			this.up = newUp;
			this.down = newDown;
			this.points = 0;
		}

		public int GetX()
		{
			return this.x;
		}

		public int GetY()
		{
			return this.y;
		}

		public int GetHeight()
		{
			return this.height;
		}

		public int GetWidht()
		{
			return this.widht;
		}

		public int GetSpeed()
		{
			return this.speed;
		}

		public void SetX(int x)
		{
			this.x = x;
		}

		public void GetY(int y)
		{
			this.y = y;
		}

		public void SetHeight(int height)
		{
			this.height = height;
		}

		public void SetWidht(int widht)
		{
			this.widht = widht;
		}

		public int GetPoints()
		{
			return this.points;
		}

		//In questo metodo facciamo gli UPDATE della barra del player 1
		public void Move(Window window, Ball ball)
		{
			if(window.GetKey(this.up))
			{
				this.y -= this.speed;
			}

			if(window.GetKey(this.down))
			{
				this.y += this.speed;
			}

			//Controllo pe non superare il bordo superiore
			if (this.y <= 14)
				this.y = 20;
			//Controllo per non superare il bordo inferiore
			if (this.y >= window.height-this.height-17)
				this.y = window.height - this.height-20;

			//int distance = (int)(ball.GetRaggio() *  26.67)/100;

			//Controllo il punto della barra in cui è avvenuto il contatto con la pallina per far cambiare l'angolazione del tiro 
			if ((ball.GetX () + ball.GetRaggio()-17 >= this.x - 15) && (ball.GetY () >= this.y) && (ball.GetY () <= this.y + this.height)) 
			{
				ball.SetDirezioneX (ball.GetDirezioneX () * -1);
				ball.SetR(255);
				ball.SetG(0);
				ball.SetB(0);
				if ((ball.GetY () < this.y + (height / 5)))
					ball.SetDirezioneY (-2);
				else if ((ball.GetY () < (this.y + (height / 5) * 2)))
					ball.SetDirezioneY (-1);
				else if ((ball.GetY () < (this.y + (height / 5) * 3)))
					ball.SetDirezioneY (0);
				else if ((ball.GetY () < (this.y + (height / 5) * 4)))
					ball.SetDirezioneY (1);
				else
					ball.SetDirezioneY (2);
			} 
			else if (ball.GetX () > window.width) 
			{
				points++;
				ball.SetX (window.width/2);
				ball.SetY (window.height/2);
				if (RandomGenerator.GetRandom (0, 1) == 0)
					ball.SetDirezioneX (-1);
				else ball.SetDirezioneX (1);
				ball.SetDirezioneY (RandomGenerator.GetRandom (-2, 2));

			}
				

		 }

		//In questo metodo facciamo gli UPDATE della barra del player 2
		public void Move2(Window window, Ball ball, int h)
		{
			if(window.GetKey(this.up))
			{
				this.y -= this.speed;
			}

			if(window.GetKey(this.down))
			{
				this.y += this.speed;
			}
			//Controllo per non superare il bordo superiore
			if (this.y <= 14)
				this.y = 20;
			
			//Controllo per non superare il bordo inferiore
			if (this.y >= h-this.height-17)
				this.y = window.height - this.height-20;



			//Controllo il punto della barra in cui è avvenuto il contatto con la pallina per far cambiare l'angolazione del tiro
			if ((ball.GetX ()-ball.GetRaggio() <= this.x+15) && (ball.GetY () >= this.y) && (ball.GetY () <= this.y + this.height)) 
			{
				ball.SetDirezioneX (ball.GetDirezioneX () * -1);
				ball.SetR(0);
				ball.SetG(255);
				ball.SetB(0);
				if ((ball.GetY () < this.y + (height / 5)))
					ball.SetDirezioneY (-2);

				else if ((ball.GetY () < (this.y + (height / 5) * 2)))
					ball.SetDirezioneY (-1);

				else if ((ball.GetY () < (this.y + (height / 5) * 3)))
					ball.SetDirezioneY (0);

				else if ((ball.GetY () < (this.y + (height / 5) * 4)))
					ball.SetDirezioneY (1);
				else 
					ball.SetDirezioneY (2);
			}
			if (ball.GetX () < 0) 
			{
				points++;
				ball.SetX (window.width/2);
				ball.SetY (window.height/2);
				if (RandomGenerator.GetRandom (0, 1) == 0)
					ball.SetDirezioneX (-1);
				else ball.SetDirezioneX (1);
				ball.SetDirezioneY (RandomGenerator.GetRandom (-2, 2));
			}
		}
	}
}

