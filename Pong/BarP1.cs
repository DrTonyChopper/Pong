using System;
using Aiv.Draw.OpenGL;


namespace Pong
{
	public class BarP1 : Bar
	{
		public BarP1 ():base(GetHeight(), GetWidht(), GetSpeed(), GetX(), GetY())
		{
		}
			
		public void Move(Window window, Ball ball, int h)
		{
			if (window.GetKey (KeyCode.Up)) {
				this.y -= this.speed;
			}

			if (window.GetKey (KeyCode.Down)) {
				this.y += this.speed;
			}

			if (this.y <= 14)
				this.y += this.speed;

			if (this.y >= h - this.height - 15)
				this.y -= this.speed;

			if ((ball.GetX () == this.x - 15) && (ball.GetY () >= this.y) && (ball.GetY () <= this.y + this.height)) {
				ball.SetDirezioneX (ball.GetDirezioneX () * -1);

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
		}
	}
}

