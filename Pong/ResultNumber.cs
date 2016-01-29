using System;
using Aiv.Draw.OpenGL;

namespace Pong
{
	public class ResultNumber
	{
		private Sprite sprite;
		private int x;
		private int y;
		private int indexY;
		private int indexX;
		private bool change;

		public ResultNumber (int newX, int newY, bool chan)
		{
			sprite = new Sprite ("../../Assets/text.png");
			x = newX;
			y = newY;
			indexY = 4;
			indexX = 2;
			change = chan;
		}

		public int getSprW()
		{
			return sprite.width;
		}

		public void CurrentResult(Window window, int result)
		{
			switch (result)
			{

			case 20:
			case 0:
				{
					indexX = 2;
					indexY = 4;
					break;
				}

			case 11:
			case 1:
				{
					indexX = 3;
					indexY = 4;
					break;
				}

			case 12:
			case 2:
				{
					indexX = 4;
					indexY = 4;
					break;
				}

			case 13:
			case 3:
				{
					indexX = 5;
					indexY = 4;
					break;
				}

			case 14:
			case 4:
				{
					indexX = 0;
					indexY = 5;
					break;
				}

			case 15:
			case 5:
				{
					indexX = 1;
					indexY = 5;
					break;
				}

			case 16:
			case 6:
				{
					indexX = 2;
					indexY = 5;
					break;
				}

			case 17:
			case 7:
				{
					indexX = 3;
					indexY = 5;
					break;
				}

			case 18:
			case 8:
				{
					indexX = 4;
					indexY = 5;
					break;
				}

			case 19:
			case 9:
				{
					indexX = 5;
					indexY = 5;
					break;
				}

			case 10:
				{
					indexX = 2;
					indexY = 4;
					if (!change) 
					{
						change = true;
						x += 70;
					}
					break;
				}
			default:
				break;
			}

			Ring.DrawSprite (window, sprite, x, y, sprite.width/6*indexX, sprite.height/7*indexY, sprite.width/6, sprite.height/7);

		}

		public void CurrentResultDec(Window window, int result)
		{
			switch (result) 
			{

			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
				{
					indexX = 1;
					indexY = 4;
					break;
				}

			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
				{
					indexX = 3;
					indexY = 4;
					break;
				}

			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
				{
					indexX = 4;
					indexY = 4;
					break;
				}
			default:
				break;
			}
			Ring.DrawSprite (window, sprite, x, y, sprite.width/6*indexX, sprite.height/7*indexY, sprite.width/6, sprite.height/7);
		}

	}
}

