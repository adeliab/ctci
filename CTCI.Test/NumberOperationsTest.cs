using CTCI.Lib;
using Shouldly;
using Xunit;

namespace CTCI.Test
{
	public class NumberOperationsTest
    {
		[Theory]
		[InlineData(0, 0)]
		[InlineData(1, 0)]
		[InlineData(2, 2)]
		[InlineData(10, 8)]
		[InlineData(19, 16)]
		[InlineData(32, 32)]
		public void GetHighestPowerOfTwo(int n, int expectedResult)
		{
			int result = NumberOperations.GetHighestPowerOfTwo(n);
			result.ShouldBe(expectedResult);
		}

		[Theory]
		[InlineData(1, 4, 2)]
		public void GetHammingDistance(int x, int y, int expectedHammingDistance)
		{
			int hammingDistance = NumberOperations.GetHammingDistance(x, y);
			hammingDistance.ShouldBe(expectedHammingDistance);
		}
	}
}
