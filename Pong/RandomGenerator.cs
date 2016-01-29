using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
	static class RandomGenerator
	{
		private static Random r;
		static RandomGenerator()
		{
			r = new Random(Guid.NewGuid().GetHashCode());
		}

		public static int GetRandom(int min, int max)
		{
			return r.Next(min,max+1);
		}
	}
}
