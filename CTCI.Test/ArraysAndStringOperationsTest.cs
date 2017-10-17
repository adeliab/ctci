using CTCI.Lib;
using System;
using Xunit;
using Shouldly;

namespace CTCI.Test
{
    public class ArraysAndStringOperationsTest
    {
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void IsUnique_ThrowArgumentNullException(string text)
		{
			Exception ex = Should.Throw<ArgumentNullException>(() => ArraysAndStringOperations.IsUnique(text));
			ex.Message.ShouldBe("Text cannot be null or empty\r\nParameter name: text");
		}

		[Theory]
		[InlineData("abcde")]
		[InlineData("12345")]
		[InlineData("ab cd")]
		[InlineData("!@#$%")]
		public void IsUnique_True(string text)
		{
			bool isUnique = ArraysAndStringOperations.IsUnique(text);
			isUnique.ShouldBeTrue();
		}

		[Theory]
		[InlineData("test")]
		[InlineData("ab cd ")]
		[InlineData("!abcd!")]
		public void IsUnique_False(string text)
		{
			bool isUnique = ArraysAndStringOperations.IsUnique(text);
			isUnique.ShouldBeFalse();
		}

		[Theory]
		[InlineData(new int[] { 16, 17, 4, 3, 5, 2 }, new int[] { 17, 5, 5, 5, 2, -1 })]
		[InlineData(new int[] { 16, 17, 4, 3, -5, -3 }, new int[] { 17, 4, 3, -1, -1, -1 })]
		public void SetToRightLargestNumber(int[] numbers, int[] expectedResult)
		{
			int[] result = ArraysAndStringOperations.SetToRightLargestNumber(numbers);

			for (int i = 0; i < numbers.Length; i++)
				expectedResult[i].ShouldBe(result[i]);
		}

		[Theory]
		[InlineData(null, "")]
		[InlineData("", "")]
		[InlineData("John", "John")]
		[InlineData("John Smith", "John")]
		[InlineData("John Smith Dowes", "John")]
		public void GetFirstName(string name, string expectedFirstName)
		{
			string firstName = ArraysAndStringOperations.GetFirstName(name);

			firstName.ShouldBe(expectedFirstName);
		}

		[Theory]
		[InlineData(null, "")]
		[InlineData("", "")]
		[InlineData("John", "John")]
		[InlineData("John Smith", "Smith")]
		[InlineData("John Smith Dowes", "Smith Dowes")]
		public void GetLastName(string name, string expectedLastName)
		{
			string lastName = ArraysAndStringOperations.GetLastName(name);

			lastName.ShouldBe(expectedLastName);
		}

		[Theory]
		[InlineData("Theresiastraat Test 2 151", null, null, "151", null)]
		[InlineData("Theresiastraat Test 2 151-AB", null, null, "151", "AB")]
		[InlineData("Theresiastraat Test 2 151 Netherlands", null, null, "151", null)]
		[InlineData("Theresiastraat Test 2 151/AB", "Office Space", "Netherlands", "151", "AB")]
		public void GetHouseNumberAndSuffix(string address1, string address2, string address3, string expectedHouseNumber, string expectedSuffix)
		{
			string[] houseNumberAndSuffix = ArraysAndStringOperations.GetHouseNumberAndSuffix(address1, address2, address3);
			houseNumberAndSuffix[0].ShouldBe(string.Join(' ', address1, address2, address3).Trim());
			houseNumberAndSuffix[1].ShouldBe(expectedHouseNumber);
			houseNumberAndSuffix[2].ShouldBe(expectedSuffix);
		}
	}
}
