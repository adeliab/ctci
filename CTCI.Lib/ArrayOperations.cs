using System;

namespace CTCI.Lib
{
	public class ArrayOperations
    {
		public static int[] SetToRightLargestNumber(int[] numbers)
		{
			int n = numbers.Length;

			if (n < 0)
				throw new ArgumentException(nameof(numbers));
			
			int rightLargestNumber = -1;

			for (int i = n - 1; i >= 0; i--)
			{
				int currentNumber = numbers[i];
				numbers[i] = rightLargestNumber;
				rightLargestNumber = Math.Max(rightLargestNumber, currentNumber);
			}

			return numbers;
		}
	}
}
