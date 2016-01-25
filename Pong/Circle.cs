using System;
using Aiv.Fast2D;

namespace Pong
{
    class Circle
    {
        public static void DrawCircle(Window window, int x0, int y0, int radius, byte r, byte g, byte b)
        {
            int x = radius;
            int y = 0;
            int decisionOver2 = 1 - x;   // Decision criterion divided by 2 evaluated at x=r, y=0

            while (y <= x)
            {
                Ring.PutPixel(window, x + x0, y + y0, r, g, b); // Octant 1
				Ring.PutPixel(window, y + x0, x + y0, r, g, b); // Octant 2
				Ring.PutPixel(window, -x + x0, y + y0, r, g, b); // Octant 4
				Ring.PutPixel(window, -y + x0, x + y0, r, g, b); // Octant 3
				Ring.PutPixel(window, -x + x0, -y + y0, r, g, b); // Octant 5
				Ring.PutPixel(window, -y + x0, -x + y0, r, g, b); // Octant 6
				Ring.PutPixel(window, x + x0, -y + y0, r, g, b); // Octant 8
				Ring.PutPixel(window, y + x0, -x + y0, r, g, b); // Octant 7
                y++;
                if (decisionOver2 <= 0)
                {
                    decisionOver2 += 2 * y + 1;   // Change in decision criterion for y -> y+1
                }
                else
                {
                    x--;
                    decisionOver2 += 2 * (y - x) + 1;   // Change for y -> y+1, x -> x-1
                }
            }
        }

        //Credits per il disegno del cerchio: Wikipedia ed un ragazzo di seconda
    }
}
