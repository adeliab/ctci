using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.Lib
{
	public class NumberOperations
	{
		public static int GetHighestPowerOfTwo(int n)
		{
			int lastPowOfTwo = 0;

			if (n >= 2)
			{
				for (int i = 1; i < 32; i++)
				{
					if (Math.Pow(2, i) > n)
						break;
					else
						lastPowOfTwo = (int)Math.Pow(2, i);
				}
			}

			return lastPowOfTwo;
		}
	}
}
