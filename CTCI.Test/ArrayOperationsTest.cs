using CTCI.Lib;
using System;
using Xunit;
using Shouldly;

namespace CTCI.Test
{
    public class ArrayOperationsTest
    {
		[Theory]
		[InlineData(new int[] { 16, 17, 4, 3, 5, 2 }, new int[] { 17, 5, 5, 5, 2, -1 })]
		[InlineData(new int[] { 16, 17, 4, 3, -5, -3 }, new int[] { 17, 4, 3, -1, -1, -1 })]
		public void SetToRightLargestNumber(int[] numbers, int[] expectedResult)
		{
			int[] result = ArrayOperations.SetToRightLargestNumber(numbers);

			for (int i = 0; i < numbers.Length; i++)
				expectedResult[i].ShouldBe(result[i]);
		}
	}
}
