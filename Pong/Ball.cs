using System;

namespace Pong
{
	public class Ball
	{
		private int x;
		private int y;
		private int raggio;
		private const int speedX = 10;
		private const int speedY = 10;
		private int direzioneX = 1;
		private int direzioneY = 1;
		private byte r;
		private byte g;
		private byte b;
		public Ball ()
		{
			this.x = 600;
			this.y = 600;
			this.raggio = 15;
		}

		public int GetX()
		{
			return this.x;
		}

		public int GetY()
		{
			return this.y;
		}

		public int GetRaggio()
		{
			return this.raggio;
		}

		public int GetSpeedX()
		{
			return speedX;
		}

		public int GetSpeedY()
		{
			return speedY;
		}

		public void SetDirezioneX(int newDirez)
		{
			this.direzioneX = newDirez;
		}

		public void SetDirezioneY(int newDirez)
		{
			this.direzioneY = newDirez;
		}

		public int GetDirezioneX()
		{
			return this.direzioneX;
		}

		public int GetDirezioneY()
		{
			return this.direzioneY;
		}

		public void SetX(int x)
		{
			this.x = x;
		}

		public void SetY(int y)
		{
			this.y = y;
		}

		public void GetRaggio(int r)
		{
			this.raggio = r;
		}

		public byte GetR()
		{
			return this.r;
		}
		public byte GetG()
		{
			return this.g;
		}
		public byte GetB()
		{
			return this.b;
		}

		public void SetR(byte y)
		{
			this.r = y;
		}

		public void SetG(byte y)
		{
			this.g = y;
		}

		public void SetB(byte y)
		{
			this.b = y;
		}
		public void Update(int hRing, int wRing)
		{
			if((this.y >= hRing -raggio - 17) || (this.y <= 20+raggio))
				direzioneY *= -1;
			this.x = this.x + (speedX*direzioneX);
			this.y = this.y + (speedY*direzioneY);
			this.r = 255;
			this.g = 255;
			this.b = 255;
		}

	}
}

