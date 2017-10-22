using CTCI.Lib;
using Shouldly;
using System;
using Xunit;

namespace CTCI.Test
{
	public class StringOperationsTest
    {
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void IsUnique_ThrowArgumentNullException(string text)
		{
			Exception ex = Should.Throw<ArgumentNullException>(() => StringOperations.IsUnique(text));
			ex.Message.ShouldBe("Text cannot be null or empty\r\nParameter name: text");
		}

		[Theory]
		[InlineData("abcde")]
		[InlineData("12345")]
		[InlineData("ab cd")]
		[InlineData("!@#$%")]
		public void IsUnique_True(string text)
		{
			bool isUnique = StringOperations.IsUnique(text);
			isUnique.ShouldBeTrue();
		}

		[Theory]
		[InlineData("test")]
		[InlineData("ab cd ")]
		[InlineData("!abcd!")]
		public void IsUnique_False(string text)
		{
			bool isUnique = StringOperations.IsUnique(text);
			isUnique.ShouldBeFalse();
		}

		[Theory]
		[InlineData(null, "")]
		[InlineData("", "")]
		[InlineData("John", "John")]
		[InlineData("John Smith", "John")]
		[InlineData("John Smith Dowes", "John")]
		public void GetFirstName(string name, string expectedFirstName)
		{
			string firstName = StringOperations.GetFirstName(name);

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
			string lastName = StringOperations.GetLastName(name);

			lastName.ShouldBe(expectedLastName);
		}

		[Theory]
		[InlineData("Theresiastraat Test 2 151", null, null, "151", null)]
		[InlineData("Theresiastraat Test 2 151-AB", null, null, "151", "AB")]
		[InlineData("Theresiastraat Test 2 151 Netherlands", null, null, "151", null)]
		[InlineData("Theresiastraat Test 2 151/AB", "Office Space", "Netherlands", "151", "AB")]
		public void GetHouseNumberAndSuffix(string address1, string address2, string address3, string expectedHouseNumber, string expectedSuffix)
		{
			string[] houseNumberAndSuffix = StringOperations.GetHouseNumberAndSuffix(address1, address2, address3);
			houseNumberAndSuffix[0].ShouldBe(string.Join(' ', address1, address2, address3).Trim());
			houseNumberAndSuffix[1].ShouldBe(expectedHouseNumber);
			houseNumberAndSuffix[2].ShouldBe(expectedSuffix);
		}

		[Theory]
		[InlineData("UD", true)]
		[InlineData("LL", false)]
		[InlineData("URRDLL", true)]
		public void JudgeCircle(string moves, bool expectedIsCircle)
		{
			bool isCircle = StringOperations.JudgeCircle(moves);
			isCircle.ShouldBe(expectedIsCircle);
		}
	}
}
