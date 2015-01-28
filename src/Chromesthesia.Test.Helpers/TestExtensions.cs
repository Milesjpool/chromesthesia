using System;
using System.Collections.Generic;

namespace Chromesthesia.Test.Helpers
{
	public static class TestExtensions
	{
		public static bool ContainsAll(this string input, IEnumerable<string> list)
		{
			foreach (var element in list)
			{
				if (!input.Contains(element))
				{
					LogFailure(input, element);
					return false;
				}
			}
			return true;
		}

		private static void LogFailure(string input, string element)
		{
			Console.WriteLine("Assertion Failed!");
			Console.WriteLine("Input:");
			Console.WriteLine("------");
			Console.WriteLine(input);
			Console.WriteLine("------");
			Console.WriteLine("Does not contain: " + element);
			Console.WriteLine();
		}
	}
}