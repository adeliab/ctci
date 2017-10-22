using System;
using System.Collections;

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

		public static int GetHammingDistance(int x, int y)
		{
			BitArray xInBit = new BitArray(new int[] { x });
			BitArray yInBit = new BitArray(new int[] { y });

			int hammingDistance = 0;
			for(int i = 0; i < xInBit.Length; i++)
			{
				if (xInBit[i] ^ yInBit[i])
					hammingDistance++;
			}

			return hammingDistance;
		}
	}
}
