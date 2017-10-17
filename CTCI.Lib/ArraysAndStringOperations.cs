﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CTCI.Lib
{
	public class ArraysAndStringOperations
    {
		public static bool IsUnique(string text)
		{
			if (string.IsNullOrEmpty(text))
				throw new ArgumentNullException(nameof(text), "Text cannot be null or empty");

			HashSet<char> foundCharacters = new HashSet<char>();

			for (int i = 0; i < text.Length; i++)
			{
				if (foundCharacters.Contains(text[i]))
					return false;

				foundCharacters.Add(text[i]);
			}

			return true;
		}

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

		public static string GetFirstName(string fullName)
		{
			if (string.IsNullOrEmpty(fullName))
				return string.Empty;

			string[] names = fullName.Split(' ');

			return names[0];
		}

		public static string GetLastName(string fullName)
		{
			if (string.IsNullOrEmpty(fullName))
				return string.Empty;

			string[] names = fullName.Split(' ');

			if (names.Length == 1)
				return fullName;

			return string.Join(' ', names, 1, names.Length - 1);
		}

		public static string[] GetHouseNumberAndSuffix(string address1, string address2, string address3)
		{
			string[] streetHouseNumberAndSuffix = new string[3];
			string completeAddress = string.Join(" ", address1, address2, address3).Trim();
			streetHouseNumberAndSuffix[0] = completeAddress;
			string regex = @"(?<number>\d+)[-/ ]{0,1}(?<suffix>[a-zA-Z-/]+){0,1}";

			MatchCollection matches = Regex.Matches(completeAddress, regex);
			if(matches.Count > 0)
			{
				Match lastMatch = matches[matches.Count - 1];
				string houseNumber = lastMatch.Groups["number"].Value;
				if (!string.IsNullOrEmpty(houseNumber))
					streetHouseNumberAndSuffix[1] = houseNumber;
				string suffix = lastMatch.Groups["suffix"].Value;
				if (!string.IsNullOrEmpty(suffix) && suffix.Length < 6)
					streetHouseNumberAndSuffix[2] = suffix;
			}

			return streetHouseNumberAndSuffix;
		}
	}
}
